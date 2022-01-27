
namespace PrimarySchool
{
    partial class frmGradebook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGradebook));
            this.mnuMenu = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFilePrint = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditClear = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditReset = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditAssignments = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpInstructions = new System.Windows.Forms.ToolStripMenuItem();
            this.gbxGradebook = new System.Windows.Forms.GroupBox();
            this.lblRoom = new System.Windows.Forms.Label();
            this.lblInstructor = new System.Windows.Forms.Label();
            this.lblCourseName = new System.Windows.Forms.Label();
            this.cbxCourses = new System.Windows.Forms.ComboBox();
            this.lblSelectCourse = new System.Windows.Forms.Label();
            this.dgvGradebook = new System.Windows.Forms.DataGridView();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.mnuMenu.SuspendLayout();
            this.gbxGradebook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGradebook)).BeginInit();
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
            this.mnuMenu.Size = new System.Drawing.Size(1084, 24);
            this.mnuMenu.TabIndex = 0;
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
            this.mnuEditAssignments});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(39, 20);
            this.mnuEdit.Text = "&Edit";
            // 
            // mnuEditClear
            // 
            this.mnuEditClear.Name = "mnuEditClear";
            this.mnuEditClear.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.mnuEditClear.Size = new System.Drawing.Size(184, 22);
            this.mnuEditClear.Text = "&Clear";
            // 
            // mnuEditReset
            // 
            this.mnuEditReset.Name = "mnuEditReset";
            this.mnuEditReset.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.mnuEditReset.Size = new System.Drawing.Size(184, 22);
            this.mnuEditReset.Text = "&Reset";
            // 
            // mnuEditAssignments
            // 
            this.mnuEditAssignments.Name = "mnuEditAssignments";
            this.mnuEditAssignments.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mnuEditAssignments.Size = new System.Drawing.Size(184, 22);
            this.mnuEditAssignments.Text = "&Assignments";
            this.mnuEditAssignments.Click += new System.EventHandler(this.mnuEditAssignments_Click);
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
            // gbxGradebook
            // 
            this.gbxGradebook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(190)))));
            this.gbxGradebook.Controls.Add(this.lblRoom);
            this.gbxGradebook.Controls.Add(this.lblInstructor);
            this.gbxGradebook.Controls.Add(this.lblCourseName);
            this.gbxGradebook.Controls.Add(this.cbxCourses);
            this.gbxGradebook.Controls.Add(this.lblSelectCourse);
            this.gbxGradebook.Location = new System.Drawing.Point(12, 36);
            this.gbxGradebook.Name = "gbxGradebook";
            this.gbxGradebook.Size = new System.Drawing.Size(439, 95);
            this.gbxGradebook.TabIndex = 1;
            this.gbxGradebook.TabStop = false;
            this.gbxGradebook.Text = "Gradebook";
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoom.Location = new System.Drawing.Point(231, 67);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(51, 17);
            this.lblRoom.TabIndex = 4;
            this.lblRoom.Text = "[Room]";
            // 
            // lblInstructor
            // 
            this.lblInstructor.AutoSize = true;
            this.lblInstructor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructor.Location = new System.Drawing.Point(231, 46);
            this.lblInstructor.Name = "lblInstructor";
            this.lblInstructor.Size = new System.Drawing.Size(71, 17);
            this.lblInstructor.TabIndex = 3;
            this.lblInstructor.Text = "[Instructor]";
            // 
            // lblCourseName
            // 
            this.lblCourseName.AutoSize = true;
            this.lblCourseName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseName.Location = new System.Drawing.Point(231, 25);
            this.lblCourseName.Name = "lblCourseName";
            this.lblCourseName.Size = new System.Drawing.Size(96, 17);
            this.lblCourseName.TabIndex = 2;
            this.lblCourseName.Text = "[Course Name]";
            // 
            // cbxCourses
            // 
            this.cbxCourses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.cbxCourses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCourses.Enabled = false;
            this.cbxCourses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.cbxCourses.FormattingEnabled = true;
            this.cbxCourses.Location = new System.Drawing.Point(15, 42);
            this.cbxCourses.Name = "cbxCourses";
            this.cbxCourses.Size = new System.Drawing.Size(196, 29);
            this.cbxCourses.TabIndex = 1;
            // 
            // lblSelectCourse
            // 
            this.lblSelectCourse.AutoSize = true;
            this.lblSelectCourse.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectCourse.Location = new System.Drawing.Point(16, 25);
            this.lblSelectCourse.Name = "lblSelectCourse";
            this.lblSelectCourse.Size = new System.Drawing.Size(87, 17);
            this.lblSelectCourse.TabIndex = 0;
            this.lblSelectCourse.Text = "Select Course";
            // 
            // dgvGradebook
            // 
            this.dgvGradebook.AllowUserToAddRows = false;
            this.dgvGradebook.AllowUserToDeleteRows = false;
            this.dgvGradebook.AllowUserToResizeRows = false;
            this.dgvGradebook.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvGradebook.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvGradebook.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(190)))));
            this.dgvGradebook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGradebook.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dgvGradebook.Enabled = false;
            this.dgvGradebook.Location = new System.Drawing.Point(12, 137);
            this.dgvGradebook.Name = "dgvGradebook";
            this.dgvGradebook.Size = new System.Drawing.Size(1060, 412);
            this.dgvGradebook.TabIndex = 2;
            this.dgvGradebook.TabStop = false;
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructions.Location = new System.Drawing.Point(457, 97);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(586, 34);
            this.lblInstructions.TabIndex = 3;
            this.lblInstructions.Text = "Use the table below to edit assignment grades. The final grade is calculated auto" +
    "matically.\r\nThe menu up top contains more operations. For detailed help, click I" +
    "nstructions under the Help tab.";
            // 
            // frmGradebook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(180)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(1084, 561);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.dgvGradebook);
            this.Controls.Add(this.gbxGradebook);
            this.Controls.Add(this.mnuMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(9)))), ((int)(((byte)(11)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMenu;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmGradebook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Primary School - Gradebook";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGradebook_FormClosing);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.gbxGradebook.ResumeLayout(false);
            this.gbxGradebook.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGradebook)).EndInit();
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
        private System.Windows.Forms.GroupBox gbxGradebook;
        private System.Windows.Forms.ComboBox cbxCourses;
        private System.Windows.Forms.Label lblSelectCourse;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.Label lblInstructor;
        private System.Windows.Forms.Label lblCourseName;
        private System.Windows.Forms.DataGridView dgvGradebook;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.ToolStripMenuItem mnuEditAssignments;
    }
}