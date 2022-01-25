
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
            this.tbxTotalStudents = new System.Windows.Forms.TextBox();
            this.lblTotalStudents = new System.Windows.Forms.Label();
            this.tbxTeacher = new System.Windows.Forms.TextBox();
            this.lblTeacher = new System.Windows.Forms.Label();
            this.tbxCapacity = new System.Windows.Forms.TextBox();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.tbxCourseID = new System.Windows.Forms.TextBox();
            this.lblCourseID = new System.Windows.Forms.Label();
            this.tbxRoom = new System.Windows.Forms.TextBox();
            this.lblRoom = new System.Windows.Forms.Label();
            this.tbxSubject = new System.Windows.Forms.TextBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.tbxCourseName = new System.Windows.Forms.TextBox();
            this.lblCourseName = new System.Windows.Forms.Label();
            this.gbxStudents = new System.Windows.Forms.GroupBox();
            this.lblCourseStudents = new System.Windows.Forms.Label();
            this.lblAvailableStudents = new System.Windows.Forms.Label();
            this.lbxCourseStudents = new System.Windows.Forms.ListBox();
            this.lbxAvailableStudents = new System.Windows.Forms.ListBox();
            this.btnStudentsRemove = new System.Windows.Forms.Button();
            this.btnStudentsAdd = new System.Windows.Forms.Button();
            this.mnuMenu = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditNavigation = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditNavigationFirst = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditNavigationLast = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditNavigationPrevious = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditNavigationNext = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditOperations = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditOperationsEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditOperationsSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditOperationsCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditOperationsAddNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditOperationsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpInstructions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditOperationsStudents = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditOperationsStudentsAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditOperationsStudentsRemove = new System.Windows.Forms.ToolStripMenuItem();
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
            this.gbxSearch.Location = new System.Drawing.Point(83, 316);
            this.gbxSearch.Name = "gbxSearch";
            this.gbxSearch.Size = new System.Drawing.Size(283, 88);
            this.gbxSearch.TabIndex = 75;
            this.gbxSearch.TabStop = false;
            this.gbxSearch.Text = "Search by Subject";
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
            this.btnSearch.TabIndex = 38;
            this.btnSearch.Text = "Sea&rch";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // tbxSearch
            // 
            this.tbxSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.tbxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(180)))), ((int)(((byte)(210)))));
            this.tbxSearch.Location = new System.Drawing.Point(15, 46);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(173, 25);
            this.tbxSearch.TabIndex = 1;
            this.tbxSearch.Text = "Subject";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(15, 26);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(95, 17);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Course Subject";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnDelete.Location = new System.Drawing.Point(178, 273);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(93, 30);
            this.btnDelete.TabIndex = 73;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNew.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnAddNew.Location = new System.Drawing.Point(83, 273);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(93, 30);
            this.btnAddNew.TabIndex = 72;
            this.btnAddNew.Text = "&Add New";
            this.btnAddNew.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnCancel.Location = new System.Drawing.Point(273, 241);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 30);
            this.btnCancel.TabIndex = 71;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnSave.Location = new System.Drawing.Point(178, 241);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 30);
            this.btnSave.TabIndex = 70;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnEdit.Location = new System.Drawing.Point(83, 241);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(93, 30);
            this.btnEdit.TabIndex = 69;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnLast
            // 
            this.btnLast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLast.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnLast.Location = new System.Drawing.Point(226, 177);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(140, 30);
            this.btnLast.TabIndex = 68;
            this.btnLast.Text = "&Last >|";
            this.btnLast.UseVisualStyleBackColor = false;
            // 
            // btnFirst
            // 
            this.btnFirst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirst.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnFirst.Location = new System.Drawing.Point(83, 177);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(140, 30);
            this.btnFirst.TabIndex = 67;
            this.btnFirst.Text = "|< &First";
            this.btnFirst.UseVisualStyleBackColor = false;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnNext.Location = new System.Drawing.Point(226, 209);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(140, 30);
            this.btnNext.TabIndex = 66;
            this.btnNext.Text = "&Next >";
            this.btnNext.UseVisualStyleBackColor = false;
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnPrevious.Location = new System.Drawing.Point(83, 209);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(140, 30);
            this.btnPrevious.TabIndex = 65;
            this.btnPrevious.Text = "< &Previous";
            this.btnPrevious.UseVisualStyleBackColor = false;
            // 
            // tbxTotalStudents
            // 
            this.tbxTotalStudents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(190)))));
            this.tbxTotalStudents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxTotalStudents.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxTotalStudents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(9)))), ((int)(((byte)(11)))));
            this.tbxTotalStudents.Location = new System.Drawing.Point(482, 99);
            this.tbxTotalStudents.Name = "tbxTotalStudents";
            this.tbxTotalStudents.Size = new System.Drawing.Size(283, 27);
            this.tbxTotalStudents.TabIndex = 64;
            this.tbxTotalStudents.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTotalStudents
            // 
            this.lblTotalStudents.AutoSize = true;
            this.lblTotalStudents.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalStudents.Location = new System.Drawing.Point(383, 103);
            this.lblTotalStudents.Name = "lblTotalStudents";
            this.lblTotalStudents.Size = new System.Drawing.Size(93, 17);
            this.lblTotalStudents.TabIndex = 63;
            this.lblTotalStudents.Text = "Total Students:";
            // 
            // tbxTeacher
            // 
            this.tbxTeacher.BackColor = System.Drawing.Color.White;
            this.tbxTeacher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxTeacher.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxTeacher.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(9)))), ((int)(((byte)(11)))));
            this.tbxTeacher.Location = new System.Drawing.Point(83, 133);
            this.tbxTeacher.Name = "tbxTeacher";
            this.tbxTeacher.Size = new System.Drawing.Size(283, 27);
            this.tbxTeacher.TabIndex = 50;
            this.tbxTeacher.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTeacher
            // 
            this.lblTeacher.AutoSize = true;
            this.lblTeacher.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeacher.Location = new System.Drawing.Point(22, 138);
            this.lblTeacher.Name = "lblTeacher";
            this.lblTeacher.Size = new System.Drawing.Size(56, 17);
            this.lblTeacher.TabIndex = 49;
            this.lblTeacher.Text = "Teacher:";
            // 
            // tbxCapacity
            // 
            this.tbxCapacity.BackColor = System.Drawing.Color.White;
            this.tbxCapacity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxCapacity.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCapacity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(9)))), ((int)(((byte)(11)))));
            this.tbxCapacity.Location = new System.Drawing.Point(482, 65);
            this.tbxCapacity.Name = "tbxCapacity";
            this.tbxCapacity.Size = new System.Drawing.Size(283, 27);
            this.tbxCapacity.TabIndex = 48;
            this.tbxCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapacity.Location = new System.Drawing.Point(416, 69);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(60, 17);
            this.lblCapacity.TabIndex = 47;
            this.lblCapacity.Text = "Capacity:";
            // 
            // tbxCourseID
            // 
            this.tbxCourseID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(190)))));
            this.tbxCourseID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxCourseID.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCourseID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(9)))), ((int)(((byte)(11)))));
            this.tbxCourseID.Location = new System.Drawing.Point(83, 31);
            this.tbxCourseID.Name = "tbxCourseID";
            this.tbxCourseID.Size = new System.Drawing.Size(283, 27);
            this.tbxCourseID.TabIndex = 46;
            this.tbxCourseID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCourseID
            // 
            this.lblCourseID.AutoSize = true;
            this.lblCourseID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseID.Location = new System.Drawing.Point(10, 36);
            this.lblCourseID.Name = "lblCourseID";
            this.lblCourseID.Size = new System.Drawing.Size(68, 17);
            this.lblCourseID.TabIndex = 45;
            this.lblCourseID.Text = "Course ID:";
            // 
            // tbxRoom
            // 
            this.tbxRoom.BackColor = System.Drawing.Color.White;
            this.tbxRoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxRoom.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxRoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(9)))), ((int)(((byte)(11)))));
            this.tbxRoom.Location = new System.Drawing.Point(482, 32);
            this.tbxRoom.Name = "tbxRoom";
            this.tbxRoom.Size = new System.Drawing.Size(283, 27);
            this.tbxRoom.TabIndex = 44;
            this.tbxRoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoom.Location = new System.Drawing.Point(430, 36);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(46, 17);
            this.lblRoom.TabIndex = 43;
            this.lblRoom.Text = "Room:";
            // 
            // tbxSubject
            // 
            this.tbxSubject.BackColor = System.Drawing.Color.White;
            this.tbxSubject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxSubject.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSubject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(9)))), ((int)(((byte)(11)))));
            this.tbxSubject.Location = new System.Drawing.Point(83, 99);
            this.tbxSubject.Name = "tbxSubject";
            this.tbxSubject.Size = new System.Drawing.Size(283, 27);
            this.tbxSubject.TabIndex = 42;
            this.tbxSubject.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.Location = new System.Drawing.Point(25, 104);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(53, 17);
            this.lblSubject.TabIndex = 41;
            this.lblSubject.Text = "Subject:";
            // 
            // tbxCourseName
            // 
            this.tbxCourseName.BackColor = System.Drawing.Color.White;
            this.tbxCourseName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxCourseName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCourseName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(9)))), ((int)(((byte)(11)))));
            this.tbxCourseName.Location = new System.Drawing.Point(83, 65);
            this.tbxCourseName.Name = "tbxCourseName";
            this.tbxCourseName.Size = new System.Drawing.Size(283, 27);
            this.tbxCourseName.TabIndex = 40;
            this.tbxCourseName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCourseName
            // 
            this.lblCourseName.AutoSize = true;
            this.lblCourseName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseName.Location = new System.Drawing.Point(32, 69);
            this.lblCourseName.Name = "lblCourseName";
            this.lblCourseName.Size = new System.Drawing.Size(46, 17);
            this.lblCourseName.TabIndex = 39;
            this.lblCourseName.Text = "Name:";
            // 
            // gbxStudents
            // 
            this.gbxStudents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(190)))));
            this.gbxStudents.Controls.Add(this.lblCourseStudents);
            this.gbxStudents.Controls.Add(this.lblAvailableStudents);
            this.gbxStudents.Controls.Add(this.lbxCourseStudents);
            this.gbxStudents.Controls.Add(this.lbxAvailableStudents);
            this.gbxStudents.Controls.Add(this.btnStudentsRemove);
            this.gbxStudents.Controls.Add(this.btnStudentsAdd);
            this.gbxStudents.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxStudents.Location = new System.Drawing.Point(386, 133);
            this.gbxStudents.Name = "gbxStudents";
            this.gbxStudents.Size = new System.Drawing.Size(379, 271);
            this.gbxStudents.TabIndex = 77;
            this.gbxStudents.TabStop = false;
            this.gbxStudents.Text = "Students";
            // 
            // lblCourseStudents
            // 
            this.lblCourseStudents.AutoSize = true;
            this.lblCourseStudents.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseStudents.Location = new System.Drawing.Point(193, 25);
            this.lblCourseStudents.Name = "lblCourseStudents";
            this.lblCourseStudents.Size = new System.Drawing.Size(139, 17);
            this.lblCourseStudents.TabIndex = 88;
            this.lblCourseStudents.Text = "This Course\'s Students";
            // 
            // lblAvailableStudents
            // 
            this.lblAvailableStudents.AutoSize = true;
            this.lblAvailableStudents.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableStudents.Location = new System.Drawing.Point(16, 25);
            this.lblAvailableStudents.Name = "lblAvailableStudents";
            this.lblAvailableStudents.Size = new System.Drawing.Size(114, 17);
            this.lblAvailableStudents.TabIndex = 87;
            this.lblAvailableStudents.Text = "Available Students";
            // 
            // lbxCourseStudents
            // 
            this.lbxCourseStudents.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxCourseStudents.FormattingEnabled = true;
            this.lbxCourseStudents.ItemHeight = 17;
            this.lbxCourseStudents.Location = new System.Drawing.Point(196, 45);
            this.lbxCourseStudents.Name = "lbxCourseStudents";
            this.lbxCourseStudents.Size = new System.Drawing.Size(171, 174);
            this.lbxCourseStudents.TabIndex = 86;
            // 
            // lbxAvailableStudents
            // 
            this.lbxAvailableStudents.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxAvailableStudents.FormattingEnabled = true;
            this.lbxAvailableStudents.ItemHeight = 17;
            this.lbxAvailableStudents.Location = new System.Drawing.Point(19, 45);
            this.lbxAvailableStudents.Name = "lbxAvailableStudents";
            this.lbxAvailableStudents.Size = new System.Drawing.Size(171, 174);
            this.lbxAvailableStudents.TabIndex = 85;
            // 
            // btnStudentsRemove
            // 
            this.btnStudentsRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.btnStudentsRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudentsRemove.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudentsRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnStudentsRemove.Location = new System.Drawing.Point(240, 223);
            this.btnStudentsRemove.Name = "btnStudentsRemove";
            this.btnStudentsRemove.Size = new System.Drawing.Size(83, 26);
            this.btnStudentsRemove.TabIndex = 82;
            this.btnStudentsRemove.Text = "&Remove";
            this.btnStudentsRemove.UseVisualStyleBackColor = false;
            // 
            // btnStudentsAdd
            // 
            this.btnStudentsAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(119)))), ((int)(((byte)(165)))));
            this.btnStudentsAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudentsAdd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudentsAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnStudentsAdd.Location = new System.Drawing.Point(53, 223);
            this.btnStudentsAdd.Name = "btnStudentsAdd";
            this.btnStudentsAdd.Size = new System.Drawing.Size(103, 26);
            this.btnStudentsAdd.TabIndex = 81;
            this.btnStudentsAdd.Text = "Add S&tudent";
            this.btnStudentsAdd.UseVisualStyleBackColor = false;
            // 
            // mnuMenu
            // 
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuHelp});
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.Size = new System.Drawing.Size(774, 24);
            this.mnuMenu.TabIndex = 120;
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
            this.mnuFileClose.Size = new System.Drawing.Size(180, 22);
            this.mnuFileClose.Text = "&Close";
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditNavigation,
            this.mnuEditOperations});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(39, 20);
            this.mnuEdit.Text = "&Edit";
            // 
            // mnuEditNavigation
            // 
            this.mnuEditNavigation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditNavigationFirst,
            this.mnuEditNavigationLast,
            this.mnuEditNavigationPrevious,
            this.mnuEditNavigationNext});
            this.mnuEditNavigation.Name = "mnuEditNavigation";
            this.mnuEditNavigation.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
            | System.Windows.Forms.Keys.N)));
            this.mnuEditNavigation.Size = new System.Drawing.Size(207, 22);
            this.mnuEditNavigation.Text = "Nagivation";
            // 
            // mnuEditNavigationFirst
            // 
            this.mnuEditNavigationFirst.Name = "mnuEditNavigationFirst";
            this.mnuEditNavigationFirst.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.mnuEditNavigationFirst.Size = new System.Drawing.Size(180, 22);
            this.mnuEditNavigationFirst.Text = "&First";
            // 
            // mnuEditNavigationLast
            // 
            this.mnuEditNavigationLast.Name = "mnuEditNavigationLast";
            this.mnuEditNavigationLast.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.mnuEditNavigationLast.Size = new System.Drawing.Size(180, 22);
            this.mnuEditNavigationLast.Text = "&Last";
            // 
            // mnuEditNavigationPrevious
            // 
            this.mnuEditNavigationPrevious.Name = "mnuEditNavigationPrevious";
            this.mnuEditNavigationPrevious.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.mnuEditNavigationPrevious.Size = new System.Drawing.Size(180, 22);
            this.mnuEditNavigationPrevious.Text = "&Previous";
            // 
            // mnuEditNavigationNext
            // 
            this.mnuEditNavigationNext.Name = "mnuEditNavigationNext";
            this.mnuEditNavigationNext.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuEditNavigationNext.Size = new System.Drawing.Size(180, 22);
            this.mnuEditNavigationNext.Text = "&Next";
            // 
            // mnuEditOperations
            // 
            this.mnuEditOperations.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditOperationsEdit,
            this.mnuEditOperationsSave,
            this.mnuEditOperationsCancel,
            this.mnuEditOperationsAddNew,
            this.mnuEditOperationsDelete,
            this.mnuEditOperationsStudents});
            this.mnuEditOperations.Name = "mnuEditOperations";
            this.mnuEditOperations.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
            | System.Windows.Forms.Keys.O)));
            this.mnuEditOperations.Size = new System.Drawing.Size(207, 22);
            this.mnuEditOperations.Text = "Operations";
            // 
            // mnuEditOperationsEdit
            // 
            this.mnuEditOperationsEdit.Name = "mnuEditOperationsEdit";
            this.mnuEditOperationsEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuEditOperationsEdit.Size = new System.Drawing.Size(192, 22);
            this.mnuEditOperationsEdit.Text = "&Edit";
            // 
            // mnuEditOperationsSave
            // 
            this.mnuEditOperationsSave.Name = "mnuEditOperationsSave";
            this.mnuEditOperationsSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuEditOperationsSave.Size = new System.Drawing.Size(192, 22);
            this.mnuEditOperationsSave.Text = "&Save";
            // 
            // mnuEditOperationsCancel
            // 
            this.mnuEditOperationsCancel.Name = "mnuEditOperationsCancel";
            this.mnuEditOperationsCancel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuEditOperationsCancel.Size = new System.Drawing.Size(192, 22);
            this.mnuEditOperationsCancel.Text = "&Cancel";
            // 
            // mnuEditOperationsAddNew
            // 
            this.mnuEditOperationsAddNew.Name = "mnuEditOperationsAddNew";
            this.mnuEditOperationsAddNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mnuEditOperationsAddNew.Size = new System.Drawing.Size(192, 22);
            this.mnuEditOperationsAddNew.Text = "&Add New";
            // 
            // mnuEditOperationsDelete
            // 
            this.mnuEditOperationsDelete.Name = "mnuEditOperationsDelete";
            this.mnuEditOperationsDelete.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.mnuEditOperationsDelete.Size = new System.Drawing.Size(192, 22);
            this.mnuEditOperationsDelete.Text = "&Delete";
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
            this.mnuHelpInstructions.Size = new System.Drawing.Size(180, 22);
            this.mnuHelpInstructions.Text = "&Instructions";
            // 
            // mnuEditOperationsStudents
            // 
            this.mnuEditOperationsStudents.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditOperationsStudentsAdd,
            this.mnuEditOperationsStudentsRemove});
            this.mnuEditOperationsStudents.Name = "mnuEditOperationsStudents";
            this.mnuEditOperationsStudents.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
            | System.Windows.Forms.Keys.T)));
            this.mnuEditOperationsStudents.Size = new System.Drawing.Size(192, 22);
            this.mnuEditOperationsStudents.Text = "S&tudents";
            // 
            // mnuEditOperationsStudentsAdd
            // 
            this.mnuEditOperationsStudentsAdd.Name = "mnuEditOperationsStudentsAdd";
            this.mnuEditOperationsStudentsAdd.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.mnuEditOperationsStudentsAdd.Size = new System.Drawing.Size(180, 22);
            this.mnuEditOperationsStudentsAdd.Text = "Add S&tudent";
            // 
            // mnuEditOperationsStudentsRemove
            // 
            this.mnuEditOperationsStudentsRemove.Name = "mnuEditOperationsStudentsRemove";
            this.mnuEditOperationsStudentsRemove.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.mnuEditOperationsStudentsRemove.Size = new System.Drawing.Size(180, 22);
            this.mnuEditOperationsStudentsRemove.Text = "&Remove";
            // 
            // frmCourses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(180)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(774, 411);
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
            this.Controls.Add(this.tbxTotalStudents);
            this.Controls.Add(this.lblTotalStudents);
            this.Controls.Add(this.tbxTeacher);
            this.Controls.Add(this.lblTeacher);
            this.Controls.Add(this.tbxCapacity);
            this.Controls.Add(this.lblCapacity);
            this.Controls.Add(this.tbxCourseID);
            this.Controls.Add(this.lblCourseID);
            this.Controls.Add(this.tbxRoom);
            this.Controls.Add(this.lblRoom);
            this.Controls.Add(this.tbxSubject);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.tbxCourseName);
            this.Controls.Add(this.lblCourseName);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(9)))), ((int)(((byte)(11)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmCourses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Primary School - Courses";
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
        private System.Windows.Forms.TextBox tbxTotalStudents;
        private System.Windows.Forms.Label lblTotalStudents;
        private System.Windows.Forms.TextBox tbxTeacher;
        private System.Windows.Forms.Label lblTeacher;
        private System.Windows.Forms.TextBox tbxCapacity;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.TextBox tbxCourseID;
        private System.Windows.Forms.Label lblCourseID;
        private System.Windows.Forms.TextBox tbxRoom;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.TextBox tbxSubject;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.TextBox tbxCourseName;
        private System.Windows.Forms.Label lblCourseName;
        private System.Windows.Forms.GroupBox gbxStudents;
        private System.Windows.Forms.Button btnStudentsRemove;
        private System.Windows.Forms.Button btnStudentsAdd;
        private System.Windows.Forms.Label lblCourseStudents;
        private System.Windows.Forms.Label lblAvailableStudents;
        private System.Windows.Forms.ListBox lbxCourseStudents;
        private System.Windows.Forms.ListBox lbxAvailableStudents;
        private System.Windows.Forms.MenuStrip mnuMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileClose;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuEditNavigation;
        private System.Windows.Forms.ToolStripMenuItem mnuEditNavigationFirst;
        private System.Windows.Forms.ToolStripMenuItem mnuEditNavigationLast;
        private System.Windows.Forms.ToolStripMenuItem mnuEditNavigationPrevious;
        private System.Windows.Forms.ToolStripMenuItem mnuEditNavigationNext;
        private System.Windows.Forms.ToolStripMenuItem mnuEditOperations;
        private System.Windows.Forms.ToolStripMenuItem mnuEditOperationsEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuEditOperationsSave;
        private System.Windows.Forms.ToolStripMenuItem mnuEditOperationsCancel;
        private System.Windows.Forms.ToolStripMenuItem mnuEditOperationsAddNew;
        private System.Windows.Forms.ToolStripMenuItem mnuEditOperationsDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuEditOperationsStudents;
        private System.Windows.Forms.ToolStripMenuItem mnuEditOperationsStudentsAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuEditOperationsStudentsRemove;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpInstructions;
    }
}