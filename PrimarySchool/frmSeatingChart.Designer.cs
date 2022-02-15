
namespace PrimarySchool
{
    partial class frmSeatingChart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSeatingChart));
            this.mnuMenu = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFilePrint = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditClear = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditReset = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditRandomize = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpInstructions = new System.Windows.Forms.ToolStripMenuItem();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.dgvSeatingChart = new System.Windows.Forms.DataGridView();
            this.gbxSeatingChart = new System.Windows.Forms.GroupBox();
            this.lblTotalSeats = new System.Windows.Forms.Label();
            this.lblRoom = new System.Windows.Forms.Label();
            this.lblInstructor = new System.Windows.Forms.Label();
            this.lblCourseName = new System.Windows.Forms.Label();
            this.cbxCourses = new System.Windows.Forms.ComboBox();
            this.lblSelectCourse = new System.Windows.Forms.Label();
            this.lblUnavailableSeats = new System.Windows.Forms.Label();
            this.lblAvailableSeats = new System.Windows.Forms.Label();
            this.lbxUnavailableSeats = new System.Windows.Forms.ListBox();
            this.lbxAvailableSeats = new System.Windows.Forms.ListBox();
            this.pbxListBoxBackground = new System.Windows.Forms.PictureBox();
            this.mnuMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeatingChart)).BeginInit();
            this.gbxSeatingChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxListBoxBackground)).BeginInit();
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
            this.mnuMenu.Size = new System.Drawing.Size(769, 24);
            this.mnuMenu.TabIndex = 2;
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
            // 
            // mnuFilePrint
            // 
            this.mnuFilePrint.Name = "mnuFilePrint";
            this.mnuFilePrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.mnuFilePrint.Size = new System.Drawing.Size(144, 22);
            this.mnuFilePrint.Text = "&Print";
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
            this.mnuEditReset,
            this.mnuEditRandomize});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(39, 20);
            this.mnuEdit.Text = "&Edit";
            // 
            // mnuEditClear
            // 
            this.mnuEditClear.Name = "mnuEditClear";
            this.mnuEditClear.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.mnuEditClear.Size = new System.Drawing.Size(206, 22);
            this.mnuEditClear.Text = "&Clear";
            // 
            // mnuEditReset
            // 
            this.mnuEditReset.Name = "mnuEditReset";
            this.mnuEditReset.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.mnuEditReset.Size = new System.Drawing.Size(206, 22);
            this.mnuEditReset.Text = "&Reset";
            // 
            // mnuEditRandomize
            // 
            this.mnuEditRandomize.Name = "mnuEditRandomize";
            this.mnuEditRandomize.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
            this.mnuEditRandomize.Size = new System.Drawing.Size(206, 22);
            this.mnuEditRandomize.Text = "R&andomize";
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
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructions.Location = new System.Drawing.Point(429, 88);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(325, 51);
            this.lblInstructions.TabIndex = 6;
            this.lblInstructions.Text = "Use the bottom left table to assign seating.\r\nThe menu up top contains more opera" +
    "tions. \r\nFor detailed help, click Instructions under the Help tab.";
            // 
            // dgvSeatingChart
            // 
            this.dgvSeatingChart.AllowUserToAddRows = false;
            this.dgvSeatingChart.AllowUserToDeleteRows = false;
            this.dgvSeatingChart.AllowUserToResizeRows = false;
            this.dgvSeatingChart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSeatingChart.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSeatingChart.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(190)))));
            this.dgvSeatingChart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeatingChart.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dgvSeatingChart.Enabled = false;
            this.dgvSeatingChart.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(190)))));
            this.dgvSeatingChart.Location = new System.Drawing.Point(14, 145);
            this.dgvSeatingChart.Name = "dgvSeatingChart";
            this.dgvSeatingChart.Size = new System.Drawing.Size(409, 389);
            this.dgvSeatingChart.TabIndex = 5;
            this.dgvSeatingChart.TabStop = false;
            // 
            // gbxSeatingChart
            // 
            this.gbxSeatingChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(190)))));
            this.gbxSeatingChart.Controls.Add(this.lblTotalSeats);
            this.gbxSeatingChart.Controls.Add(this.lblRoom);
            this.gbxSeatingChart.Controls.Add(this.lblInstructor);
            this.gbxSeatingChart.Controls.Add(this.lblCourseName);
            this.gbxSeatingChart.Controls.Add(this.cbxCourses);
            this.gbxSeatingChart.Controls.Add(this.lblSelectCourse);
            this.gbxSeatingChart.Location = new System.Drawing.Point(14, 33);
            this.gbxSeatingChart.Name = "gbxSeatingChart";
            this.gbxSeatingChart.Size = new System.Drawing.Size(409, 106);
            this.gbxSeatingChart.TabIndex = 7;
            this.gbxSeatingChart.TabStop = false;
            this.gbxSeatingChart.Text = "Seating Chart";
            // 
            // lblTotalSeats
            // 
            this.lblTotalSeats.AutoSize = true;
            this.lblTotalSeats.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSeats.Location = new System.Drawing.Point(231, 80);
            this.lblTotalSeats.Name = "lblTotalSeats";
            this.lblTotalSeats.Size = new System.Drawing.Size(79, 17);
            this.lblTotalSeats.TabIndex = 11;
            this.lblTotalSeats.Text = "[Total Seats]";
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoom.Location = new System.Drawing.Point(231, 59);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(51, 17);
            this.lblRoom.TabIndex = 10;
            this.lblRoom.Text = "[Room]";
            // 
            // lblInstructor
            // 
            this.lblInstructor.AutoSize = true;
            this.lblInstructor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructor.Location = new System.Drawing.Point(231, 38);
            this.lblInstructor.Name = "lblInstructor";
            this.lblInstructor.Size = new System.Drawing.Size(71, 17);
            this.lblInstructor.TabIndex = 9;
            this.lblInstructor.Text = "[Instructor]";
            // 
            // lblCourseName
            // 
            this.lblCourseName.AutoSize = true;
            this.lblCourseName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseName.Location = new System.Drawing.Point(231, 17);
            this.lblCourseName.Name = "lblCourseName";
            this.lblCourseName.Size = new System.Drawing.Size(96, 17);
            this.lblCourseName.TabIndex = 7;
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
            this.cbxCourses.Size = new System.Drawing.Size(196, 29);
            this.cbxCourses.TabIndex = 1;
            this.cbxCourses.SelectedIndexChanged += new System.EventHandler(this.cbxCourses_SelectedIndexChanged);
            // 
            // lblSelectCourse
            // 
            this.lblSelectCourse.AutoSize = true;
            this.lblSelectCourse.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectCourse.Location = new System.Drawing.Point(16, 32);
            this.lblSelectCourse.Name = "lblSelectCourse";
            this.lblSelectCourse.Size = new System.Drawing.Size(87, 17);
            this.lblSelectCourse.TabIndex = 0;
            this.lblSelectCourse.Text = "Select Course";
            // 
            // lblUnavailableSeats
            // 
            this.lblUnavailableSeats.AutoSize = true;
            this.lblUnavailableSeats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.lblUnavailableSeats.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnavailableSeats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.lblUnavailableSeats.Location = new System.Drawing.Point(595, 149);
            this.lblUnavailableSeats.Name = "lblUnavailableSeats";
            this.lblUnavailableSeats.Size = new System.Drawing.Size(126, 20);
            this.lblUnavailableSeats.TabIndex = 17;
            this.lblUnavailableSeats.Text = "Unavailable Seats";
            // 
            // lblAvailableSeats
            // 
            this.lblAvailableSeats.AutoSize = true;
            this.lblAvailableSeats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.lblAvailableSeats.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableSeats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.lblAvailableSeats.Location = new System.Drawing.Point(431, 149);
            this.lblAvailableSeats.Name = "lblAvailableSeats";
            this.lblAvailableSeats.Size = new System.Drawing.Size(110, 20);
            this.lblAvailableSeats.TabIndex = 16;
            this.lblAvailableSeats.Text = "Available Seats";
            // 
            // lbxUnavailableSeats
            // 
            this.lbxUnavailableSeats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.lbxUnavailableSeats.Enabled = false;
            this.lbxUnavailableSeats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(9)))), ((int)(((byte)(11)))));
            this.lbxUnavailableSeats.FormattingEnabled = true;
            this.lbxUnavailableSeats.ItemHeight = 21;
            this.lbxUnavailableSeats.Location = new System.Drawing.Point(595, 173);
            this.lbxUnavailableSeats.Name = "lbxUnavailableSeats";
            this.lbxUnavailableSeats.Size = new System.Drawing.Size(160, 361);
            this.lbxUnavailableSeats.TabIndex = 15;
            // 
            // lbxAvailableSeats
            // 
            this.lbxAvailableSeats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.lbxAvailableSeats.Enabled = false;
            this.lbxAvailableSeats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(9)))), ((int)(((byte)(11)))));
            this.lbxAvailableSeats.FormattingEnabled = true;
            this.lbxAvailableSeats.ItemHeight = 21;
            this.lbxAvailableSeats.Location = new System.Drawing.Point(431, 173);
            this.lbxAvailableSeats.Name = "lbxAvailableSeats";
            this.lbxAvailableSeats.Size = new System.Drawing.Size(160, 361);
            this.lbxAvailableSeats.TabIndex = 14;
            // 
            // pbxListBoxBackground
            // 
            this.pbxListBoxBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.pbxListBoxBackground.Location = new System.Drawing.Point(431, 145);
            this.pbxListBoxBackground.Name = "pbxListBoxBackground";
            this.pbxListBoxBackground.Size = new System.Drawing.Size(324, 389);
            this.pbxListBoxBackground.TabIndex = 8;
            this.pbxListBoxBackground.TabStop = false;
            // 
            // frmSeatingChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(180)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(769, 541);
            this.Controls.Add(this.lblUnavailableSeats);
            this.Controls.Add(this.lblAvailableSeats);
            this.Controls.Add(this.lbxUnavailableSeats);
            this.Controls.Add(this.lbxAvailableSeats);
            this.Controls.Add(this.pbxListBoxBackground);
            this.Controls.Add(this.gbxSeatingChart);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.dgvSeatingChart);
            this.Controls.Add(this.mnuMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(9)))), ((int)(((byte)(11)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmSeatingChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Primary School - Seating Chart";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSeatingChart_FormClosing);
            this.Load += new System.EventHandler(this.frmSeatingChart_Load);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeatingChart)).EndInit();
            this.gbxSeatingChart.ResumeLayout(false);
            this.gbxSeatingChart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxListBoxBackground)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvSeatingChart;
        private System.Windows.Forms.GroupBox gbxSeatingChart;
        private System.Windows.Forms.Label lblTotalSeats;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.Label lblInstructor;
        private System.Windows.Forms.Label lblCourseName;
        private System.Windows.Forms.ComboBox cbxCourses;
        private System.Windows.Forms.Label lblSelectCourse;
        private System.Windows.Forms.Label lblUnavailableSeats;
        private System.Windows.Forms.Label lblAvailableSeats;
        private System.Windows.Forms.ListBox lbxUnavailableSeats;
        private System.Windows.Forms.ListBox lbxAvailableSeats;
        private System.Windows.Forms.PictureBox pbxListBoxBackground;
        private System.Windows.Forms.ToolStripMenuItem mnuEditRandomize;
    }
}