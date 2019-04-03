namespace MoveScreenshots
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabConsolidate = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRunSelected = new System.Windows.Forms.Button();
            this.btnRunAll = new System.Windows.Forms.Button();
            this.picConsolidate = new System.Windows.Forms.PictureBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstConsolidate = new System.Windows.Forms.ListBox();
            this.tabBackup = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRunSelectedBackup = new System.Windows.Forms.Button();
            this.btnRunAllBackup = new System.Windows.Forms.Button();
            this.picBackup = new System.Windows.Forms.PictureBox();
            this.btnEditBackup = new System.Windows.Forms.Button();
            this.btnRemoveBackup = new System.Windows.Forms.Button();
            this.btnAddBackup = new System.Windows.Forms.Button();
            this.lstBackup = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBatch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBatchAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBatchConsolidate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBatchBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instructionalVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuYouTube = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMain = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabConsolidate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picConsolidate)).BeginInit();
            this.tabBackup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackup)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabConsolidate);
            this.tabControl1.Controls.Add(this.tabBackup);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 84);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(625, 431);
            this.tabControl1.TabIndex = 0;
            // 
            // tabConsolidate
            // 
            this.tabConsolidate.Controls.Add(this.label1);
            this.tabConsolidate.Controls.Add(this.btnRunSelected);
            this.tabConsolidate.Controls.Add(this.btnRunAll);
            this.tabConsolidate.Controls.Add(this.picConsolidate);
            this.tabConsolidate.Controls.Add(this.btnEdit);
            this.tabConsolidate.Controls.Add(this.btnRemove);
            this.tabConsolidate.Controls.Add(this.btnAdd);
            this.tabConsolidate.Controls.Add(this.lstConsolidate);
            this.tabConsolidate.Location = new System.Drawing.Point(4, 25);
            this.tabConsolidate.Name = "tabConsolidate";
            this.tabConsolidate.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsolidate.Size = new System.Drawing.Size(617, 402);
            this.tabConsolidate.TabIndex = 0;
            this.tabConsolidate.Text = "Consolidate";
            this.tabConsolidate.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(306, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "(cut and paste)";
            // 
            // btnRunSelected
            // 
            this.btnRunSelected.Enabled = false;
            this.btnRunSelected.Location = new System.Drawing.Point(170, 362);
            this.btnRunSelected.Name = "btnRunSelected";
            this.btnRunSelected.Size = new System.Drawing.Size(108, 23);
            this.btnRunSelected.TabIndex = 6;
            this.btnRunSelected.Text = "Run Selected";
            this.btnRunSelected.UseVisualStyleBackColor = true;
            this.btnRunSelected.Click += new System.EventHandler(this.btnRunSelected_Click);
            // 
            // btnRunAll
            // 
            this.btnRunAll.Location = new System.Drawing.Point(284, 362);
            this.btnRunAll.Name = "btnRunAll";
            this.btnRunAll.Size = new System.Drawing.Size(108, 23);
            this.btnRunAll.TabIndex = 5;
            this.btnRunAll.Text = "Run All";
            this.btnRunAll.UseVisualStyleBackColor = true;
            this.btnRunAll.Click += new System.EventHandler(this.btnRunAll_Click);
            // 
            // picConsolidate
            // 
            this.picConsolidate.Image = ((System.Drawing.Image)(resources.GetObject("picConsolidate.Image")));
            this.picConsolidate.Location = new System.Drawing.Point(433, 45);
            this.picConsolidate.Name = "picConsolidate";
            this.picConsolidate.Size = new System.Drawing.Size(148, 148);
            this.picConsolidate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picConsolidate.TabIndex = 4;
            this.picConsolidate.TabStop = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(105, 16);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(186, 16);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(24, 16);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lstConsolidate
            // 
            this.lstConsolidate.FormattingEnabled = true;
            this.lstConsolidate.ItemHeight = 16;
            this.lstConsolidate.Location = new System.Drawing.Point(24, 45);
            this.lstConsolidate.Name = "lstConsolidate";
            this.lstConsolidate.Size = new System.Drawing.Size(368, 308);
            this.lstConsolidate.TabIndex = 0;
            this.lstConsolidate.SelectedIndexChanged += new System.EventHandler(this.lstConsolidate_SelectedIndexChanged);
            // 
            // tabBackup
            // 
            this.tabBackup.Controls.Add(this.label2);
            this.tabBackup.Controls.Add(this.btnRunSelectedBackup);
            this.tabBackup.Controls.Add(this.btnRunAllBackup);
            this.tabBackup.Controls.Add(this.picBackup);
            this.tabBackup.Controls.Add(this.btnEditBackup);
            this.tabBackup.Controls.Add(this.btnRemoveBackup);
            this.tabBackup.Controls.Add(this.btnAddBackup);
            this.tabBackup.Controls.Add(this.lstBackup);
            this.tabBackup.Location = new System.Drawing.Point(4, 25);
            this.tabBackup.Name = "tabBackup";
            this.tabBackup.Padding = new System.Windows.Forms.Padding(3);
            this.tabBackup.Size = new System.Drawing.Size(617, 402);
            this.tabBackup.TabIndex = 1;
            this.tabBackup.Text = "Backup";
            this.tabBackup.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(296, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "(copy and paste)";
            // 
            // btnRunSelectedBackup
            // 
            this.btnRunSelectedBackup.Enabled = false;
            this.btnRunSelectedBackup.Location = new System.Drawing.Point(170, 362);
            this.btnRunSelectedBackup.Name = "btnRunSelectedBackup";
            this.btnRunSelectedBackup.Size = new System.Drawing.Size(108, 23);
            this.btnRunSelectedBackup.TabIndex = 13;
            this.btnRunSelectedBackup.Text = "Run Selected";
            this.btnRunSelectedBackup.UseVisualStyleBackColor = true;
            this.btnRunSelectedBackup.Click += new System.EventHandler(this.btnRunSelectedBackup_Click);
            // 
            // btnRunAllBackup
            // 
            this.btnRunAllBackup.Location = new System.Drawing.Point(284, 362);
            this.btnRunAllBackup.Name = "btnRunAllBackup";
            this.btnRunAllBackup.Size = new System.Drawing.Size(108, 23);
            this.btnRunAllBackup.TabIndex = 12;
            this.btnRunAllBackup.Text = "Run All";
            this.btnRunAllBackup.UseVisualStyleBackColor = true;
            this.btnRunAllBackup.Click += new System.EventHandler(this.btnRunAllBackup_Click);
            // 
            // picBackup
            // 
            this.picBackup.Image = ((System.Drawing.Image)(resources.GetObject("picBackup.Image")));
            this.picBackup.Location = new System.Drawing.Point(433, 45);
            this.picBackup.Name = "picBackup";
            this.picBackup.Size = new System.Drawing.Size(148, 148);
            this.picBackup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBackup.TabIndex = 11;
            this.picBackup.TabStop = false;
            // 
            // btnEditBackup
            // 
            this.btnEditBackup.Enabled = false;
            this.btnEditBackup.Location = new System.Drawing.Point(105, 16);
            this.btnEditBackup.Name = "btnEditBackup";
            this.btnEditBackup.Size = new System.Drawing.Size(75, 23);
            this.btnEditBackup.TabIndex = 10;
            this.btnEditBackup.Text = "Edit";
            this.btnEditBackup.UseVisualStyleBackColor = true;
            this.btnEditBackup.Click += new System.EventHandler(this.btnEditBackup_Click);
            // 
            // btnRemoveBackup
            // 
            this.btnRemoveBackup.Enabled = false;
            this.btnRemoveBackup.Location = new System.Drawing.Point(186, 16);
            this.btnRemoveBackup.Name = "btnRemoveBackup";
            this.btnRemoveBackup.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveBackup.TabIndex = 9;
            this.btnRemoveBackup.Text = "Remove";
            this.btnRemoveBackup.UseVisualStyleBackColor = true;
            this.btnRemoveBackup.Click += new System.EventHandler(this.btnRemoveBackup_Click);
            // 
            // btnAddBackup
            // 
            this.btnAddBackup.Location = new System.Drawing.Point(24, 16);
            this.btnAddBackup.Name = "btnAddBackup";
            this.btnAddBackup.Size = new System.Drawing.Size(75, 23);
            this.btnAddBackup.TabIndex = 8;
            this.btnAddBackup.Text = "Add";
            this.btnAddBackup.UseVisualStyleBackColor = true;
            this.btnAddBackup.Click += new System.EventHandler(this.btnAddBackup_Click);
            // 
            // lstBackup
            // 
            this.lstBackup.FormattingEnabled = true;
            this.lstBackup.ItemHeight = 16;
            this.lstBackup.Location = new System.Drawing.Point(24, 45);
            this.lstBackup.Name = "lstBackup";
            this.lstBackup.Size = new System.Drawing.Size(368, 308);
            this.lstBackup.TabIndex = 7;
            this.lstBackup.SelectedIndexChanged += new System.EventHandler(this.lstBackup_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(649, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBatch,
            this.toolStripMenuItem1,
            this.mnuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuBatch
            // 
            this.mnuBatch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBatchAll,
            this.mnuBatchConsolidate,
            this.mnuBatchBackup});
            this.mnuBatch.Name = "mnuBatch";
            this.mnuBatch.Size = new System.Drawing.Size(162, 22);
            this.mnuBatch.Text = "Create &Batch File";
            // 
            // mnuBatchAll
            // 
            this.mnuBatchAll.Name = "mnuBatchAll";
            this.mnuBatchAll.Size = new System.Drawing.Size(186, 22);
            this.mnuBatchAll.Text = "Run &All";
            this.mnuBatchAll.Click += new System.EventHandler(this.mnuBatchAll_Click);
            // 
            // mnuBatchConsolidate
            // 
            this.mnuBatchConsolidate.Name = "mnuBatchConsolidate";
            this.mnuBatchConsolidate.Size = new System.Drawing.Size(186, 22);
            this.mnuBatchConsolidate.Text = "Run &Consolidate (All)";
            this.mnuBatchConsolidate.Click += new System.EventHandler(this.mnuBatchConsolidate_Click);
            // 
            // mnuBatchBackup
            // 
            this.mnuBatchBackup.Name = "mnuBatchBackup";
            this.mnuBatchBackup.Size = new System.Drawing.Size(186, 22);
            this.mnuBatchBackup.Text = "Run &Backup (All)";
            this.mnuBatchBackup.Click += new System.EventHandler(this.mnuBatchBackup_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(159, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(162, 22);
            this.mnuExit.Text = "E&xit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instructionalVideoToolStripMenuItem,
            this.mnuAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // instructionalVideoToolStripMenuItem
            // 
            this.instructionalVideoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuYouTube});
            this.instructionalVideoToolStripMenuItem.Name = "instructionalVideoToolStripMenuItem";
            this.instructionalVideoToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.instructionalVideoToolStripMenuItem.Text = "&Instructional Video";
            // 
            // mnuYouTube
            // 
            this.mnuYouTube.Name = "mnuYouTube";
            this.mnuYouTube.Size = new System.Drawing.Size(121, 22);
            this.mnuYouTube.Text = "&YouTube";
            this.mnuYouTube.Click += new System.EventHandler(this.mnuYouTube_Click);
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(173, 22);
            this.mnuAbout.Text = "&About";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // lblMain
            // 
            this.lblMain.AutoSize = true;
            this.lblMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMain.Location = new System.Drawing.Point(81, 39);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(471, 24);
            this.lblMain.TabIndex = 2;
            this.lblMain.Text = "Shoff\'s Screenshot Backup and Consolidate Utility";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 527);
            this.Controls.Add(this.lblMain);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Move Screenshots";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabConsolidate.ResumeLayout(false);
            this.tabConsolidate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picConsolidate)).EndInit();
            this.tabBackup.ResumeLayout(false);
            this.tabBackup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackup)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabConsolidate;
        private System.Windows.Forms.Button btnRunSelected;
        private System.Windows.Forms.Button btnRunAll;
        private System.Windows.Forms.PictureBox picConsolidate;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lstConsolidate;
        private System.Windows.Forms.TabPage tabBackup;
        private System.Windows.Forms.Button btnRunSelectedBackup;
        private System.Windows.Forms.Button btnRunAllBackup;
        private System.Windows.Forms.PictureBox picBackup;
        private System.Windows.Forms.Button btnEditBackup;
        private System.Windows.Forms.Button btnRemoveBackup;
        private System.Windows.Forms.Button btnAddBackup;
        private System.Windows.Forms.ListBox lstBackup;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instructionalVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuYouTube;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.Label lblMain;
        private System.Windows.Forms.ToolStripMenuItem mnuBatch;
        private System.Windows.Forms.ToolStripMenuItem mnuBatchAll;
        private System.Windows.Forms.ToolStripMenuItem mnuBatchConsolidate;
        private System.Windows.Forms.ToolStripMenuItem mnuBatchBackup;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

