using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace MoveScreenshots
{
    static class RuleProcessor
    {
        #region Attributes
        private static Rule _curRule;
        private static frmProcessFeedback _processFeedbackForm;
        private static List<Rule> _ruleProcessingQueue = new List<Rule>();
        private static List<Rule> _completedRules = new List<Rule>();
        private static BackgroundWorker worker;
        #endregion

        #region Public Methods
        /// <summary>
        /// Takes action based on the rule's parameters.
        /// </summary>
        /// <param name="rule">Rule to be processed.</param>
        /// <param name="feedbackForm">Form used for user feedback.</param>
        public static void ProcessRule(Rule rule, frmProcessFeedback feedbackForm)
        {
            if (_ruleProcessingQueue.Count == 0)
            {
                _ruleProcessingQueue.Add(rule);
                _processFeedbackForm = feedbackForm;
                BeginProcessing();
            }
            else
            {
                _ruleProcessingQueue.Add(rule);
                _processFeedbackForm = feedbackForm;
            }
        }
        #endregion

        #region Private Methods
        private static void BeginProcessing()
        {
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.RunWorkerAsync();
        }

        private static void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _processFeedbackForm.SetProgress(e.ProgressPercentage, e.UserState.ToString());
        }

        private static void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            ProcessNext();
        }

        private static void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // if queue wasn't cleared due to cancelation, remove most recently processed rule from queue
            if (_ruleProcessingQueue.Count > 0)
                _ruleProcessingQueue.RemoveAt(0);
            else
            {
                _processFeedbackForm.DisableBtnCancel();
                _processFeedbackForm.EnableBtnOk();
                _processFeedbackForm.SetProgress(100, "Processing Canceled");
                PostProcessingReport();
                return;
            }

            // move to next rule in queue
            if (_ruleProcessingQueue.Count > 0)
            {
                BeginProcessing();
            }
            else
            {
                _processFeedbackForm.DisableBtnCancel();
                _processFeedbackForm.EnableBtnOk();
                _processFeedbackForm.SetProgress(100, "Done Processing");
                PostProcessingReport();
            }
        }

        private static void PostProcessingReport()
        {
            foreach(Rule curRule in _completedRules)
            {
                _processFeedbackForm.WriteFeedback($"{curRule.Name} - Files affected: {curRule.FilesAffectedCount}; Files ignored: {curRule.FilesIgnoredCount}");
            }

            _completedRules.Clear();
        }

        public static void CancelProcessing()
        {
            if (worker != null)
            {
                worker.CancelAsync();
            }

            _ruleProcessingQueue.Clear();
        }

        private static void ProcessNext()
        {
            // enable process cancelation btn for user
            _processFeedbackForm.EnableBtnCancel();

            // pull next rule from the queue
            _curRule = _ruleProcessingQueue[0];
            _processFeedbackForm.WriteFeedback("Processing " + _curRule.Name);
            _curRule.FilesAffectedCount = 0;
            _curRule.FilesIgnoredCount = 0;

            // ascertain which search pattern to use for the files
            string searchPattern1 = "", searchPattern2 = "";
            switch (_curRule.TypeOfFile)
            {
                case Rule.FileType.AllFiles:
                    searchPattern1 = "*.*";
                    break;
                case Rule.FileType.jpgAndPng:
                    searchPattern1 = "*.jpg";
                    searchPattern2 = "*.png";
                    break;
                case Rule.FileType.jpg:
                    searchPattern1 = "*.jpg";
                    break;
                case Rule.FileType.png:
                    searchPattern1 = "*.png";
                    break;
                default:
                    break;
            }


            // get a list of files to work with
            List<string> filepaths = new List<string>();
            if (searchPattern1 != "")
            {
                _processFeedbackForm.WriteFeedback("Fetching all files from " + _curRule.Source + " matching " + searchPattern1);
                try
                {
                    filepaths.AddRange(Directory.GetFiles(_curRule.Source, searchPattern1).ToList<string>());
                }
                catch (Exception ex)
                {
                    _processFeedbackForm.WriteFeedback("Fetching " + searchPattern1 + " from " + _curRule.Source + " failed. Error: " + ex.Message);
                }
            }
            if (searchPattern2 != "")
            {
                _processFeedbackForm.WriteFeedback("Fetching all files from " + _curRule.Source + " matching " + searchPattern2);
                try
                {
                    filepaths.AddRange(Directory.GetFiles(_curRule.Source, searchPattern2).ToList<string>());
                }
                catch (Exception ex)
                {
                    _processFeedbackForm.WriteFeedback("Fetching " + searchPattern2 + " from " + _curRule.Source + " failed. Error: " + ex.Message);
                }
            }

            // move/copy files to destination folder, skipping duplicates
            DirectoryInfo destination = new DirectoryInfo(_curRule.Destination);
            int curFile = 1;
            int filesMoved = 0;
            int filesCopied = 0;
            foreach (String filepath in filepaths)
            {
                // send progress update
                int progress = 0;
                double dblProgress = (curFile * 1.0) / (filepaths.Count * 1.0) * 100;
                progress = Convert.ToInt16(Math.Round(dblProgress, 0));
                worker.ReportProgress(progress, "Processing " + _curRule.Name + ": file " + curFile.ToString() + " of " + filepaths.Count);

                // begin work on file
                if (!worker.CancellationPending)
                {

                    FileInfo file = new FileInfo(filepath);
                    if (!new FileInfo(destination + "\\" + file.Name).Exists)
                    {
                        if (_curRule.TypeOfRule == Rule.RuleType.Consolidate)
                        {
                            _processFeedbackForm.WriteFeedback("Moving " + file.Name + " from " + file.DirectoryName + " to " + destination.ToString());
                            try
                            {
                                file.MoveTo(destination + "\\" + file.Name);
                                filesMoved++;
                                _curRule.FilesAffectedCount++;
                            }
                            catch (Exception ex)
                            {
                                _processFeedbackForm.WriteFeedback("Moving " + file.Name + " from " + file.DirectoryName + " to " + destination.ToString() + " failed. Error: " + ex.Message);
                            }
                        }
                        if (_curRule.TypeOfRule == Rule.RuleType.Backup)
                        {
                            _processFeedbackForm.WriteFeedback("Copying " + file.Name + " from " + file.DirectoryName + " to " + destination.ToString());
                            try
                            {
                                file.CopyTo(destination + "\\" + file.Name);
                                filesCopied++;
                                _curRule.FilesAffectedCount++;
                            }
                            catch (Exception ex)
                            {
                                _processFeedbackForm.WriteFeedback("Copying " + file.Name + " from " + file.DirectoryName + " to " + destination.ToString() + " failed. Error: " + ex.Message);
                            }
                        }
                    }
                    else
                    {
                        _processFeedbackForm.WriteFeedback("File not " + (_curRule.TypeOfRule == Rule.RuleType.Backup ? "copied: " : "moved: ") + file.Name + " already exists in " + destination.ToString());
                        _curRule.FilesIgnoredCount++;
                    }
                }
                else
                {
                    _processFeedbackForm.WriteFeedback("Processing Canceled.");
                    _completedRules.Add(_curRule);
                    _curRule = null;
                    return;
                }

                curFile++;
            }
            
            _processFeedbackForm.WriteFeedback(_curRule.Name + ": Done.");
            _completedRules.Add(_curRule);
            _curRule = null;
        }
        #endregion
    }
}
