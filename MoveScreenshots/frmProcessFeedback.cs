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
    public partial class frmProcessFeedback : Form
    {
        public Font feedbackFormFont { get; }

        public frmProcessFeedback()
        {
            InitializeComponent();
            feedbackFormFont = rtbFeedbackLog.Font;
        }
        
        public void WriteFeedback(string s)
        {
            CheckForIllegalCrossThreadCalls = false;

            string[] curTime = DateTime.Now.GetDateTimeFormats();
            /*
                (DateTime.Now.TimeOfDay.Hours.ToString().Length == 2 ? DateTime.Now.TimeOfDay.Hours.ToString() : "0" + DateTime.Now.TimeOfDay.Hours.ToString()) + ":" + 
                (DateTime.Now.TimeOfDay.Minutes.ToString().Length == 2 ? DateTime.Now.TimeOfDay.Minutes.ToString() : "0" + DateTime.Now.TimeOfDay.Minutes.ToString()) + ":" + 
                (DateTime.Now.TimeOfDay.Seconds.ToString().Length == 2 ? DateTime.Now.TimeOfDay.Seconds.ToString() : "0" + DateTime.Now.TimeOfDay.Seconds.ToString());
            */            
            if (rtbFeedbackLog.Text != "") rtbFeedbackLog.AppendText(Environment.NewLine + "[" + curTime[120] + "] " + s); else rtbFeedbackLog.AppendText("[" + curTime[120] + "] " + s);
        }

        public void WriteFeedback(string s, Font font)
        {
            CheckForIllegalCrossThreadCalls = false;

            string[] curTime = DateTime.Now.GetDateTimeFormats();

            int startIndex = rtbFeedbackLog.Text.Length;
            if (rtbFeedbackLog.Text != "") rtbFeedbackLog.AppendText(Environment.NewLine + "[" + curTime[120] + "] " + s); else rtbFeedbackLog.AppendText("[" + curTime[120] + "] " + s);
            rtbFeedbackLog.Select(startIndex, rtbFeedbackLog.Text.Length - startIndex);
            rtbFeedbackLog.SelectionFont = font;
            rtbFeedbackLog.Select(0, 0);
        }

        public void EnableBtnOk()
        {
            btnOk.Enabled = true;
        }

        public void EnableBtnCancel()
        {
            btnCancel.Enabled = true;
        }

        public void DisableBtnOk()
        {
            btnOk.Enabled = false;
        }

        public void DisableBtnCancel()
        {
            btnCancel.Enabled = false;
        }

        public void SetProgress(int progressPercentage)
        {
            barProgress.Value = progressPercentage;
        }

        public void SetProgress(int progressPercentage, string progressLabel)
        {
            barProgress.Value = progressPercentage;
            lblProgress.Text = progressLabel;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            RuleProcessor.CancelProcessing();
        }
        
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
