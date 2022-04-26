
namespace PrimarySchool
{
    partial class frmCourses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCourses));
            this.gbxSearch = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.tbxCourseID = new System.Windows.Forms.TextBox();
            this.lblCourseID = new System.Windows.Forms.Label();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbxCourseName = new System.Windows.Forms.TextBox();
            this.lblCourseName = new System.Windows.Forms.Label();
            this.gbxStudents = new System.Windows.Forms.GroupBox();
            this.lblRegisteredStudents = new System.Windows.Forms.Label();
            this.lblAvailableStudents = new System.Windows.Forms.Label();
            this.lbxRegisteredStudents = new System.Windows.Forms.ListBox();
            this.lbxAvailableStudents = new System.Windows.Forms.ListBox();
            this.btnRemoveStudent = new System.Windows.Forms.Button();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.mnuMenu = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditTab = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNavigation = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFirst = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLast = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrevious = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNext = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOperations = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStudents = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemoveStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpInstructions = new System.Windows.Forms.ToolStripMenuItem();
            this.tbxUserID = new System.Windows.Forms.TextBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lbxTeachers = new System.Windows.Forms.ListBox();
            this.tbxStatus = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.gbxSearch.SuspendLayout();
            this.gbxStudents.SuspendLayout();
            this.mnuMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxSearch
            // 
            this.gbxSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(190)))));
            this.gbxSearch.Controls.Add(this.btnSearch);
            this.gbxSearch.Controls.Add(this.tbxSearch);
            this.gbxSearch.Controls.Add(this.lblSearch);
            this.gbxSearch.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxSearch.Location = new System.Drawing.Point(92, 399);
            this.gbxSearch.Name = "gbxSearch";
            this.gbxSearch.Size = new System.Drawing.Size(283, 88);
            this.gbxSearch.TabIndex = 9;
            this.gbxSearch.TabStop = false;
            this.gbxSearch.Text = "Search by Name";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnSearch.Location = new System.Drawing.Point(194, 45);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(71, 26);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Sea&rch";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbxSearch
            // 
            this.tbxSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.tbxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(180)))), ((int)(((byte)(210)))));
            this.tbxSearch.Location = new System.Drawing.Point(15, 46);
            this.tbxSearch.MaxLength = 100;
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(173, 25);
            this.tbxSearch.TabIndex = 1;
            this.tbxSearch.Text = "Name";
            this.tbxSearch.Enter += new System.EventHandler(this.tbxSearch_Enter);
            this.tbxSearch.Leave += new System.EventHandler(this.tbxSearch_Leave);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(15, 26);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(88, 17);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Course Name";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnDelete.Location = new System.Drawing.Point(187, 356);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(93, 30);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNew.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnAddNew.Location = new System.Drawing.Point(92, 356);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(93, 30);
            this.btnAddNew.TabIndex = 7;
            this.btnAddNew.Text = "&Add New";
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnCancel.Location = new System.Drawing.Point(282, 324);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 30);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnSave.Location = new System.Drawing.Point(187, 324);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 30);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnEdit.Location = new System.Drawing.Point(92, 324);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(93, 30);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnLast
            // 
            this.btnLast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLast.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnLast.Location = new System.Drawing.Point(235, 260);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(140, 30);
            this.btnLast.TabIndex = 1;
            this.btnLast.Text = "&Last >|";
            this.btnLast.UseVisualStyleBackColor = false;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirst.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnFirst.Location = new System.Drawing.Point(92, 260);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(140, 30);
            this.btnFirst.TabIndex = 0;
            this.btnFirst.Text = "|< &First";
            this.btnFirst.UseVisualStyleBackColor = false;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnNext.Location = new System.Drawing.Point(235, 292);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(140, 30);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "&Next >";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnPrevious.Location = new System.Drawing.Point(92, 292);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(140, 30);
            this.btnPrevious.TabIndex = 2;
            this.btnPrevious.Text = "< &Previous";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // tbxCourseID
            // 
            this.tbxCourseID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(190)))));
            this.tbxCourseID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxCourseID.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCourseID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(9)))), ((int)(((byte)(11)))));
            this.tbxCourseID.Location = new System.Drawing.Point(92, 37);
            this.tbxCourseID.Name = "tbxCourseID";
            this.tbxCourseID.ReadOnly = true;
            this.tbxCourseID.Size = new System.Drawing.Size(283, 27);
            this.tbxCourseID.TabIndex = 10;
            this.tbxCourseID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxCourseID.TextChanged += new System.EventHandler(this.tbxCourseID_TextChanged);
            // 
            // lblCourseID
            // 
            this.lblCourseID.AutoSize = true;
            this.lblCourseID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseID.Location = new System.Drawing.Point(19, 42);
            this.lblCourseID.Name = "lblCourseID";
            this.lblCourseID.Size = new System.Drawing.Size(68, 17);
            this.lblCourseID.TabIndex = 16;
            this.lblCourseID.Text = "Course ID:";
            // 
            // tbxDescription
            // 
            this.tbxDescription.BackColor = System.Drawing.Color.White;
            this.tbxDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxDescription.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(9)))), ((int)(((byte)(11)))));
            this.tbxDescription.Location = new System.Drawing.Point(92, 135);
            this.tbxDescription.MaxLength = 255;
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.ReadOnly = true;
            this.tbxDescription.Size = new System.Drawing.Size(283, 110);
            this.tbxDescription.TabIndex = 12;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(10, 135);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(77, 17);
            this.lblDescription.TabIndex = 18;
            this.lblDescription.Text = "Description:";
            // 
            // tbxCourseName
            // 
            this.tbxCourseName.BackColor = System.Drawing.Color.White;
            this.tbxCourseName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxCourseName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCourseName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(9)))), ((int)(((byte)(11)))));
            this.tbxCourseName.Location = new System.Drawing.Point(92, 102);
            this.tbxCourseName.MaxLength = 100;
            this.tbxCourseName.Name = "tbxCourseName";
            this.tbxCourseName.ReadOnly = true;
            this.tbxCourseName.Size = new System.Drawing.Size(283, 27);
            this.tbxCourseName.TabIndex = 11;
            this.tbxCourseName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCourseName
            // 
            this.lblCourseName.AutoSize = true;
            this.lblCourseName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseName.Location = new System.Drawing.Point(41, 107);
            this.lblCourseName.Name = "lblCourseName";
            this.lblCourseName.Size = new System.Drawing.Size(46, 17);
            this.lblCourseName.TabIndex = 17;
            this.lblCourseName.Text = "Name:";
            // 
            // gbxStudents
            // 
            this.gbxStudents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(190)))));
            this.gbxStudents.Controls.Add(this.lblRegisteredStudents);
            this.gbxStudents.Controls.Add(this.lblAvailableStudents);
            this.gbxStudents.Controls.Add(this.lbxRegisteredStudents);
            this.gbxStudents.Controls.Add(this.lbxAvailableStudents);
            this.gbxStudents.Controls.Add(this.btnRemoveStudent);
            this.gbxStudents.Controls.Add(this.btnAddStudent);
            this.gbxStudents.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxStudents.Location = new System.Drawing.Point(392, 260);
            this.gbxStudents.Name = "gbxStudents";
            this.gbxStudents.Size = new System.Drawing.Size(379, 227);
            this.gbxStudents.TabIndex = 20;
            this.gbxStudents.TabStop = false;
            this.gbxStudents.Text = "Students";
            // 
            // lblRegisteredStudents
            // 
            this.lblRegisteredStudents.AutoSize = true;
            this.lblRegisteredStudents.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegisteredStudents.Location = new System.Drawing.Point(192, 23);
            this.lblRegisteredStudents.Name = "lblRegisteredStudents";
            this.lblRegisteredStudents.Size = new System.Drawing.Size(125, 17);
            this.lblRegisteredStudents.TabIndex = 1;
            this.lblRegisteredStudents.Text = "Registered Students";
            // 
            // lblAvailableStudents
            // 
            this.lblAvailableStudents.AutoSize = true;
            this.lblAvailableStudents.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableStudents.Location = new System.Drawing.Point(10, 23);
            this.lblAvailableStudents.Name = "lblAvailableStudents";
            this.lblAvailableStudents.Size = new System.Drawing.Size(114, 17);
            this.lblAvailableStudents.TabIndex = 0;
            this.lblAvailableStudents.Text = "Available Students";
            // 
            // lbxRegisteredStudents
            // 
            this.lbxRegisteredStudents.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxRegisteredStudents.FormattingEnabled = true;
            this.lbxRegisteredStudents.ItemHeight = 17;
            this.lbxRegisteredStudents.Location = new System.Drawing.Point(192, 42);
            this.lbxRegisteredStudents.Name = "lbxRegisteredStudents";
            this.lbxRegisteredStudents.ScrollAlwaysVisible = true;
            this.lbxRegisteredStudents.Size = new System.Drawing.Size(176, 140);
            this.lbxRegisteredStudents.TabIndex = 3;
            // 
            // lbxAvailableStudents
            // 
            this.lbxAvailableStudents.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxAvailableStudents.FormattingEnabled = true;
            this.lbxAvailableStudents.ItemHeight = 17;
            this.lbxAvailableStudents.Location = new System.Drawing.Point(10, 42);
            this.lbxAvailableStudents.Name = "lbxAvailableStudents";
            this.lbxAvailableStudents.ScrollAlwaysVisible = true;
            this.lbxAvailableStudents.Size = new System.Drawing.Size(176, 140);
            this.lbxAvailableStudents.TabIndex = 2;
            // 
            // btnRemoveStudent
            // 
            this.btnRemoveStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.btnRemoveStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveStudent.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveStudent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnRemoveStudent.Location = new System.Drawing.Point(239, 185);
            this.btnRemoveStudent.Name = "btnRemoveStudent";
            this.btnRemoveStudent.Size = new System.Drawing.Size(83, 26);
            this.btnRemoveStudent.TabIndex = 5;
            this.btnRemoveStudent.Text = "&Remove";
            this.btnRemoveStudent.UseVisualStyleBackColor = false;
            this.btnRemoveStudent.Click += new System.EventHandler(this.btnRemoveStudent_Click);
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.btnAddStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddStudent.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStudent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnAddStudent.Location = new System.Drawing.Point(47, 185);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(103, 26);
            this.btnAddStudent.TabIndex = 4;
            this.btnAddStudent.Text = "Add S&tudent";
            this.btnAddStudent.UseVisualStyleBackColor = false;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // mnuMenu
            // 
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEditTab,
            this.mnuHelp});
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.Size = new System.Drawing.Size(780, 24);
            this.mnuMenu.TabIndex = 14;
            this.mnuMenu.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileClose});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "F&ile";
            // 
            // mnuFileClose
            // 
            this.mnuFileClose.Name = "mnuFileClose";
            this.mnuFileClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuFileClose.Size = new System.Drawing.Size(144, 22);
            this.mnuFileClose.Text = "&Close";
            this.mnuFileClose.Click += new System.EventHandler(this.mnuFileClose_Click);
            // 
            // mnuEditTab
            // 
            this.mnuEditTab.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNavigation,
            this.mnuOperations});
            this.mnuEditTab.Name = "mnuEditTab";
            this.mnuEditTab.Size = new System.Drawing.Size(39, 20);
            this.mnuEditTab.Text = "Edi&t";
            // 
            // mnuNavigation
            // 
            this.mnuNavigation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFirst,
            this.mnuLast,
            this.mnuPrevious,
            this.mnuNext});
            this.mnuNavigation.Name = "mnuNavigation";
            this.mnuNavigation.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.mnuNavigation.Size = new System.Drawing.Size(207, 22);
            this.mnuNavigation.Text = "Nagivation";
            // 
            // mnuFirst
            // 
            this.mnuFirst.Name = "mnuFirst";
            this.mnuFirst.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.mnuFirst.Size = new System.Drawing.Size(160, 22);
            this.mnuFirst.Text = "&First";
            this.mnuFirst.Click += new System.EventHandler(this.mnuFirst_Click);
            // 
            // mnuLast
            // 
            this.mnuLast.Name = "mnuLast";
            this.mnuLast.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.mnuLast.Size = new System.Drawing.Size(160, 22);
            this.mnuLast.Text = "&Last";
            this.mnuLast.Click += new System.EventHandler(this.mnuLast_Click);
            // 
            // mnuPrevious
            // 
            this.mnuPrevious.Name = "mnuPrevious";
            this.mnuPrevious.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.mnuPrevious.Size = new System.Drawing.Size(160, 22);
            this.mnuPrevious.Text = "&Previous";
            this.mnuPrevious.Click += new System.EventHandler(this.mnuPrevious_Click);
            // 
            // mnuNext
            // 
            this.mnuNext.Name = "mnuNext";
            this.mnuNext.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuNext.Size = new System.Drawing.Size(160, 22);
            this.mnuNext.Text = "&Next";
            this.mnuNext.Click += new System.EventHandler(this.mnuNext_Click);
            // 
            // mnuOperations
            // 
            this.mnuOperations.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditRecord,
            this.mnuSave,
            this.mnuCancel,
            this.mnuAddNew,
            this.mnuDelete,
            this.mnuSearch,
            this.mnuStudents});
            this.mnuOperations.Name = "mnuOperations";
            this.mnuOperations.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.mnuOperations.Size = new System.Drawing.Size(207, 22);
            this.mnuOperations.Text = "Operations";
            // 
            // mnuEditRecord
            // 
            this.mnuEditRecord.Name = "mnuEditRecord";
            this.mnuEditRecord.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuEditRecord.Size = new System.Drawing.Size(192, 22);
            this.mnuEditRecord.Text = "&Edit";
            this.mnuEditRecord.Click += new System.EventHandler(this.mnuEditRecord_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuSave.Size = new System.Drawing.Size(192, 22);
            this.mnuSave.Text = "&Save";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // mnuCancel
            // 
            this.mnuCancel.Name = "mnuCancel";
            this.mnuCancel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuCancel.Size = new System.Drawing.Size(192, 22);
            this.mnuCancel.Text = "&Cancel";
            this.mnuCancel.Click += new System.EventHandler(this.mnuCancel_Click);
            // 
            // mnuAddNew
            // 
            this.mnuAddNew.Name = "mnuAddNew";
            this.mnuAddNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mnuAddNew.Size = new System.Drawing.Size(192, 22);
            this.mnuAddNew.Text = "&Add New";
            this.mnuAddNew.Click += new System.EventHandler(this.mnuAddNew_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.mnuDelete.Size = new System.Drawing.Size(192, 22);
            this.mnuDelete.Text = "&Delete";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // mnuSearch
            // 
            this.mnuSearch.Name = "mnuSearch";
            this.mnuSearch.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
            this.mnuSearch.Size = new System.Drawing.Size(192, 22);
            this.mnuSearch.Text = "Sea&rch";
            this.mnuSearch.Click += new System.EventHandler(this.mnuSearch_Click);
            // 
            // mnuStudents
            // 
            this.mnuStudents.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddStudent,
            this.mnuRemoveStudent});
            this.mnuStudents.Name = "mnuStudents";
            this.mnuStudents.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.T)));
            this.mnuStudents.Size = new System.Drawing.Size(192, 22);
            this.mnuStudents.Text = "S&tudents";
            // 
            // mnuAddStudent
            // 
            this.mnuAddStudent.Name = "mnuAddStudent";
            this.mnuAddStudent.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.mnuAddStudent.Size = new System.Drawing.Size(180, 22);
            this.mnuAddStudent.Text = "Add S&tudent";
            // 
            // mnuRemoveStudent
            // 
            this.mnuRemoveStudent.Name = "mnuRemoveStudent";
            this.mnuRemoveStudent.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.mnuRemoveStudent.Size = new System.Drawing.Size(180, 22);
            this.mnuRemoveStudent.Text = "&Remove";
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
            // tbxUserID
            // 
            this.tbxUserID.BackColor = System.Drawing.Color.White;
            this.tbxUserID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxUserID.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxUserID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(9)))), ((int)(((byte)(11)))));
            this.tbxUserID.Location = new System.Drawing.Point(470, 37);
            this.tbxUserID.MaxLength = 4;
            this.tbxUserID.Name = "tbxUserID";
            this.tbxUserID.ReadOnly = true;
            this.tbxUserID.Size = new System.Drawing.Size(298, 27);
            this.tbxUserID.TabIndex = 13;
            this.tbxUserID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.Location = new System.Drawing.Point(392, 42);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(72, 17);
            this.lblUserID.TabIndex = 19;
            this.lblUserID.Text = "Teacher ID:";
            // 
            // lbxTeachers
            // 
            this.lbxTeachers.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxTeachers.FormattingEnabled = true;
            this.lbxTeachers.ItemHeight = 17;
            this.lbxTeachers.Location = new System.Drawing.Point(392, 71);
            this.lbxTeachers.Name = "lbxTeachers";
            this.lbxTeachers.Size = new System.Drawing.Size(376, 174);
            this.lbxTeachers.TabIndex = 15;
            // 
            // tbxStatus
            // 
            this.tbxStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(190)))));
            this.tbxStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(9)))), ((int)(((byte)(11)))));
            this.tbxStatus.Location = new System.Drawing.Point(92, 71);
            this.tbxStatus.Name = "tbxStatus";
            this.tbxStatus.ReadOnly = true;
            this.tbxStatus.Size = new System.Drawing.Size(283, 27);
            this.tbxStatus.TabIndex = 21;
            this.tbxStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(41, 76);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(46, 17);
            this.lblStatus.TabIndex = 22;
            this.lblStatus.Text = "Status:";
            // 
            // frmCourses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(180)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(780, 497);
            this.Controls.Add(this.tbxStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lbxTeachers);
            this.Controls.Add(this.tbxUserID);
            this.Controls.Add(this.lblUserID);
            this.Controls.Add(this.mnuMenu);
            this.Controls.Add(this.gbxStudents);
            this.Controls.Add(this.gbxSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.tbxCourseID);
            this.Controls.Add(this.lblCourseID);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.tbxCourseName);
            this.Controls.Add(this.lblCourseName);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(9)))), ((int)(((byte)(11)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmCourses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Primary School - Courses";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCourses_FormClosing);
            this.Load += new System.EventHandler(this.frmCourses_Load);
            this.gbxSearch.ResumeLayout(false);
            this.gbxSearch.PerformLayout();
            this.gbxStudents.ResumeLayout(false);
            this.gbxStudents.PerformLayout();
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gbxSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.TextBox tbxCourseID;
        private System.Windows.Forms.Label lblCourseID;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox tbxCourseName;
        private System.Windows.Forms.Label lblCourseName;
        private System.Windows.Forms.GroupBox gbxStudents;
        private System.Windows.Forms.Button btnRemoveStudent;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.Label lblRegisteredStudents;
        private System.Windows.Forms.Label lblAvailableStudents;
        private System.Windows.Forms.ListBox lbxRegisteredStudents;
        private System.Windows.Forms.ListBox lbxAvailableStudents;
        private System.Windows.Forms.MenuStrip mnuMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileClose;
        private System.Windows.Forms.ToolStripMenuItem mnuEditTab;
        private System.Windows.Forms.ToolStripMenuItem mnuNavigation;
        private System.Windows.Forms.ToolStripMenuItem mnuFirst;
        private System.Windows.Forms.ToolStripMenuItem mnuLast;
        private System.Windows.Forms.ToolStripMenuItem mnuPrevious;
        private System.Windows.Forms.ToolStripMenuItem mnuNext;
        private System.Windows.Forms.ToolStripMenuItem mnuOperations;
        private System.Windows.Forms.ToolStripMenuItem mnuEditRecord;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripMenuItem mnuCancel;
        private System.Windows.Forms.ToolStripMenuItem mnuAddNew;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuStudents;
        private System.Windows.Forms.ToolStripMenuItem mnuAddStudent;
        private System.Windows.Forms.ToolStripMenuItem mnuRemoveStudent;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpInstructions;
        private System.Windows.Forms.ToolStripMenuItem mnuSearch;
        private System.Windows.Forms.TextBox tbxUserID;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.ListBox lbxTeachers;
        private System.Windows.Forms.TextBox tbxStatus;
        private System.Windows.Forms.Label lblStatus;
    }
}