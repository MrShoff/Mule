namespace MoveScreenshots
{
    partial class frmRuleGenerator
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.btnSearchSource = new System.Windows.Forms.Button();
            this.btnSearchDestination = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkJpg = new System.Windows.Forms.CheckBox();
            this.chkPng = new System.Windows.Forms.CheckBox();
            this.chkAllFiles = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblNameError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtName.Location = new System.Drawing.Point(24, 35);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(467, 22);
            this.txtName.TabIndex = 0;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Source";
            // 
            // txtSource
            // 
            this.txtSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSource.Location = new System.Drawing.Point(24, 86);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(467, 22);
            this.txtSource.TabIndex = 2;
            this.txtSource.TextChanged += new System.EventHandler(this.txtSource_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Desintation";
            // 
            // txtDestination
            // 
            this.txtDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestination.Location = new System.Drawing.Point(24, 144);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(467, 22);
            this.txtDestination.TabIndex = 6;
            this.txtDestination.TextChanged += new System.EventHandler(this.txtDestination_TextChanged);
            // 
            // btnSearchSource
            // 
            this.btnSearchSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchSource.Location = new System.Drawing.Point(497, 86);
            this.btnSearchSource.Name = "btnSearchSource";
            this.btnSearchSource.Size = new System.Drawing.Size(75, 23);
            this.btnSearchSource.TabIndex = 8;
            this.btnSearchSource.Text = "Search";
            this.btnSearchSource.UseVisualStyleBackColor = true;
            this.btnSearchSource.Click += new System.EventHandler(this.btnSearchSource_Click);
            // 
            // btnSearchDestination
            // 
            this.btnSearchDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchDestination.Location = new System.Drawing.Point(497, 144);
            this.btnSearchDestination.Name = "btnSearchDestination";
            this.btnSearchDestination.Size = new System.Drawing.Size(75, 23);
            this.btnSearchDestination.TabIndex = 9;
            this.btnSearchDestination.Text = "Search";
            this.btnSearchDestination.UseVisualStyleBackColor = true;
            this.btnSearchDestination.Click += new System.EventHandler(this.btnSearchDestination_Click);
            // 
            // btnDone
            // 
            this.btnDone.Enabled = false;
            this.btnDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.Location = new System.Drawing.Point(510, 201);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 10;
            this.btnDone.Text = "&Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(429, 201);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkJpg
            // 
            this.chkJpg.AutoSize = true;
            this.chkJpg.Location = new System.Drawing.Point(333, 114);
            this.chkJpg.Name = "chkJpg";
            this.chkJpg.Size = new System.Drawing.Size(40, 17);
            this.chkJpg.TabIndex = 12;
            this.chkJpg.Text = "jpg";
            this.chkJpg.UseVisualStyleBackColor = true;
            this.chkJpg.CheckedChanged += new System.EventHandler(this.chkJpg_CheckedChanged);
            // 
            // chkPng
            // 
            this.chkPng.AutoSize = true;
            this.chkPng.Location = new System.Drawing.Point(379, 114);
            this.chkPng.Name = "chkPng";
            this.chkPng.Size = new System.Drawing.Size(44, 17);
            this.chkPng.TabIndex = 13;
            this.chkPng.Text = "png";
            this.chkPng.UseVisualStyleBackColor = true;
            this.chkPng.CheckedChanged += new System.EventHandler(this.chkPng_CheckedChanged);
            // 
            // chkAllFiles
            // 
            this.chkAllFiles.AutoSize = true;
            this.chkAllFiles.Checked = true;
            this.chkAllFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllFiles.Location = new System.Drawing.Point(429, 114);
            this.chkAllFiles.Name = "chkAllFiles";
            this.chkAllFiles.Size = new System.Drawing.Size(61, 17);
            this.chkAllFiles.TabIndex = 14;
            this.chkAllFiles.Text = "All Files";
            this.chkAllFiles.UseVisualStyleBackColor = true;
            this.chkAllFiles.CheckedChanged += new System.EventHandler(this.chkAllFiles_CheckedChanged);
            // 
            // lblNameError
            // 
            this.lblNameError.AutoSize = true;
            this.lblNameError.ForeColor = System.Drawing.Color.Red;
            this.lblNameError.Location = new System.Drawing.Point(72, 18);
            this.lblNameError.Name = "lblNameError";
            this.lblNameError.Size = new System.Drawing.Size(67, 13);
            this.lblNameError.TabIndex = 15;
            this.lblNameError.Text = "lblNameError";
            this.lblNameError.Visible = false;
            // 
            // frmRuleGenerator
            // 
            this.AcceptButton = this.btnDone;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(597, 236);
            this.Controls.Add(this.lblNameError);
            this.Controls.Add(this.chkAllFiles);
            this.Controls.Add(this.chkPng);
            this.Controls.Add(this.chkJpg);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnSearchDestination);
            this.Controls.Add(this.btnSearchSource);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRuleGenerator";
            this.Text = "Rule Generator";
            this.Shown += new System.EventHandler(this.frmRuleGenerator_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Button btnSearchSource;
        private System.Windows.Forms.Button btnSearchDestination;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkJpg;
        private System.Windows.Forms.CheckBox chkPng;
        private System.Windows.Forms.CheckBox chkAllFiles;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblNameError;
    }
}