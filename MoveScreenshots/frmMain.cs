using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MoveScreenshots
{
    public partial class frmMain : Form
    {
        #region Class Level Variables
        /// <summary>
        /// The current name for the application.
        /// </summary>
        public static string ApplicationName = "Mule";

        private List<Rule> ConsolidationRuleList;
        private List<Rule> BackupRuleList;
        private frmProcessFeedback ProcessFeedbackForm;

        private enum BatchFileType { Consolidation, Backup, All }
        #endregion

        #region frmMain Methods
        public frmMain()
        {
            InitializeComponent();

            // Check for application updates
            InstallUpdateSyncWithInfo();

            // Initialize rule lists
            this.Text = ApplicationName;
            LoadApplicationData();        
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblMain.Left = (this.ClientSize.Width - lblMain.Width) / 2;
            this.Text = ApplicationName;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try { SaveApplicationData(); }
            catch (Exception ex)
            {
                DialogResult response = MessageBox.Show("Application data not saved! Want to see the actual error?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (response == DialogResult.Yes)
                {
                    MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region Handle Button Clicks
        // --------- [ CONSOLIDATE TAB ] ---------
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmRuleGenerator RuleGenForm = new frmRuleGenerator();
            RuleGenForm.RuleType = Rule.RuleType.Consolidate;
            RuleGenForm.MainForm = this;
            RuleGenForm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int curRuleIndex = ConsolidationRuleList.FindIndex(x => x.Name == lstConsolidate.SelectedItem.ToString());

            frmRuleGenerator RuleGenForm = new frmRuleGenerator();
            RuleGenForm.RuleType = Rule.RuleType.Consolidate;
            RuleGenForm.MainForm = this;
            RuleGenForm.CurRuleIndex = curRuleIndex;
            RuleGenForm.CurRule = ConsolidationRuleList[curRuleIndex];
            RuleGenForm.EditingMode = true;
            RuleGenForm.Show();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string ruleName = lstConsolidate.SelectedItem.ToString();
            if (DialogResult.Yes == MessageBox.Show("Are you sure you wish to remove " + ruleName + "?", "Are you sure?", MessageBoxButtons.YesNo))
            {
                ConsolidationRuleList.RemoveAt(ConsolidationRuleList.FindIndex(x => x.Name == ruleName));
                UpdateConsolidateList();
            }
        }

        private void btnRunSelected_Click(object sender, EventArgs e)
        {
            ProcessFeedbackForm = new frmProcessFeedback();
            ProcessFeedbackForm.Show();
            ProcessFeedbackForm.WriteFeedback("Run Selected clicked");

            // grab our current rule 
            Rule selectedRule = ConsolidationRuleList.Find(x => x.Name == lstConsolidate.SelectedItem.ToString());

            RuleProcessor.ProcessRule(selectedRule, ProcessFeedbackForm);
        }

        private void btnRunAll_Click(object sender, EventArgs e)
        {
            ProcessFeedbackForm = new frmProcessFeedback();
            ProcessFeedbackForm.Show();
            ProcessFeedbackForm.WriteFeedback("Run All clicked");

            foreach (Rule r in ConsolidationRuleList)
            {
                RuleProcessor.ProcessRule(r, ProcessFeedbackForm);
            }
        }

        // --------- [ BACKUP TAB ] ---------
        private void btnAddBackup_Click(object sender, EventArgs e)
        {
            frmRuleGenerator RuleGenForm = new frmRuleGenerator();
            RuleGenForm.RuleType = Rule.RuleType.Backup;
            RuleGenForm.MainForm = this;
            RuleGenForm.Show();
        }

        private void btnEditBackup_Click(object sender, EventArgs e)
        {
            int curRuleIndex = BackupRuleList.FindIndex(x => x.Name == lstBackup.SelectedItem.ToString());

            frmRuleGenerator RuleGenForm = new frmRuleGenerator();
            RuleGenForm.RuleType = Rule.RuleType.Backup;
            RuleGenForm.MainForm = this;
            RuleGenForm.CurRuleIndex = curRuleIndex;
            RuleGenForm.CurRule = BackupRuleList[curRuleIndex];
            RuleGenForm.EditingMode = true;
            RuleGenForm.Show();
        }

        private void btnRemoveBackup_Click(object sender, EventArgs e)
        {
            string ruleName = lstBackup.SelectedItem.ToString();
            if (DialogResult.Yes == MessageBox.Show("Are you sure you wish to remove " + ruleName + "?", "Are you sure?", MessageBoxButtons.YesNo))
            {
                BackupRuleList.RemoveAt(BackupRuleList.FindIndex(x => x.Name == ruleName));
                UpdateBackupList();
            }
        }

        private void btnRunSelectedBackup_Click(object sender, EventArgs e)
        {
            ProcessFeedbackForm = new frmProcessFeedback();
            ProcessFeedbackForm.Show();
            ProcessFeedbackForm.WriteFeedback("Run Selected clicked");

            // grab our current rule 
            Rule selectedRule = BackupRuleList.Find(x => x.Name == lstBackup.SelectedItem.ToString());

            RuleProcessor.ProcessRule(selectedRule, ProcessFeedbackForm);
        }

        private void btnRunAllBackup_Click(object sender, EventArgs e)
        {
            ProcessFeedbackForm = new frmProcessFeedback();
            ProcessFeedbackForm.Show();
            ProcessFeedbackForm.WriteFeedback("Run All clicked");

            foreach (Rule r in BackupRuleList)
            {
                RuleProcessor.ProcessRule(r, ProcessFeedbackForm);
            }
        }

        // --------- [ MENU TOOLBAR ] ---------
        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            frmAbout aboutForm = new frmAbout();
            aboutForm.Show();
        }

        private void mnuBatchAll_Click(object sender, EventArgs e)
        {
            ProcessFeedbackForm = new frmProcessFeedback();
            ProcessFeedbackForm.Show();
            ProcessFeedbackForm.WriteFeedback("Create Batch File (all) selected");

            CreateBatchFile(BatchFileType.All);

            ProcessFeedbackForm.EnableBtnOk();
        }

        private void mnuBatchConsolidate_Click(object sender, EventArgs e)
        {
            ProcessFeedbackForm = new frmProcessFeedback();
            ProcessFeedbackForm.Show();
            ProcessFeedbackForm.WriteFeedback("Create Batch File (consolidate) selected");

            CreateBatchFile(BatchFileType.Consolidation);

            ProcessFeedbackForm.EnableBtnOk();
        }

        private void mnuBatchBackup_Click(object sender, EventArgs e)
        {
            ProcessFeedbackForm = new frmProcessFeedback();
            ProcessFeedbackForm.Show();
            ProcessFeedbackForm.WriteFeedback("Create Batch File (backup) selected");

            CreateBatchFile(BatchFileType.Backup);

            ProcessFeedbackForm.EnableBtnCancel();
            ProcessFeedbackForm.EnableBtnOk();
        }

        private void mnuYouTube_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=OCWj5xgu5Ng");
        }
        #endregion

        #region Handle Listbox Changes
        // --------- [ HANDLE RULES LIST ] ---------
        private void UpdateConsolidateList()
        {
            ConsolidationRuleList.Sort((x, y) => string.Compare(x.Name, y.Name));
            lstConsolidate.Items.Clear();
            foreach (Rule r in ConsolidationRuleList)
            {
                lstConsolidate.Items.Add(r.Name);
            }
            lstConsolidate_SelectedIndexChanged(null, null);
        }

        private void UpdateBackupList()
        {
            BackupRuleList.Sort((x, y) => string.Compare(x.Name, y.Name));
            lstBackup.Items.Clear();
            foreach (Rule r in BackupRuleList)
            {
                lstBackup.Items.Add(r.Name);
            }
            lstBackup_SelectedIndexChanged(null, null);
        }

        private void lstConsolidate_SelectedIndexChanged(object sender, EventArgs e)
        {
            // enable or disable buttons that interact with specific rules, depending on whether or not one is selected in the list
            if (lstConsolidate.SelectedIndex == -1)
                { btnEdit.Enabled = false; ; btnRemove.Enabled = false; btnRunSelected.Enabled = false; }
            else
                { btnEdit.Enabled = true; btnRemove.Enabled = true; btnRunSelected.Enabled = true; }
        }

        private void lstBackup_SelectedIndexChanged(object sender, EventArgs e)
        {
            // enable or disable buttons that interact with specific rules, depending on whether or not one is selected in the list
            if (lstBackup.SelectedIndex == -1)
                { btnEditBackup.Enabled = false; btnRemoveBackup.Enabled = false; btnRunSelectedBackup.Enabled = false; }
            else
                { btnEditBackup.Enabled = true; btnRemoveBackup.Enabled = true; btnRunSelectedBackup.Enabled = true; }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Add a rule to the consolidation list.
        /// </summary>
        /// <param name="newRule">Consolidation rule.</param>
        public void AddConsolidationRule(Rule newRule)
        {
            if (!ConsolidationRuleList.Exists(x => x.Name == newRule.Name))
            {
                ConsolidationRuleList.Add(newRule);
                UpdateConsolidateList();
            }
            else
                throw new Exception("A rule with this name already exists in the Consolidation list.");
        }

        /// <summary>
        /// Update a consolidation rule.
        /// </summary>
        /// <param name="updatedRule">The updated consolidation rule.</param>
        /// <param name="ruleIndex">The index of the rule in the consolidation listbox.</param>
        public void UpdateConsolidationRule(Rule updatedRule, int ruleIndex)
        {
            if (ConsolidationRuleList.Exists(x => x.Name == updatedRule.Name)
                && ConsolidationRuleList.FindIndex(x => x.Name == updatedRule.Name) != ruleIndex)
                throw new Exception("Another rule with this name already exists in the Consolidation list.");
            else
            {
                ConsolidationRuleList.RemoveAt(ruleIndex);
                ConsolidationRuleList.Add(updatedRule);
                UpdateConsolidateList();
            }                
        }

        /// <summary>
        /// Add a rule to the backup list.
        /// </summary>
        /// <param name="newRule">Backup rule.</param>
        public void AddBackupRule(Rule newRule)
        {
            if (!BackupRuleList.Exists(x => x.Name == newRule.Name))
            {
                BackupRuleList.Add(newRule);
                UpdateBackupList();
            }
            else
                throw new Exception("A rule with this name already exists in the Backup list.");
        }

        /// <summary>
        /// Update a backup rule.
        /// </summary>
        /// <param name="updatedRule">The updated backup rule.</param>
        /// <param name="ruleIndex">The index of the rule in the backup listbox.</param>
        public void UpdateBackupRule(Rule updatedRule, int ruleIndex)
        {
            if (BackupRuleList.Exists(x => x.Name == updatedRule.Name)
                && BackupRuleList.FindIndex(x => x.Name == updatedRule.Name) != ruleIndex)
                throw new Exception("Another rule with this name already exists in the Backup list.");
            else
            {
                BackupRuleList.RemoveAt(ruleIndex);
                BackupRuleList.Add(updatedRule);
                UpdateBackupList();
            }
        }
        #endregion

        #region Private Methods
        private void CreateBatchFile(BatchFileType bft)
        {
            // create file
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string batchFilePath = Path.Combine(desktopPath, "MuleScript" + DateTime.Now.ToString("_dd-MM-yy-HHmm") + ".bat" );
            if (!new FileInfo(batchFilePath).Exists) File.Create(batchFilePath).Close();

            // robocopy C:\Users\shoff\Desktop\Testor G:\Screenshots\Testee *.jpg /XC /XN /XO /MOV

            // create script to be written to the file
            string batchFile = "";
            // consolidation
            if (bft == BatchFileType.Backup || bft == BatchFileType.All)
            {
                batchFile += (batchFile != "" ? Environment.NewLine : "") + "REM <-- BACKUP/COPY SCREENSHOTS ELSEWHERE -->";
                foreach (Rule r in BackupRuleList)
                {
                    // ascertain which search pattern to use for the files
                    string searchPattern1 = "", searchPattern2 = "";
                    switch (r.TypeOfFile)
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

                    if (searchPattern1 != "") batchFile += Environment.NewLine + "robocopy \"" + r.Source + "\" \"" + r.Destination + "\" " + searchPattern1 + " /XC /XN /XO";
                    if (searchPattern2 != "") batchFile += Environment.NewLine + "robocopy \"" + r.Source + "\" \"" + r.Destination + "\" " + searchPattern2 + " /XC /XN /XO";
                }
            }
            // backup
            if (bft == BatchFileType.Consolidation || bft == BatchFileType.All)
            {
                batchFile += (batchFile != "" ? Environment.NewLine : "") + "REM <-- MOVE SCREENSHOTS FROM ALL OVER PC TO SINGLE FOLDER -->";
                foreach (Rule r in ConsolidationRuleList)
                {
                    // ascertain which search pattern to use for the files
                    string searchPattern1 = "", searchPattern2 = "";
                    switch (r.TypeOfFile)
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

                    if (searchPattern1 != "") batchFile += Environment.NewLine + "robocopy \"" + r.Source + "\" \"" + r.Destination + "\" " + searchPattern1 + " /XC /XN /XO /MOV";
                    if (searchPattern2 != "") batchFile += Environment.NewLine + "robocopy \"" + r.Source + "\" \"" + r.Destination + "\" " + searchPattern2 + " /XC /XN /XO /MOV";
                }
            }
            batchFile += (batchFile != "" ? Environment.NewLine : "") + "pause";

            // feedback
            ProcessFeedbackForm.WriteFeedback("Script developed, here's a preview:" + Environment.NewLine + batchFile);
            ProcessFeedbackForm.WriteFeedback("--Writting script to batch file--");

            // write script to batch file
            File.WriteAllText(batchFilePath, batchFile);

            Font boldFont = new Font(ProcessFeedbackForm.feedbackFormFont, FontStyle.Bold);
            ProcessFeedbackForm.WriteFeedback("Batch file written and placed on your desktop at " + batchFilePath, boldFont);
        }
        #endregion

        #region Save and Load App Data
        private void SaveApplicationData()
        {
            // get %appdata% path
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appFolder = Path.Combine(appDataPath, ApplicationName + "/");
            string consolidationXml = Path.Combine(appFolder, "ConsolidationRuleList.xml");
            string backupXml = Path.Combine(appFolder, "BackupRuleList.xml");

            Directory.CreateDirectory(appFolder);

            // write xmls to %appdata% folder
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(ConsolidationRuleList.GetType());
            System.Xml.XmlWriter consolidationWriter = System.Xml.XmlWriter.Create(consolidationXml);
            System.Xml.XmlWriter backupWriter = System.Xml.XmlWriter.Create(backupXml);
            x.Serialize(consolidationWriter, ConsolidationRuleList);
            x.Serialize(backupWriter, BackupRuleList);
            consolidationWriter.Close();
            backupWriter.Close();
        }

        private void LoadApplicationData()
        {
            ConsolidationRuleList = new List<Rule>();
            BackupRuleList = new List<Rule>();

            // get %appdata% path            
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appFolder = Path.Combine(appDataPath, ApplicationName + "/");
            string consolidationXml = Path.Combine(appFolder, "ConsolidationRuleList.xml");
            string backupXml = Path.Combine(appFolder, "BackupRuleList.xml");

            // load data from xml files
            if (File.Exists(consolidationXml) && File.Exists(backupXml))
            { 
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(ConsolidationRuleList.GetType());
                System.Xml.XmlReader consolidationReader = System.Xml.XmlReader.Create(consolidationXml);
                System.Xml.XmlReader backupReader = System.Xml.XmlReader.Create(backupXml);
                object consolidationRuleListXml = x.Deserialize(consolidationReader);
                object backupRuleListXml = x.Deserialize(backupReader);
                consolidationReader.Close();
                backupReader.Close();

                ConsolidationRuleList.AddRange(consolidationRuleListXml as List<Rule>);
                foreach (Rule r in ConsolidationRuleList) { r.TypeOfRule = Rule.RuleType.Consolidate; }
                BackupRuleList.AddRange(backupRuleListXml as List<Rule>);
                foreach (Rule r in BackupRuleList) { r.TypeOfRule = Rule.RuleType.Backup; }

                UpdateConsolidateList();
                UpdateBackupList();
            }
        }
        #endregion

        #region Remote Application Updating
        private void InstallUpdateSyncWithInfo()
        {
            UpdateCheckInfo info = null;
            
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                try
                {
                    info = ad.CheckForDetailedUpdate();

                }
                catch (DeploymentDownloadException dde)
                {
                    MessageBox.Show("The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " + dde.Message);
                    return;
                }
                catch (InvalidDeploymentException ide)
                {
                    MessageBox.Show("Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " + ide.Message);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " + ioe.Message);
                    return;
                }

                if (info.UpdateAvailable)
                {
                    Boolean doUpdate = true;

                    if (!info.IsUpdateRequired)
                    {
                        DialogResult dr = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel);
                        if (!(DialogResult.OK == dr))
                        {
                            doUpdate = false;
                        }
                    }
                    else
                    {
                        // Display a message that the app MUST reboot. Display the minimum required version.
                        MessageBox.Show("This application has detected a mandatory update from your current " +
                            "version to version " + info.MinimumRequiredVersion.ToString() +
                            ". The application will now install the update and restart.",
                            "Update Available", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    if (doUpdate)
                    {
                        try
                        {
                            ad.Update();
                            MessageBox.Show("The application has been upgraded, and will now restart.");
                            Application.Restart();
                        }
                        catch (DeploymentDownloadException dde)
                        {
                            MessageBox.Show("Cannot install the latest version of the application. \n\nPlease check your network connection, or try again later. Error: " + dde);
                            return;
                        }
                    }
                }
            }
        }
        #endregion
    }
}
