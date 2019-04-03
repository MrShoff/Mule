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
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            lblApplicationName.Text = frmMain.ApplicationName;
            lblVersion.Text = "Version: " + Application.ProductVersion;

            // center all labels
            lblApplicationName.Left = (this.ClientSize.Width - lblApplicationName.Width) / 2;
            lblSubtitle.Left = (this.ClientSize.Width - lblSubtitle.Width) / 2;
            lblCredit.Left = (this.ClientSize.Width - lblCredit.Width) / 2;

        }
    }
}
