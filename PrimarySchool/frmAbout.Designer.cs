
namespace PrimarySchool
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.mnuMenu = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpInstructions = new System.Windows.Forms.ToolStripMenuItem();
            this.lblProgramName = new System.Windows.Forms.Label();
            this.lblVersionNumber = new System.Windows.Forms.Label();
            this.lblProgramInfo = new System.Windows.Forms.Label();
            this.gbxDevelopers = new System.Windows.Forms.GroupBox();
            this.lblHicks = new System.Windows.Forms.Label();
            this.lbCancino = new System.Windows.Forms.Label();
            this.lblAnderson = new System.Windows.Forms.Label();
            this.pbxHicks = new System.Windows.Forms.PictureBox();
            this.pbxAnderson = new System.Windows.Forms.PictureBox();
            this.pbxCancino = new System.Windows.Forms.PictureBox();
            this.btnReturnToHome = new System.Windows.Forms.Button();
            this.mnuMenu.SuspendLayout();
            this.gbxDevelopers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHicks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAnderson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCancino)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMenu
            // 
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuHelp});
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.Size = new System.Drawing.Size(514, 24);
            this.mnuMenu.TabIndex = 116;
            this.mnuMenu.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileClose});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuFileClose
            // 
            this.mnuFileClose.Name = "mnuFileClose";
            this.mnuFileClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuFileClose.Size = new System.Drawing.Size(144, 22);
            this.mnuFileClose.Text = "&Close";
            this.mnuFileClose.Click += new System.EventHandler(this.mnuFileClose_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpInstructions});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "&Help";
            // 
            // mnuHelpInstructions
            // 
            this.mnuHelpInstructions.Name = "mnuHelpInstructions";
            this.mnuHelpInstructions.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.mnuHelpInstructions.Size = new System.Drawing.Size(173, 22);
            this.mnuHelpInstructions.Text = "&Instructions";
            // 
            // lblProgramName
            // 
            this.lblProgramName.AutoSize = true;
            this.lblProgramName.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgramName.Location = new System.Drawing.Point(141, 27);
            this.lblProgramName.Name = "lblProgramName";
            this.lblProgramName.Size = new System.Drawing.Size(232, 45);
            this.lblProgramName.TabIndex = 117;
            this.lblProgramName.Text = "Primary School";
            // 
            // lblVersionNumber
            // 
            this.lblVersionNumber.AutoSize = true;
            this.lblVersionNumber.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersionNumber.Location = new System.Drawing.Point(213, 75);
            this.lblVersionNumber.Name = "lblVersionNumber";
            this.lblVersionNumber.Size = new System.Drawing.Size(88, 20);
            this.lblVersionNumber.TabIndex = 118;
            this.lblVersionNumber.Text = "Version 1.00";
            // 
            // lblProgramInfo
            // 
            this.lblProgramInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(190)))));
            this.lblProgramInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProgramInfo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgramInfo.Location = new System.Drawing.Point(12, 102);
            this.lblProgramInfo.Name = "lblProgramInfo";
            this.lblProgramInfo.Size = new System.Drawing.Size(237, 266);
            this.lblProgramInfo.TabIndex = 119;
            this.lblProgramInfo.Text = "This is Version 1.00 of the Primary School application. It was developed by Team " +
    "1 of 22/SP INEW-2330-7Z1. This version was released on 4/27/2022.";
            // 
            // gbxDevelopers
            // 
            this.gbxDevelopers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(190)))));
            this.gbxDevelopers.Controls.Add(this.lblHicks);
            this.gbxDevelopers.Controls.Add(this.lbCancino);
            this.gbxDevelopers.Controls.Add(this.lblAnderson);
            this.gbxDevelopers.Controls.Add(this.pbxHicks);
            this.gbxDevelopers.Controls.Add(this.pbxAnderson);
            this.gbxDevelopers.Controls.Add(this.pbxCancino);
            this.gbxDevelopers.Location = new System.Drawing.Point(265, 102);
            this.gbxDevelopers.Name = "gbxDevelopers";
            this.gbxDevelopers.Size = new System.Drawing.Size(237, 266);
            this.gbxDevelopers.TabIndex = 120;
            this.gbxDevelopers.TabStop = false;
            this.gbxDevelopers.Text = "Developers";
            // 
            // lblHicks
            // 
            this.lblHicks.AutoSize = true;
            this.lblHicks.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHicks.Location = new System.Drawing.Point(82, 186);
            this.lblHicks.Name = "lblHicks";
            this.lblHicks.Size = new System.Drawing.Size(80, 20);
            this.lblHicks.TabIndex = 133;
            this.lblHicks.Text = "Ryan Hicks";
            // 
            // lbCancino
            // 
            this.lbCancino.AutoSize = true;
            this.lbCancino.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCancino.Location = new System.Drawing.Point(82, 107);
            this.lbCancino.Name = "lbCancino";
            this.lbCancino.Size = new System.Drawing.Size(143, 20);
            this.lbCancino.TabIndex = 132;
            this.lbCancino.Text = "Maximillian Cancino";
            // 
            // lblAnderson
            // 
            this.lblAnderson.AutoSize = true;
            this.lblAnderson.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnderson.Location = new System.Drawing.Point(82, 28);
            this.lblAnderson.Name = "lblAnderson";
            this.lblAnderson.Size = new System.Drawing.Size(107, 20);
            this.lblAnderson.TabIndex = 131;
            this.lblAnderson.Text = "Tyler Anderson";
            // 
            // pbxHicks
            // 
            this.pbxHicks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.pbxHicks.Image = ((System.Drawing.Image)(resources.GetObject("pbxHicks.Image")));
            this.pbxHicks.Location = new System.Drawing.Point(6, 186);
            this.pbxHicks.Name = "pbxHicks";
            this.pbxHicks.Size = new System.Drawing.Size(70, 70);
            this.pbxHicks.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxHicks.TabIndex = 129;
            this.pbxHicks.TabStop = false;
            // 
            // pbxAnderson
            // 
            this.pbxAnderson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.pbxAnderson.Image = ((System.Drawing.Image)(resources.GetObject("pbxAnderson.Image")));
            this.pbxAnderson.Location = new System.Drawing.Point(6, 28);
            this.pbxAnderson.Name = "pbxAnderson";
            this.pbxAnderson.Size = new System.Drawing.Size(70, 70);
            this.pbxAnderson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxAnderson.TabIndex = 128;
            this.pbxAnderson.TabStop = false;
            // 
            // pbxCancino
            // 
            this.pbxCancino.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.pbxCancino.Image = ((System.Drawing.Image)(resources.GetObject("pbxCancino.Image")));
            this.pbxCancino.Location = new System.Drawing.Point(6, 107);
            this.pbxCancino.Name = "pbxCancino";
            this.pbxCancino.Size = new System.Drawing.Size(70, 70);
            this.pbxCancino.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxCancino.TabIndex = 127;
            this.pbxCancino.TabStop = false;
            // 
            // btnReturnToHome
            // 
            this.btnReturnToHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.btnReturnToHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnToHome.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnToHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnReturnToHome.Location = new System.Drawing.Point(192, 377);
            this.btnReturnToHome.Name = "btnReturnToHome";
            this.btnReturnToHome.Size = new System.Drawing.Size(130, 30);
            this.btnReturnToHome.TabIndex = 121;
            this.btnReturnToHome.Text = "&Return to Home";
            this.btnReturnToHome.UseVisualStyleBackColor = false;
            this.btnReturnToHome.Click += new System.EventHandler(this.btnReturnToHome_Click);
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(180)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(514, 416);
            this.Controls.Add(this.btnReturnToHome);
            this.Controls.Add(this.gbxDevelopers);
            this.Controls.Add(this.lblProgramInfo);
            this.Controls.Add(this.lblVersionNumber);
            this.Controls.Add(this.lblProgramName);
            this.Controls.Add(this.mnuMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(9)))), ((int)(((byte)(11)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Primary School - About";
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.gbxDevelopers.ResumeLayout(false);
            this.gbxDevelopers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHicks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAnderson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCancino)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileClose;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpInstructions;
        private System.Windows.Forms.Label lblProgramName;
        private System.Windows.Forms.Label lblVersionNumber;
        private System.Windows.Forms.Label lblProgramInfo;
        private System.Windows.Forms.GroupBox gbxDevelopers;
        private System.Windows.Forms.Label lblHicks;
        private System.Windows.Forms.Label lbCancino;
        private System.Windows.Forms.Label lblAnderson;
        private System.Windows.Forms.PictureBox pbxHicks;
        private System.Windows.Forms.PictureBox pbxAnderson;
        private System.Windows.Forms.PictureBox pbxCancino;
        private System.Windows.Forms.Button btnReturnToHome;
    }
}