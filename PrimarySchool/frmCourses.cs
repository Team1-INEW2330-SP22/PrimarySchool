using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace PrimarySchool
{
    public partial class frmCourses : Form
    {
        // Creates 'home' attribute so we can show Home again. Doesn't initialize.
        private frmHome home;

        // Creates 'state' attribute to hold current state.
        private string state;

        // Creates currency manager.
        private CurrencyManager manager;

        // Holds currency manager position.
        private int bookmark;

        // Creates form level data table for teachers
        //      Column [0]: User_ID
        //      Column [1]: Name
        private DataTable teachersTable;

        // Holds default value for tbxSearch
        private string strSearch = "Name";

        // Lists to hold student IDs
        private List<int> registeredStudentIDs;
        private List<int> availableStudentIDs;

        // Bool to track if adding new course
        private bool newCourse;

        // Initializes 'home' attribute to parameter.
        public frmCourses(frmHome home)
        {
            this.home = home;
            InitializeComponent();
        }

        // Boolean method for checking that data lists are not null
        private bool CheckDataLists()
        {
            try
            {
                if (registeredStudentIDs != null &&
                    availableStudentIDs != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return false;
            }
        }

        // Method to initialize data lists
        private void InitDataLists()
        {
            try
            {
                ClearDataLists();

                registeredStudentIDs = new List<int>();

                availableStudentIDs = new List<int>();
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Clears data lists
        private void ClearDataLists()
        {
            try
            {
                if (CheckDataLists())
                {
                    registeredStudentIDs.Clear();

                    availableStudentIDs.Clear();
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }
        
        // Calls DB commmand
        // Fills currency manager
        // Sets state to 'View'
        private void frmCourses_Load(object sender, EventArgs e)
        {
            try
            {
                ProgOps.DatabaseCommandCourses(tbxCourseID, tbxCourseName, tbxDescription, tbxUserID);

                manager = (CurrencyManager)this.BindingContext[ProgOps.CoursesTable];

                FillTeachersDataTable();

                FillTeachersListBox();

                InitDataLists();

                newCourse = false;

                SetState("View");
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Prevents closing of form during edits
        // Updates database
        // Closes and disposes of DB objects
        // Shows Home
        private void frmCourses_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (state.Equals("Edit") || state.Equals("Add New"))
                {
                    FormOps.ErrorBox("You must finish the current edit before closing Courses.");

                    e.Cancel = true;
                }
                else
                {
                    ClearTeachersDataTable();

                    ClearDataLists();

                    ProgOps.DisposeCourses();

                    FormOps.ShowModeless(home);
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Closes Courses
        private void mnuFileClose_Click(object sender, EventArgs e)
        {
            FormOps.CloseModeless(this);
        }

        // Sets program state based on parameter/argument
        private void SetState(string state)
        {
            try
            {
                this.state = state;

                switch (state)
                {
                    case "View":
                        tbxCourseName.ReadOnly = true;
                        tbxDescription.ReadOnly = true;
                        tbxUserID.ReadOnly = true;
                        btnFirst.Enabled = true;
                        btnLast.Enabled = true;
                        btnNext.Enabled = true;
                        btnPrevious.Enabled = true;
                        btnEdit.Enabled = true;
                        btnAddNew.Enabled = true;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = true;
                        btnCancel.Enabled = false;
                        gbxSearch.Enabled = true;
                        tbxSearch.ReadOnly = false;
                        btnSearch.Enabled = true;
                        btnAddStudent.Enabled = false;
                        btnRemoveStudent.Enabled = false;
                        mnuNavigation.Enabled = true;
                        mnuFirst.Enabled = true;
                        mnuLast.Enabled = true;
                        mnuNext.Enabled = true;
                        mnuPrevious.Enabled = true;
                        mnuEditRecord.Enabled = true;
                        mnuAddNew.Enabled = true;
                        mnuSave.Enabled = false;
                        mnuDelete.Enabled = true;
                        mnuCancel.Enabled = false;
                        mnuSearch.Enabled = true;
                        mnuStudents.Enabled = false;
                        mnuAddStudent.Enabled = false;
                        mnuRemoveStudent.Enabled = false;
                        tbxCourseName.Focus();
                        break;
                    // Acts as both 'Add New' and 'Edit' state
                    default:
                        tbxCourseName.ReadOnly = false;
                        tbxDescription.ReadOnly = false;
                        tbxUserID.ReadOnly = false;
                        btnFirst.Enabled = false;
                        btnLast.Enabled = false;
                        btnNext.Enabled = false;
                        btnPrevious.Enabled = false;
                        btnEdit.Enabled = false;
                        btnAddNew.Enabled = false;
                        btnSave.Enabled = true;
                        btnDelete.Enabled = false;
                        btnCancel.Enabled = true;
                        gbxSearch.Enabled = false;
                        tbxSearch.ReadOnly = true;
                        btnSearch.Enabled = false;
                        btnAddStudent.Enabled = true;
                        btnRemoveStudent.Enabled = true;
                        mnuNavigation.Enabled = false;
                        mnuFirst.Enabled = false;
                        mnuLast.Enabled = false;
                        mnuNext.Enabled = false;
                        mnuPrevious.Enabled = false;
                        mnuEditRecord.Enabled = false;
                        mnuAddNew.Enabled = false;
                        mnuSave.Enabled = true;
                        mnuDelete.Enabled = false;
                        mnuCancel.Enabled = true;
                        mnuSearch.Enabled = false;
                        mnuStudents.Enabled = true;
                        mnuAddStudent.Enabled = true;
                        mnuRemoveStudent.Enabled = true;
                        tbxCourseName.Focus();
                        break;
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Calls GoToFirst()
        private void btnFirst_Click(object sender, EventArgs e)
        {
            GoToFirst();
        }

        // Calls GoToFirst()
        private void mnuFirst_Click(object sender, EventArgs e)
        {
            GoToFirst();
        }

        // Calls GoToLast()
        private void btnLast_Click(object sender, EventArgs e)
        {
            GoToLast();
        }

        // Calls GoToLast()
        private void mnuLast_Click(object sender, EventArgs e)
        {
            GoToLast();
        }

        // Calls GoToPrevious()
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            GoToPrevious();
        }

        // Calls GoToPrevious()
        private void mnuPrevious_Click(object sender, EventArgs e)
        {
            GoToPrevious();
        }

        // Calls GoToNext()
        private void btnNext_Click(object sender, EventArgs e)
        {
            GoToNext();
        }

        // Calls GoToNext()
        private void mnuNext_Click(object sender, EventArgs e)
        {
            GoToNext();
        }

        // Calls Edit()
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        // Calls Edit()
        private void mnuEditRecord_Click(object sender, EventArgs e)
        {
            Edit();
        }

        // Calls Save()
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        // Calls Save()
        private void mnuSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        // Calls Cancel()
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        // Calls Cancel()
        private void mnuCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        // Calls AddNew()
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddNew();
        }

        // Calls AddNew()
        private void mnuAddNew_Click(object sender, EventArgs e)
        {
            AddNew();
        }

        // Calls Delete()
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        // Calls Delete()
        private void mnuDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        // Checks validity of edited/new data
        private bool ValidateData()
        {
            try
            {
                string message = "Invalid input detected.";

                bool allOK = true;

                if (tbxCourseName.Text.Trim().Equals(string.Empty))
                {
                    message = "You must enter a Name.";
                    tbxCourseName.Focus();
                    allOK = false;
                }

                if (tbxDescription.Text.Trim().Equals(string.Empty))
                {
                    message = "You must enter a Description.";
                    tbxDescription.Focus();
                    allOK = false;
                }

                if (tbxUserID.Text.Trim().Equals(string.Empty))
                {
                    message = "You must enter a Teacher ID.";
                    tbxUserID.Focus();
                    allOK = false;
                }

                List<int> teacherIDList = new List<int>();

                for (int x = 0; x < teachersTable.Rows.Count; x++)
                {
                    teacherIDList.Add(Convert.ToInt32(teachersTable.Rows[x][0]));
                }

                if (!teacherIDList.Contains(Convert.ToInt32(tbxUserID.Text.Trim())))
                {
                    message = "You must enter a valid Teacher ID.\n\n" +
                        "Review the list box on the right side of the form.";
                    tbxUserID.Focus();
                    teacherIDList.Clear();
                    allOK = false;
                }

                teacherIDList.Clear();

                if (!allOK)
                {
                    FormOps.ErrorBox(message);
                }

                return allOK;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return false;
            }
        }

        // Goes to first record and beeps
        private void GoToFirst()
        {
            try
            {
                manager.Position = 0;

                SystemSounds.Beep.Play();
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Goes to last record and beeps
        private void GoToLast()
        {
            try
            {
                manager.Position = manager.Count - 1;

                SystemSounds.Beep.Play();
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Goes to previous record
        // Beeps when first record is reached
        private void GoToPrevious()
        {
            try
            {
                if (manager.Position == 0)
                {
                    SystemSounds.Beep.Play();
                }

                manager.Position--;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Goes to next record
        // Beeps when last record is reached
        private void GoToNext()
        {
            try
            {
                if (manager.Position == manager.Count - 1)
                {
                    SystemSounds.Beep.Play();
                }

                manager.Position++;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Calls ValidateData before saving
        // Ends current edit
        // Sorts by Course Name
        // Informs user of successful save
        // Sets state to 'View'
        private void Save()
        {
            if (!ValidateData())
            {
                return;
            }

            try
            {
                manager.EndCurrentEdit();

                ProgOps.UpdateCourses();

                if (newCourse)
                {
                    int courseID = ProgOps.GetCourseID(tbxCourseName.Text);

                    ProgOps.AddPlaceholderStudentToNewCourse(courseID);

                    ClearDataLists();

                    FillRegisteredStudentsListBox();

                    FillAvailableStudentsListBox();

                    newCourse = false;
                }

                ProgOps.CoursesTable.DefaultView.Sort = "Course_Name";

                MessageBox.Show("Record saved.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                SetState("View");
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Asks user if they are sure about deleting the chosen record
        // Returns to form if 'no' selected
        // Deletes record if 'yes' selected
        // Sets state to View
        private void Delete()
        {
            if (!FormOps.QuestionBox("Are you sure you want to delete this course?\n\n" +
                "It will be deleted from the database entirely,\n" +
                "an action which cannot be undone."))
            {
                return;
            }
            else
            {
                try
                {
                    ProgOps.DeleteCourseFromAncillaryTables(Convert.ToInt32(tbxCourseID.Text));

                    manager.RemoveAt(manager.Position);

                    ProgOps.UpdateCourses();
                }
                catch (Exception ex)
                {
                    FormOps.ErrorBox(ex.Message);
                }
            }

            SetState("View");
        }

        // Cancels current edit
        // Prevents error if user cancels before saving new record
        // Sets state to 'View'
        private void Cancel()
        {
            try
            {
                manager.CancelCurrentEdit();

                if (state.Equals("Add New"))
                {
                    manager.Position = bookmark;
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }

            SetState("View");
        }

        // Saves curreny manager position into bookmark variable
        // Set state to 'Add'
        // Adds new record to data table
        private void AddNew()
        {
            try
            {
                bookmark = manager.Position;

                SetState("Add New");

                newCourse = true;

                manager.AddNew();

                lblAvailableStudents.Text = "Available Students (0)";

                lblRegisteredStudents.Text = "Registered Students (0)";

                lbxAvailableStudents.Items.Clear();

                lbxRegisteredStudents.Items.Clear();
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Sets state to 'Edit'
        private void Edit()
        {
            SetState("Edit");
        }

        private void FillTeachersDataTable()
        {
            try
            {
                teachersTable = ProgOps.GetTeachersTable();
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void ClearTeachersDataTable()
        {
            try
            {
                if (teachersTable != null)
                {
                    teachersTable.Clear();
                    teachersTable.Dispose();
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void FillTeachersListBox()
        {
            try
            {
                if (teachersTable != null)
                {
                    lbxTeachers.Items.Add("Teacher ID - Name");
                    lbxTeachers.Items.Add("");

                    for (int x = 0; x < teachersTable.Rows.Count; x++)
                    {
                        lbxTeachers.Items.Add(teachersTable.Rows[x][0].ToString() +
                            " - " + teachersTable.Rows[x][1].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void tbxSearch_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbxSearch.Text.Trim().Equals(string.Empty))
                {
                    tbxSearch.ForeColor = FormOps.GetColorFromPalette("mid blue");
                    tbxSearch.Text = strSearch;
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void tbxSearch_Enter(object sender, EventArgs e)
        {
            try
            {
                if (tbxSearch.Text.Equals(strSearch))
                {
                    tbxSearch.Text = string.Empty;
                    tbxSearch.ForeColor = FormOps.GetColorFromPalette("black");
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void PerformSearch()
        {
            try
            {
                if (tbxSearch.Text.Equals(string.Empty))
                {
                    return;
                }

                int savedRow = manager.Position;

                DataRow[] foundRows;

                ProgOps.CoursesTable.DefaultView.Sort = "Course_Name";

                foundRows = ProgOps.CoursesTable.Select("Course_Name LIKE '" + tbxSearch.Text + "*'");

                if (foundRows.Length == 0)
                {
                    manager.Position = savedRow;
                }
                else
                {
                    manager.Position = ProgOps.CoursesTable.DefaultView.Find(foundRows[0]["Course_Name"]);
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void mnuSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void FillRegisteredStudentsListBox()
        {
            try
            {
                lbxRegisteredStudents.Items.Clear();

                if (!tbxCourseID.Text.Equals(string.Empty))
                {
                    DataTable studentsTable = ProgOps.GetStudentsInCourse(Convert.ToInt32(tbxCourseID.Text));

                    if (studentsTable.Rows.Count > 0)
                    {
                        lblRegisteredStudents.Text = "Registered Students (" + studentsTable.Rows.Count.ToString() + ")";

                        for (int x = 0; x < studentsTable.Rows.Count; x++)
                        {
                            if (CheckDataLists())
                            {
                                registeredStudentIDs.Add(Convert.ToInt32(studentsTable.Rows[x][0]));
                            }

                            lbxRegisteredStudents.Items.Add(studentsTable.Rows[x][1] + " " + studentsTable.Rows[x][2]);
                        }
                    }
                    else
                    {
                        lblRegisteredStudents.Text = "Registered Students (0)";
                    }

                    studentsTable.Clear();
                    studentsTable.Dispose();
                }
                else
                {
                    lblRegisteredStudents.Text = "Registered Students (0)";
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void FillAvailableStudentsListBox()
        {
            try
            {
                lbxAvailableStudents.Items.Clear();

                if (!tbxCourseID.Text.Equals(string.Empty))
                {
                    DataTable studentsTable = ProgOps.GetStudentsNotInCourse(Convert.ToInt32(tbxCourseID.Text));

                    if (studentsTable.Rows.Count > 0)
                    {
                        lblAvailableStudents.Text = "Available Students (" + studentsTable.Rows.Count.ToString() + ")";

                        for (int x = 0; x < studentsTable.Rows.Count; x++)
                        {
                            if (CheckDataLists())
                            {
                                availableStudentIDs.Add(Convert.ToInt32(studentsTable.Rows[x][0]));
                            }

                            lbxAvailableStudents.Items.Add(studentsTable.Rows[x][1] + " " + studentsTable.Rows[x][2]);
                        }
                    }
                    else
                    {
                        lblAvailableStudents.Text = "Available Students (0)";
                    }

                    studentsTable.Clear();
                    studentsTable.Dispose();
                }
                else
                {
                    lblAvailableStudents.Text = "Available Students (0)";
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void tbxCourseID_TextChanged(object sender, EventArgs e)
        {
            ClearDataLists();

            FillRegisteredStudentsListBox();

            FillAvailableStudentsListBox();
        }

        // Adds student to course by calling ProgOps method
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbxAvailableStudents.SelectedIndex >= 0)
                {
                    if (FormOps.QuestionBox("Are you sure you want to add this student?"))
                    {
                        int studentID = Convert.ToInt32(availableStudentIDs[lbxAvailableStudents.SelectedIndex]),
                            courseID = Convert.ToInt32(tbxCourseID.Text);

                        ProgOps.AddStudentToCourse(studentID, courseID);

                        ClearDataLists();

                        FillRegisteredStudentsListBox();

                        FillAvailableStudentsListBox();
                    }
                }
                else
                {
                    FormOps.ErrorBox("Select an available student to add.");
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void btnRemoveStudent_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbxRegisteredStudents.SelectedIndex >= 0)
                {
                    if (registeredStudentIDs.Count > 1)
                    {
                        if (FormOps.QuestionBox("Are you sure you want to remove this student?\n\n" +
                        "Their grade, seat, and attendance records will be deleted.\n\n" +
                        "Pressing Cancel will not undo this."))
                        {
                            int studentID = Convert.ToInt32(registeredStudentIDs[lbxRegisteredStudents.SelectedIndex]),
                                courseID = Convert.ToInt32(tbxCourseID.Text);

                            ProgOps.RemoveStudentFromCourse(studentID, courseID);

                            ClearDataLists();

                            FillRegisteredStudentsListBox();

                            FillAvailableStudentsListBox();
                        }
                    }
                    else
                    {
                        FormOps.ErrorBox("Due to database limitations, you must have\n" +
                            "at least 1 student in the course in order for\n" +
                            "the course to have an assigned room.");
                    }
                }
                else
                {
                    FormOps.ErrorBox("Select a registered student to remove.");
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }
    }
}
