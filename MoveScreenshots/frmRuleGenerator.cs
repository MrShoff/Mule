using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveScreenshots
{
    public partial class frmRuleGenerator : Form
    {
        private Rule.RuleType _ruletype;
        private frmMain _mainForm;
        private Boolean _editingMode = false;
        private Rule _curRule;
        private int _curRuleIndex;
        private Rule.FileType _filetype;

        public Rule.RuleType RuleType { set { _ruletype = value; } }
        public frmMain MainForm { set { _mainForm = value; } }
        public Boolean EditingMode { set { _editingMode = value; } }
        public Rule CurRule { set { _curRule = value; } }
        public int CurRuleIndex { set { _curRuleIndex = value; } }

        #region Initialization
        public frmRuleGenerator()
        {
            InitializeComponent();
        }

        private void frmRuleGenerator_Shown(object sender, EventArgs e)
        {
            if (_editingMode) SetInitialFormValues();
        }

        private void SetInitialFormValues()
        {
            txtName.Text = _curRule.Name;
            txtSource.Text = _curRule.Source;
            txtDestination.Text = _curRule.Destination;
            if (_curRule.TypeOfFile == Rule.FileType.AllFiles) chkAllFiles.Checked = true;
            if (_curRule.TypeOfFile == Rule.FileType.jpgAndPng) { chkPng.Checked = true; chkJpg.Checked = true; }
            if (_curRule.TypeOfFile == Rule.FileType.jpg) chkJpg.Checked = true;
            if (_curRule.TypeOfFile == Rule.FileType.png) chkPng.Checked = true;
        }
        #endregion

        #region Handle Button Clicks
        private void btnDone_Click(object sender, EventArgs e)
        {
            // set _filetype
            if (chkAllFiles.Checked) _filetype = Rule.FileType.AllFiles;
            if (chkJpg.Checked && chkPng.Checked) _filetype = Rule.FileType.jpgAndPng;
            else
            {
                if (chkJpg.Checked) _filetype = Rule.FileType.jpg;
                if (chkPng.Checked) _filetype = Rule.FileType.png;
            }            

            try
            {
                // write rule to list
                if (_ruletype == Rule.RuleType.Consolidate)
                {
                    if (_editingMode)
                        _mainForm.UpdateConsolidationRule(new Rule(_ruletype, txtSource.Text, txtDestination.Text, txtName.Text, _filetype), _curRuleIndex);
                    else
                        _mainForm.AddConsolidationRule((new Rule(_ruletype, txtSource.Text, txtDestination.Text, txtName.Text, _filetype)));
                    this.Close();
                }
                if (_ruletype == Rule.RuleType.Backup)
                {
                    if (_editingMode)
                        _mainForm.UpdateBackupRule(new Rule(_ruletype, txtSource.Text, txtDestination.Text, txtName.Text, _filetype), _curRuleIndex);
                    else
                        _mainForm.AddBackupRule((new Rule(_ruletype, txtSource.Text, txtDestination.Text, txtName.Text, _filetype)));
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearchSource_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtSource.Text;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK) txtSource.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnSearchDestination_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtDestination.Text;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK) txtDestination.Text = folderBrowserDialog1.SelectedPath;
        }
        #endregion

        #region Handle Textbox Events
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (isFormComplete()) btnDone.Enabled = true; else btnDone.Enabled = false;
        }

        private void txtSource_TextChanged(object sender, EventArgs e)
        {
            if (isFormComplete()) btnDone.Enabled = true; else btnDone.Enabled = false;
        }

        private void txtDestination_TextChanged(object sender, EventArgs e)
        {
            if (isFormComplete()) btnDone.Enabled = true; else btnDone.Enabled = false;
        }

        private Boolean isFormComplete()
        {
            return (txtName.Text != "" && txtSource.Text != "" && txtDestination.Text != "");
        }
        #endregion

        #region Handle Checkbox Events
        private void chkAllFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllFiles.Checked)
            {
                chkJpg.Checked = false;
                chkPng.Checked = false;
            }

            if (!(chkJpg.Checked || chkPng.Checked || chkAllFiles.Checked))
            {
                chkAllFiles.Checked = true;
            }
        }

        private void chkJpg_CheckedChanged(object sender, EventArgs e)
        {
            chkAllFiles.Checked = !(chkJpg.Checked || chkPng.Checked);
        }

        private void chkPng_CheckedChanged(object sender, EventArgs e)
        {
            chkAllFiles.Checked = !(chkJpg.Checked || chkPng.Checked);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Display a message in red at the top of frmRuleGenerator.
        /// </summary>
        /// <param name="v">Error message to be displayed.</param>
        private void DisplayError(string v)
        {
            lblNameError.Text = v;
            lblNameError.Visible = true;
        }

        /// <summary>
        /// Set a the FileType property for a Rule.
        /// </summary>
        private void SetFileType()
        {
            if (chkAllFiles.Checked) { _filetype = Rule.FileType.AllFiles; return; }
            if (chkPng.Checked && chkJpg.Checked) { _filetype = Rule.FileType.jpgAndPng; return; }
            if (chkPng.Checked) { _filetype = Rule.FileType.png; return; }
            if (chkJpg.Checked) { _filetype = Rule.FileType.jpg; return; }
        }
        #endregion
    }
}
