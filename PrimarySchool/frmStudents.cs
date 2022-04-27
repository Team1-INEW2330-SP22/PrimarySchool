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

/*
 * Application: Primary School
 * Group: Team 1
 * Names: Tyler Anderson, Max Cancino, Ryan Hicks
 * Date: 4/27/2022
 * Course: INEW-2330-7Z1
 * Semester: SP/22
 */

namespace PrimarySchool
{
    public partial class frmStudents : Form
    {
        // Creates 'home' attribute so we can show Home again...
        // ...doesn't initialize
        private frmHome home;

        // Creates 'state' attribute to hold current state
        private string state;

        // Creates currency manager
        private CurrencyManager manager;

        // Holds currency manager position
        private int bookmark;

        // Holds default value for tbxSearch
        private string strSearch = "Last Name";

        // Initializes 'home' attribute to parameter
        public frmStudents(frmHome home)
        {
            this.home = home;
            InitializeComponent();
        }

        // Prevents closing of form during edits
        // Updates database
        // Closes and disposes of DB objects
        // Shows Home
        private void frmStudents_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (state.Equals("Edit") || state.Equals("Add New"))
                {
                    FormOps.ErrorBox("You must finish the current edit before closing Students.");

                    e.Cancel = true;
                }
                else
                {
                    ProgOps.DisposeStudents();

                    FormOps.ShowModeless(home);
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Closes Students
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
                        tbxLastName.ReadOnly = true;
                        tbxFirstName.ReadOnly = true;
                        tbxMiddleName.ReadOnly = true;
                        tbxDateOfBirth.ReadOnly = true;
                        tbxAddress.ReadOnly = true;
                        tbxCity.ReadOnly = true;
                        tbxState.ReadOnly = true;
                        tbxZip.ReadOnly = true;
                        tbxG1Name.ReadOnly = true;
                        tbxG1CellPhone.ReadOnly = true;
                        tbxG1WorkPhone.ReadOnly = true;
                        tbxG1PlaceOfWork.ReadOnly = true;
                        tbxG2Name.ReadOnly = true;
                        tbxG2CellPhone.ReadOnly = true;
                        tbxG2WorkPhone.ReadOnly = true;
                        tbxG2PlaceOfWork.ReadOnly = true;
                        tbxEC.ReadOnly = true;
                        tbxEcCellPhone.ReadOnly = true;
                        btnAddCourse.Enabled = false;
                        btnRemoveCourse.Enabled = false;
                        btnFirst.Enabled = true;
                        btnLast.Enabled = true;
                        btnNext.Enabled = true;
                        btnPrevious.Enabled = true;
                        btnEdit.Enabled = true;
                        btnAddNew.Enabled = true;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;
                        gbxSearch.Enabled = true;
                        mnuNavigation.Enabled = true;
                        mnuFirst.Enabled = true;
                        mnuLast.Enabled = true;
                        mnuNext.Enabled = true;
                        mnuPrevious.Enabled = true;
                        mnuEditRecord.Enabled = true;
                        mnuAddNew.Enabled = true;
                        mnuSave.Enabled = false;
                        mnuCancel.Enabled = false;
                        mnuSearch.Enabled = true;
                        mnuCourses.Enabled = false;
                        mnuAddCourse.Enabled = false;
                        mnuRemoveCourse.Enabled = false;
                        tbxLastName.Focus();
                        CheckDatabaseTies();
                        break;
                    // Acts as both 'Add New' and 'Edit' state
                    default:
                        tbxLastName.ReadOnly = false;
                        tbxFirstName.ReadOnly = false;
                        tbxMiddleName.ReadOnly = false;
                        tbxDateOfBirth.ReadOnly = false;
                        tbxAddress.ReadOnly = false;
                        tbxCity.ReadOnly = false;
                        tbxState.ReadOnly = false;
                        tbxZip.ReadOnly = false;
                        tbxG1Name.ReadOnly = false;
                        tbxG1CellPhone.ReadOnly = false;
                        tbxG1WorkPhone.ReadOnly = false;
                        tbxG1PlaceOfWork.ReadOnly = false;
                        tbxG2Name.ReadOnly = false;
                        tbxG2CellPhone.ReadOnly = false;
                        tbxG2WorkPhone.ReadOnly = false;
                        tbxG2PlaceOfWork.ReadOnly = false;
                        tbxEC.ReadOnly = false;
                        tbxEcCellPhone.ReadOnly = false;
                        btnAddCourse.Enabled = true;
                        btnRemoveCourse.Enabled = true;
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
                        mnuCourses.Enabled = true;
                        mnuAddCourse.Enabled = true;
                        mnuRemoveCourse.Enabled = true;
                        tbxLastName.Focus();
                        break;
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
        private void frmStudents_Load(object sender, EventArgs e)
        {
            //Pointer to help file
            helpme.HelpNamespace = Application.StartupPath + "\\helpme.chm";

            try
            {
                ProgOps.DatabaseCommandStudents(tbxStudentID, tbxLastName, tbxFirstName, tbxMiddleName,
                tbxDateOfBirth, tbxAddress, tbxCity, tbxState, tbxZip,
                tbxG1Name, tbxG1CellPhone, tbxG1WorkPhone, tbxG1PlaceOfWork,
                tbxG2Name, tbxG2CellPhone, tbxG2WorkPhone, tbxG2PlaceOfWork,
                tbxEC, tbxEcCellPhone);

                manager = (CurrencyManager)this.BindingContext[ProgOps.StudentsTable];

                SetState("View");
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

                if (tbxLastName.Text.Trim().Equals(string.Empty))
                {
                    message = "You must enter a Last Name.";
                    tbxLastName.Focus();
                    allOK = false;
                }

                if (tbxFirstName.Text.Trim().Equals(string.Empty))
                {
                    message = "You must enter a First Name.";
                    tbxFirstName.Focus();
                    allOK = false;
                }

                if (tbxMiddleName.Text.Trim().Equals(string.Empty))
                {
                    message = "You must enter a Middle Name.";
                    tbxMiddleName.Focus();
                    allOK = false;
                }

                if (tbxDateOfBirth.Text.Trim().Equals(string.Empty))
                {
                    message = "You must enter a Date of Birth.";
                    tbxDateOfBirth.Focus();
                    allOK = false;
                }

                if (tbxAddress.Text.Trim().Equals(string.Empty))
                {
                    message = "You must enter an Address.";
                    tbxAddress.Focus();
                    allOK = false;
                }

                if (tbxCity.Text.Trim().Equals(string.Empty))
                {
                    message = "You must enter a City.";
                    tbxCity.Focus();
                    allOK = false;
                }

                if (tbxZip.Text.Trim().Equals(string.Empty))
                {
                    message = "You must enter a Zip Code.";
                    tbxZip.Focus();
                    allOK = false;
                }

                if (tbxG1Name.Text.Trim().Equals(string.Empty))
                {
                    message = "You must enter Guardian 1 Name.";
                    tbxG1Name.Focus();
                    allOK = false;
                }

                if (tbxG1CellPhone.Text.Trim().Equals(string.Empty))
                {
                    message = "You must enter Guardian 1 Cell Phone.";
                    tbxG1CellPhone.Focus();
                    allOK = false;
                }

                if (tbxG1WorkPhone.Text.Trim().Equals(string.Empty))
                {
                    message = "You must enter Guardian 1 Work Phone.";
                    tbxG1WorkPhone.Focus();
                    allOK = false;
                }

                if (tbxG1PlaceOfWork.Text.Trim().Equals(string.Empty))
                {
                    message = "You must enter Guardian 1 Place of Work.";
                    tbxG1PlaceOfWork.Focus();
                    allOK = false;
                }

                if (tbxEC.Text.Trim().Equals(string.Empty))
                {
                    message = "You must enter an Emergency Contact.";
                    tbxEC.Focus();
                    allOK = false;
                }

                if (tbxEcCellPhone.Text.Trim().Equals(string.Empty))
                {
                    message = "You must enter Emergency Contact Cell Phone.";
                    tbxEcCellPhone.Focus();
                    allOK = false;
                }

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
        // Sorts by Last Name
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

                ProgOps.UpdateStudents();

                CheckDatabaseTies();

                ProgOps.StudentsTable.DefaultView.Sort = "Last_Name";

                MessageBox.Show("Record saved", "Success",
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
            if (!FormOps.QuestionBox("Are you sure you want to delete this student?\n\n" +
                "They will be deleted from the database entirely,\n" +
                "an action which cannot be undone."))
            {
                return;
            }
            else
            {
                try
                {
                    ProgOps.DeleteStudentFromAncillaryTables(Convert.ToInt32(tbxStudentID.Text));

                    manager.RemoveAt(manager.Position);

                    ProgOps.UpdateStudents();
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

                CheckDatabaseTies();
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

                manager.AddNew();
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

                ProgOps.StudentsTable.DefaultView.Sort = "Last_Name";

                foundRows = ProgOps.StudentsTable.Select("Last_Name LIKE '" + tbxSearch.Text + "*'");

                if (foundRows.Length == 0)
                {
                    manager.Position = savedRow;
                }
                else
                {
                    manager.Position = ProgOps.StudentsTable.DefaultView.Find(foundRows[0]["Last_Name"]);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void mnuSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void FillRegisteredCoursesListBox()
        {
            try
            {
                lbxRegisteredCourses.Items.Clear();

                if (!tbxStudentID.Text.Equals(string.Empty))
                {
                    DataTable coursesTable = ProgOps.GetRegisteredCoursesForStudent(Convert.ToInt32(tbxStudentID.Text));

                    if (coursesTable.Rows.Count > 0)
                    {
                        lblRegisteredCourses.Text = "Registered Courses (" + coursesTable.Rows.Count.ToString() + ")";

                        for (int x = 0; x < coursesTable.Rows.Count; x++)
                        {
                            lbxRegisteredCourses.Items.Add(coursesTable.Rows[x][0]);
                        }
                    }
                    else
                    {
                        lblRegisteredCourses.Text = "Registered Courses (0)";
                    }

                    coursesTable.Clear();
                    coursesTable.Dispose();
                }
                else
                {
                    lblRegisteredCourses.Text = "Registered Courses (0)";
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void FillAvailableCoursesListBox()
        {
            try
            {
                lbxAvailableCourses.Items.Clear();

                if (!tbxStudentID.Text.Equals(string.Empty))
                {
                    DataTable coursesTable = ProgOps.GetAvailableCoursesForStudent(Convert.ToInt32(tbxStudentID.Text));

                    if (coursesTable.Rows.Count > 0)
                    {
                        lblAvailableCourses.Text = "Available Courses (" + coursesTable.Rows.Count.ToString() + ")";

                        for (int x = 0; x < coursesTable.Rows.Count; x++)
                        {
                            lbxAvailableCourses.Items.Add(coursesTable.Rows[x][0]);
                        }
                    }
                    else
                    {
                        lblAvailableCourses.Text = "Available Courses (0)";
                    }

                    coursesTable.Clear();
                    coursesTable.Dispose();
                }
                else
                {
                    lblAvailableCourses.Text = "Available Courses (0)";
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void tbxStudentID_TextChanged(object sender, EventArgs e)
        {
            CheckDatabaseTies();

            FillRegisteredCoursesListBox();

            FillAvailableCoursesListBox();
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbxAvailableCourses.SelectedIndex >= 0)
                {
                    if (FormOps.QuestionBox("Are you sure you want to add this course?"))
                    {
                        int courseID = ProgOps.GetCourseID(lbxAvailableCourses.SelectedItem.ToString()),
                            studentID = Convert.ToInt32(tbxStudentID.Text);

                        ProgOps.AddStudentToCourse(studentID, courseID);

                        FillRegisteredCoursesListBox();

                        FillAvailableCoursesListBox();
                    }
                }
                else
                {
                    FormOps.ErrorBox("Select an available course to add.");
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void btnRemoveCourse_Click(object sender, EventArgs e)
        {
            if (lbxRegisteredCourses.SelectedIndex >= 0)
            {
                int courseID = ProgOps.GetCourseID(lbxRegisteredCourses.SelectedItem.ToString());

                DataTable studentsTable = ProgOps.GetStudentsInCourse(courseID);

                if (studentsTable.Rows.Count > 1)
                {
                    if (FormOps.QuestionBox("Are you sure you want to remove this course?\n\n" +
                        "The student's grade, seat, and attendance records will be deleted for this course.\n\n" +
                        "Pressing Cancel will not undo this."))
                    {
                        int studentID = Convert.ToInt32(tbxStudentID.Text);

                        ProgOps.RemoveStudentFromCourse(studentID, courseID);

                        FillRegisteredCoursesListBox();

                        FillAvailableCoursesListBox();
                    }
                }
                else
                {
                    FormOps.ErrorBox("This the last student in the course.\n\n" +
                        "Due to database limitations, you must have\n" +
                        "at least 1 student in the course in order for\n" +
                        "the course to have an assigned room.");
                }

                studentsTable.Clear();
                studentsTable.Dispose();
            }
            else
            {
                FormOps.ErrorBox("Select a registered course to remove.");
            }
        }

        private void CheckDatabaseTies()
        {
            try
            {
                if (!tbxStudentID.Text.Equals(string.Empty))
                {
                    int studentID = Convert.ToInt32(tbxStudentID.Text);

                    DataTable courses = ProgOps.GetRegisteredCoursesForStudent(studentID);

                    if (courses.Rows.Count > 0)
                    {
                        btnDelete.Enabled = false;
                        mnuDelete.Enabled = false;
                        tbxStatus.Text = "Not Active";
                    }
                    else
                    {
                        btnDelete.Enabled = true;
                        mnuDelete.Enabled = true;
                        tbxStatus.Text = "Active";
                    }

                    courses.Clear();
                    courses.Dispose();
                }
                else
                {
                    btnDelete.Enabled = false;
                    mnuDelete.Enabled = false;
                    tbxStatus.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void mnuHelpInstructions_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpme.HelpNamespace);
        }
    }
}
