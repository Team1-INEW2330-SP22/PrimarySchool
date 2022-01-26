
namespace PrimarySchool
{
    partial class frmHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHome));
            this.mnuMenu = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileLogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTeacher = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTeacherGradebook = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTeacherAttendance = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTeacherSeatingChart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOfficer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOfficerTeachers = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOfficerStudents = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOfficerCourses = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdminUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpInstructions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMenu = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pbxSchool = new System.Windows.Forms.PictureBox();
            this.mnuMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSchool)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMenu
            // 
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuTeacher,
            this.mnuOfficer,
            this.mnuAdmin,
            this.mnuHelp});
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.Size = new System.Drawing.Size(534, 24);
            this.mnuMenu.TabIndex = 0;
            this.mnuMenu.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileLogOut,
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuFileLogOut
            // 
            this.mnuFileLogOut.Name = "mnuFileLogOut";
            this.mnuFileLogOut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.mnuFileLogOut.Size = new System.Drawing.Size(157, 22);
            this.mnuFileLogOut.Text = "&Log Out";
            this.mnuFileLogOut.Click += new System.EventHandler(this.mnuFileLogOut_Click);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuFileExit.Size = new System.Drawing.Size(157, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // mnuTeacher
            // 
            this.mnuTeacher.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTeacherGradebook,
            this.mnuTeacherAttendance,
            this.mnuTeacherSeatingChart});
            this.mnuTeacher.Name = "mnuTeacher";
            this.mnuTeacher.Size = new System.Drawing.Size(59, 20);
            this.mnuTeacher.Text = "&Teacher";
            // 
            // mnuTeacherGradebook
            // 
            this.mnuTeacherGradebook.Name = "mnuTeacherGradebook";
            this.mnuTeacherGradebook.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.mnuTeacherGradebook.Size = new System.Drawing.Size(185, 22);
            this.mnuTeacherGradebook.Text = "&Gradebook";
            this.mnuTeacherGradebook.Click += new System.EventHandler(this.mnuTeacherGradebook_Click);
            // 
            // mnuTeacherAttendance
            // 
            this.mnuTeacherAttendance.Name = "mnuTeacherAttendance";
            this.mnuTeacherAttendance.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mnuTeacherAttendance.Size = new System.Drawing.Size(185, 22);
            this.mnuTeacherAttendance.Text = "&Attendance";
            this.mnuTeacherAttendance.Click += new System.EventHandler(this.mnuTeacherAttendance_Click);
            // 
            // mnuTeacherSeatingChart
            // 
            this.mnuTeacherSeatingChart.Name = "mnuTeacherSeatingChart";
            this.mnuTeacherSeatingChart.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuTeacherSeatingChart.Size = new System.Drawing.Size(185, 22);
            this.mnuTeacherSeatingChart.Text = "&Seating Chart";
            this.mnuTeacherSeatingChart.Click += new System.EventHandler(this.mnuTeacherSeatingChart_Click);
            // 
            // mnuOfficer
            // 
            this.mnuOfficer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOfficerTeachers,
            this.mnuOfficerStudents,
            this.mnuOfficerCourses});
            this.mnuOfficer.Name = "mnuOfficer";
            this.mnuOfficer.Size = new System.Drawing.Size(111, 20);
            this.mnuOfficer.Text = "&Academic Officer";
            // 
            // mnuOfficerTeachers
            // 
            this.mnuOfficerTeachers.Name = "mnuOfficerTeachers";
            this.mnuOfficerTeachers.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.mnuOfficerTeachers.Size = new System.Drawing.Size(192, 22);
            this.mnuOfficerTeachers.Text = "&Teachers";
            this.mnuOfficerTeachers.Click += new System.EventHandler(this.mnuOfficerTeachers_Click);
            // 
            // mnuOfficerStudents
            // 
            this.mnuOfficerStudents.Name = "mnuOfficerStudents";
            this.mnuOfficerStudents.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.mnuOfficerStudents.Size = new System.Drawing.Size(192, 22);
            this.mnuOfficerStudents.Text = "&Students";
            this.mnuOfficerStudents.Click += new System.EventHandler(this.mnuOfficerStudents_Click);
            // 
            // mnuOfficerCourses
            // 
            this.mnuOfficerCourses.Name = "mnuOfficerCourses";
            this.mnuOfficerCourses.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuOfficerCourses.Size = new System.Drawing.Size(192, 22);
            this.mnuOfficerCourses.Text = "&Courses";
            this.mnuOfficerCourses.Click += new System.EventHandler(this.mnuOfficerCourses_Click);
            // 
            // mnuAdmin
            // 
            this.mnuAdmin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAdminUsers});
            this.mnuAdmin.Name = "mnuAdmin";
            this.mnuAdmin.Size = new System.Drawing.Size(92, 20);
            this.mnuAdmin.Text = "A&dministrator";
            // 
            // mnuAdminUsers
            // 
            this.mnuAdminUsers.Name = "mnuAdminUsers";
            this.mnuAdminUsers.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.mnuAdminUsers.Size = new System.Drawing.Size(144, 22);
            this.mnuAdminUsers.Text = "&Users";
            this.mnuAdminUsers.Click += new System.EventHandler(this.mnuAdminUsers_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpInstructions,
            this.mnuHelpAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "&Help";
            // 
            // mnuHelpInstructions
            // 
            this.mnuHelpInstructions.Name = "mnuHelpInstructions";
            this.mnuHelpInstructions.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.mnuHelpInstructions.Size = new System.Drawing.Size(181, 22);
            this.mnuHelpInstructions.Text = "&Instructions";
            // 
            // mnuHelpAbout
            // 
            this.mnuHelpAbout.Name = "mnuHelpAbout";
            this.mnuHelpAbout.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.mnuHelpAbout.Size = new System.Drawing.Size(181, 22);
            this.mnuHelpAbout.Text = "&About";
            this.mnuHelpAbout.Click += new System.EventHandler(this.mnuHelpAbout_Click);
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(180)))), ((int)(((byte)(210)))));
            this.lblMenu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(9)))), ((int)(((byte)(11)))));
            this.lblMenu.Location = new System.Drawing.Point(102, 375);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(331, 17);
            this.lblMenu.TabIndex = 1;
            this.lblMenu.Text = "Use the menu up top to navigate through the program.";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(147, 310);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(238, 65);
            this.lblWelcome.TabIndex = 2;
            this.lblWelcome.Text = "Welcome!";
            // 
            // pbxSchool
            // 
            this.pbxSchool.Image = ((System.Drawing.Image)(resources.GetObject("pbxSchool.Image")));
            this.pbxSchool.Location = new System.Drawing.Point(147, 32);
            this.pbxSchool.Name = "pbxSchool";
            this.pbxSchool.Size = new System.Drawing.Size(238, 287);
            this.pbxSchool.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxSchool.TabIndex = 3;
            this.pbxSchool.TabStop = false;
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(180)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(534, 406);
            this.Controls.Add(this.pbxSchool);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblMenu);
            this.Controls.Add(this.mnuMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(9)))), ((int)(((byte)(11)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMenu;
            this.MaximizeBox = false;
            this.Name = "frmHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Primary School - Home";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHome_FormClosing);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSchool)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileLogOut;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem mnuTeacher;
        private System.Windows.Forms.ToolStripMenuItem mnuOfficer;
        private System.Windows.Forms.ToolStripMenuItem mnuAdmin;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuTeacherGradebook;
        private System.Windows.Forms.ToolStripMenuItem mnuTeacherAttendance;
        private System.Windows.Forms.ToolStripMenuItem mnuTeacherSeatingChart;
        private System.Windows.Forms.ToolStripMenuItem mnuOfficerTeachers;
        private System.Windows.Forms.ToolStripMenuItem mnuOfficerStudents;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpInstructions;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuAdminUsers;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.PictureBox pbxSchool;
        private System.Windows.Forms.ToolStripMenuItem mnuOfficerCourses;
    }
}