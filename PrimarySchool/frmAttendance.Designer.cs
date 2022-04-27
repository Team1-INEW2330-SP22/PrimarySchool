
namespace PrimarySchool
{
    partial class frmAttendance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAttendance));
            this.mnuMenu = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFilePrint = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditClear = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditReset = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpInstructions = new System.Windows.Forms.ToolStripMenuItem();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.dgvAttendance = new System.Windows.Forms.DataGridView();
            this.gbxAttendance = new System.Windows.Forms.GroupBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.cbxDate = new System.Windows.Forms.ComboBox();
            this.lblRoom = new System.Windows.Forms.Label();
            this.lblSelectDate = new System.Windows.Forms.Label();
            this.lblInstructor = new System.Windows.Forms.Label();
            this.lblCourseName = new System.Windows.Forms.Label();
            this.cbxCourses = new System.Windows.Forms.ComboBox();
            this.lblSelectCourse = new System.Windows.Forms.Label();
            this.helpme = new System.Windows.Forms.HelpProvider();
            this.mnuMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).BeginInit();
            this.gbxAttendance.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMenu
            // 
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuHelp});
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.Size = new System.Drawing.Size(1011, 24);
            this.mnuMenu.TabIndex = 1;
            this.mnuMenu.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileSave,
            this.mnuFilePrint,
            this.mnuFileClose});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSave.Size = new System.Drawing.Size(144, 22);
            this.mnuFileSave.Text = "&Save";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // mnuFilePrint
            // 
            this.mnuFilePrint.Name = "mnuFilePrint";
            this.mnuFilePrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.mnuFilePrint.Size = new System.Drawing.Size(144, 22);
            this.mnuFilePrint.Text = "&Print";
            this.mnuFilePrint.Click += new System.EventHandler(this.mnuFilePrint_Click);
            // 
            // mnuFileClose
            // 
            this.mnuFileClose.Name = "mnuFileClose";
            this.mnuFileClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuFileClose.Size = new System.Drawing.Size(144, 22);
            this.mnuFileClose.Text = "&Close";
            this.mnuFileClose.Click += new System.EventHandler(this.mnuFileClose_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditClear,
            this.mnuEditReset});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(39, 20);
            this.mnuEdit.Text = "&Edit";
            // 
            // mnuEditClear
            // 
            this.mnuEditClear.Name = "mnuEditClear";
            this.mnuEditClear.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.mnuEditClear.Size = new System.Drawing.Size(143, 22);
            this.mnuEditClear.Text = "&Clear";
            this.mnuEditClear.Click += new System.EventHandler(this.mnuEditClear_Click);
            // 
            // mnuEditReset
            // 
            this.mnuEditReset.Name = "mnuEditReset";
            this.mnuEditReset.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.mnuEditReset.Size = new System.Drawing.Size(143, 22);
            this.mnuEditReset.Text = "&Reset";
            this.mnuEditReset.Click += new System.EventHandler(this.mnuEditReset_Click);
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
            this.mnuHelpInstructions.Click += new System.EventHandler(this.mnuHelpInstructions_Click);
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructions.Location = new System.Drawing.Point(811, 57);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(187, 85);
            this.lblInstructions.TabIndex = 3;
            this.lblInstructions.Text = "Use the table below to record \r\nstudent attendance. The menu \r\nup top contains mo" +
    "re operati-\r\nons. For detailed help, click In-\r\nstructions under the Help tab.";
            // 
            // dgvAttendance
            // 
            this.dgvAttendance.AllowUserToAddRows = false;
            this.dgvAttendance.AllowUserToDeleteRows = false;
            this.dgvAttendance.AllowUserToResizeRows = false;
            this.dgvAttendance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAttendance.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAttendance.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(190)))));
            this.dgvAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendance.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dgvAttendance.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(190)))));
            this.dgvAttendance.Location = new System.Drawing.Point(12, 148);
            this.dgvAttendance.Name = "dgvAttendance";
            this.dgvAttendance.Size = new System.Drawing.Size(986, 412);
            this.dgvAttendance.TabIndex = 0;
            this.dgvAttendance.TabStop = false;
            this.dgvAttendance.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAttendance_CellValueChanged);
            this.dgvAttendance.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvAttendance_DataError);
            // 
            // gbxAttendance
            // 
            this.gbxAttendance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(190)))));
            this.gbxAttendance.Controls.Add(this.lblDate);
            this.gbxAttendance.Controls.Add(this.cbxDate);
            this.gbxAttendance.Controls.Add(this.lblRoom);
            this.gbxAttendance.Controls.Add(this.lblSelectDate);
            this.gbxAttendance.Controls.Add(this.lblInstructor);
            this.gbxAttendance.Controls.Add(this.lblCourseName);
            this.gbxAttendance.Controls.Add(this.cbxCourses);
            this.gbxAttendance.Controls.Add(this.lblSelectCourse);
            this.gbxAttendance.Location = new System.Drawing.Point(12, 36);
            this.gbxAttendance.Name = "gbxAttendance";
            this.gbxAttendance.Size = new System.Drawing.Size(793, 106);
            this.gbxAttendance.TabIndex = 2;
            this.gbxAttendance.TabStop = false;
            this.gbxAttendance.Text = "Attendance";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(496, 81);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(43, 17);
            this.lblDate.TabIndex = 7;
            this.lblDate.Text = "[Date]";
            // 
            // cbxDate
            // 
            this.cbxDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.cbxDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.cbxDate.FormattingEnabled = true;
            this.cbxDate.Location = new System.Drawing.Point(285, 49);
            this.cbxDate.Name = "cbxDate";
            this.cbxDate.Size = new System.Drawing.Size(196, 29);
            this.cbxDate.TabIndex = 1;
            this.cbxDate.SelectedIndexChanged += new System.EventHandler(this.cbxDate_SelectedIndexChanged);
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoom.Location = new System.Drawing.Point(496, 60);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(51, 17);
            this.lblRoom.TabIndex = 6;
            this.lblRoom.Text = "[Room]";
            // 
            // lblSelectDate
            // 
            this.lblSelectDate.AutoSize = true;
            this.lblSelectDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectDate.Location = new System.Drawing.Point(285, 32);
            this.lblSelectDate.Name = "lblSelectDate";
            this.lblSelectDate.Size = new System.Drawing.Size(73, 17);
            this.lblSelectDate.TabIndex = 3;
            this.lblSelectDate.Text = "Select Date";
            // 
            // lblInstructor
            // 
            this.lblInstructor.AutoSize = true;
            this.lblInstructor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructor.Location = new System.Drawing.Point(496, 39);
            this.lblInstructor.Name = "lblInstructor";
            this.lblInstructor.Size = new System.Drawing.Size(71, 17);
            this.lblInstructor.TabIndex = 5;
            this.lblInstructor.Text = "[Instructor]";
            // 
            // lblCourseName
            // 
            this.lblCourseName.AutoSize = true;
            this.lblCourseName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseName.Location = new System.Drawing.Point(496, 18);
            this.lblCourseName.Name = "lblCourseName";
            this.lblCourseName.Size = new System.Drawing.Size(96, 17);
            this.lblCourseName.TabIndex = 4;
            this.lblCourseName.Text = "[Course Name]";
            // 
            // cbxCourses
            // 
            this.cbxCourses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.cbxCourses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCourses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.cbxCourses.FormattingEnabled = true;
            this.cbxCourses.Location = new System.Drawing.Point(15, 49);
            this.cbxCourses.Name = "cbxCourses";
            this.cbxCourses.Size = new System.Drawing.Size(255, 29);
            this.cbxCourses.TabIndex = 0;
            this.cbxCourses.SelectedIndexChanged += new System.EventHandler(this.cbxCourses_SelectedIndexChanged);
            // 
            // lblSelectCourse
            // 
            this.lblSelectCourse.AutoSize = true;
            this.lblSelectCourse.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectCourse.Location = new System.Drawing.Point(15, 32);
            this.lblSelectCourse.Name = "lblSelectCourse";
            this.lblSelectCourse.Size = new System.Drawing.Size(87, 17);
            this.lblSelectCourse.TabIndex = 2;
            this.lblSelectCourse.Text = "Select Course";
            // 
            // frmAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(180)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(1011, 571);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.dgvAttendance);
            this.Controls.Add(this.gbxAttendance);
            this.Controls.Add(this.mnuMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(9)))), ((int)(((byte)(11)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.helpme.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TableOfContents);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmAttendance";
            this.helpme.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Primary School - Attendance";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAttendance_FormClosing);
            this.Load += new System.EventHandler(this.frmAttendance_Load);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).EndInit();
            this.gbxAttendance.ResumeLayout(false);
            this.gbxAttendance.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        private System.Windows.Forms.ToolStripMenuItem mnuFilePrint;
        private System.Windows.Forms.ToolStripMenuItem mnuFileClose;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuEditClear;
        private System.Windows.Forms.ToolStripMenuItem mnuEditReset;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpInstructions;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.DataGridView dgvAttendance;
        private System.Windows.Forms.GroupBox gbxAttendance;
        private System.Windows.Forms.ComboBox cbxCourses;
        private System.Windows.Forms.Label lblSelectCourse;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ComboBox cbxDate;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.Label lblSelectDate;
        private System.Windows.Forms.Label lblInstructor;
        private System.Windows.Forms.Label lblCourseName;
        private System.Windows.Forms.HelpProvider helpme;
    }
}