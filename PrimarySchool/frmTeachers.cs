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
    public partial class frmTeachers : Form
    {
        // Creates 'home' attribute so we can show Home again. Doesn't initialize.
        private frmHome home;

        // Creates 'state' attribute to hold current state.
        private string state;

        // Creates currency manager.
        private CurrencyManager manager;

        // Holds currency manager position.
        private int bookmark;

        // Holds default value for tbxSearch
        private string strSearch = "Last Name";

        // Initializes 'home' attribute to parameter.
        public frmTeachers(frmHome home)
        {
            this.home = home;
            InitializeComponent();
        }

        // Prevents closing of form during edits.
        // Closes and disposes of DB things.
        // Shows Home.
        private void frmTeachers_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (state.Equals("Edit") || state.Equals("Add New"))
                {
                    FormOps.ErrorBox("You must finish the current edit before closing Teachers.");
                    e.Cancel = true;
                }
                else
                {
                    ProgOps.UpdateTeacherRecordsOnClose();
                    ProgOps.DisposeTeachers();
                    FormOps.ShowModeless(home);
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Closes Teachers.
        private void mnuFileClose_Click(object sender, EventArgs e)
        {
            FormOps.CloseModeless(this);
        }

        // Sets program state based on parameter/argument.
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
                        tbxEmail.ReadOnly = true;
                        tbxAddress.ReadOnly = true;
                        tbxCity.ReadOnly = true;
                        tbxState.ReadOnly = true;
                        tbxZip.ReadOnly = true;
                        tbxPhone.ReadOnly = true;
                        btnAddCourse.Enabled = false;
                        btnRemoveCourse.Enabled = false;
                        btnFirst.Enabled = true;
                        btnLast.Enabled = true;
                        btnNext.Enabled = true;
                        btnPrevious.Enabled = true;
                        btnEdit.Enabled = true;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;
                        gbxSearch.Enabled = true;
                        mnuNavigation.Enabled = true;
                        mnuFirst.Enabled = true;
                        mnuLast.Enabled = true;
                        mnuNext.Enabled = true;
                        mnuPrevious.Enabled = true;
                        mnuEditRecord.Enabled = true;
                        mnuSave.Enabled = false;
                        mnuCancel.Enabled = false;
                        mnuSearch.Enabled = true;
                        mnuCourses.Enabled = false;
                        mnuAddCourse.Enabled = false;
                        mnuRemoveCourse.Enabled = false;
                        tbxLastName.Focus();
                        break;
                    // Acts as both 'Add New' and 'Edit' state.
                    default:
                        tbxLastName.ReadOnly = false;
                        tbxFirstName.ReadOnly = false;
                        tbxMiddleName.ReadOnly = false;
                        tbxDateOfBirth.ReadOnly = false;
                        tbxEmail.ReadOnly = false;
                        tbxAddress.ReadOnly = false;
                        tbxCity.ReadOnly = false;
                        tbxState.ReadOnly = false;
                        tbxZip.ReadOnly = false;
                        tbxPhone.ReadOnly = false;
                        btnAddCourse.Enabled = true;
                        btnRemoveCourse.Enabled = true;
                        btnFirst.Enabled = false;
                        btnLast.Enabled = false;
                        btnNext.Enabled = false;
                        btnPrevious.Enabled = false;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = true;
                        btnCancel.Enabled = true;
                        gbxSearch.Enabled = false;
                        mnuNavigation.Enabled = false;
                        mnuFirst.Enabled = false;
                        mnuLast.Enabled = false;
                        mnuNext.Enabled = false;
                        mnuPrevious.Enabled = false;
                        mnuEditRecord.Enabled = false;
                        mnuSave.Enabled = true;
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

        // Calls DB commmand (do later).
        // Fills currency manager (do later).
        // Sets state to 'View'.
        private void frmTeachers_Load(object sender, EventArgs e)
        {
            //ProgOps.OpenDatabase();
            ProgOps.TeachersCommand(tbxUserID, tbxLastName, tbxFirstName, tbxMiddleName, tbxDateOfBirth, tbxEmail,
                tbxAddress, tbxCity, tbxState, tbxZip, tbxPhone);
            //establish currency manager to control buttons previous and next
            manager = (CurrencyManager)this.BindingContext[ProgOps.DTTeachersTable];
            //set state
            SetState("View");
        }

        // Asks user if they are sure about deleting the chosen record.
        // Returns to form if 'no' selected.
        // Deletes record if 'yes' selected (commented).
        // Sets state to View.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        // Calls GoToFirst().
        private void btnFirst_Click(object sender, EventArgs e)
        {
            GoToFirst();
        }

        // Calls GoToLast().
        private void btnLast_Click(object sender, EventArgs e)
        {
            GoToLast();
        }

        // Calls GoToPrevious().
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            GoToPrevious();
        }

        // Calls GoToNext().
        private void btnNext_Click(object sender, EventArgs e)
        {
            GoToNext();
        }

        // Calls Cancel().
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        // Calls AddNew().
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddNew();
        }

        // Calls Edit().
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();

        }

        // Calls GoToFirst().
        private void mnuFirst_Click(object sender, EventArgs e)
        {
            GoToFirst();
        }

        // Calls GoToLast().
        private void mnuLast_Click(object sender, EventArgs e)
        {
            GoToLast();
        }

        // Calls GoToPrevious().
        private void mnuPrevious_Click(object sender, EventArgs e)
        {
            GoToPrevious();
        }

        // Calls GoToNext().
        private void mnuNext_Click(object sender, EventArgs e)
        {
            GoToNext();
        }

        // Calls Edit().
        private void mnuEditRecord_Click(object sender, EventArgs e)
        {
            Edit();
        }

        // Calls Save().
        private void mnuSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        // Calls Cancel().
        private void mnuCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        // Calls AddNew().
        private void mnuAddNew_Click(object sender, EventArgs e)
        {
            AddNew();
        }

        // Calls Delete().
        private void mnuDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        // Checks validity of edited/new data (do later).
        private bool ValidateData()
        {

            return false;
        }

        // Goes to first record and beeps (commented).
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

        // Goes to last record and beeps (commented).
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

        // Goes to previous record (commented).
        // Beeps when first record is reached (commented).
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

        // Goes to next record (commented).
        // Beeps when last record is reached (commented).
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

        // Calls ValidateData before saving.
        // Ends current edit (commented).
        // Sorts by ID (do later).
        // Informs user of successful save (commented).
        // Sets state to 'View'.
        private void Save()
        {
            //if (!ValidateData())
            //{
            //    return;
            //}

            string savedName = tbxUserID.Text;
            int savedRow;

            try
            {
                manager.EndCurrentEdit();
                ProgOps.DTTeachersTable.DefaultView.Sort = "User_LName";
                savedRow = ProgOps.DTTeachersTable.DefaultView.Find(savedName);

                manager.Position = savedRow;
                MessageBox.Show("Record Saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetState("View");
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Asks user if they are sure about deleting the chosen record.
        // Returns to form if 'no' selected.
        // Deletes record if 'yes' selected (commented).
        // Sets state to View.
        private void Delete()
        {
            if (!FormOps.QuestionBox("Are you sure you want to delete this user?"))
            {
                return;
            }
            else
            {
                try
                {
                    manager.RemoveAt(manager.Position);
                }
                catch (Exception ex)
                {
                    FormOps.ErrorBox(ex.Message);
                }
            }
            SetState("View");
        }

        // Cancels current edit (commented).
        // Prevents error if user cancels before saving new record (commented).
        // Sets state to 'View'.
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

        // Saves curreny manager position into bookmark variable (commented).
        // Set state to 'Add'.
        // Adds new record to data table (commented).
        // Sets correct ID (do later).
        private void AddNew()
        {
            try
            {
                bookmark = manager.Position;
                manager.AddNew();

                SetState("Add New");
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Sets state to 'Edit'.
        // Sets correct ID (do later).
        private void Edit()
        {
            SetState("Edit");

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbxSearch.Text.Equals(""))
            {
                return;
            }
            int savedRow = manager.Position;
            DataRow[] foundRows;
            ProgOps.DTTeachersTable.DefaultView.Sort = "User_LName";
            foundRows = ProgOps.DTTeachersTable.Select("User_LName LIKE '" + tbxSearch.Text + "*'");
            if (foundRows.Length == 0)
            {
                manager.Position = savedRow;
            }
            else
            {
                manager.Position = ProgOps.DTTeachersTable.DefaultView.Find(foundRows[0]["User_LName"]);
            }
        }

        private void FillAvailableCoursesListBox()
        {
            try
            {
                lbxAvailableCourses.Items.Clear();

                if (!tbxUserID.Text.Equals(string.Empty))
                {
                    DataTable coursesTable = ProgOps.GetAvailableCoursesForTeacher(); ;

                    if (coursesTable.Rows.Count > 0 && !tbxUserID.Text.Equals("1009"))
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
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox("FillAvailableCoursesListBox: " + ex.Message);
            }
        }

        private void FillRegisteredCoursesListBox()
        {
            try
            {
                lbxRegisteredCourses.Items.Clear();

                if (!tbxUserID.Text.Equals(string.Empty))
                {
                    DataTable coursesTable = ProgOps.GetRegisteredCoursesForTeacher(Convert.ToInt32(tbxUserID.Text));

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
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox("FillRegisteredCoursesListBox: " + ex.Message);
            }
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbxAvailableCourses.SelectedIndex >= 0)
                {
                    if (FormOps.QuestionBox("Are you sure you want to add this course?"))
                    {
                        int userID = Convert.ToInt32(tbxUserID.Text);

                        ProgOps.AddTeacherToCourse(userID, lbxAvailableCourses.SelectedItem.ToString());

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
                FormOps.ErrorBox("btnAddCourse_Click: " + ex.Message);
            }
        }

        private void btnRemoveCourse_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbxRegisteredCourses.SelectedIndex >= 0)
                {
                    if (!tbxUserID.Text.Equals("1009"))
                    {
                        if (FormOps.QuestionBox("Are you sure you want to remove this course?\n\n" +
                            "The teacher will no longer be associated with this course.\n\n" +
                            "Pressing Cancel will not undo this."))
                        {
                            ProgOps.RemoveTeacherFromCourse(lbxRegisteredCourses.SelectedItem.ToString());

                            FillRegisteredCoursesListBox();

                            FillAvailableCoursesListBox();
                        }
                    }
                    else
                    {
                        FormOps.ErrorBox("Cannot delete Placeholder Teacher.\n\n" +
                            "Due to database limitations, you must have\n" +
                            "a teacher assigned to each course in order\n" +
                            "for the course to exist.");
                    }
                }
                else
                {
                    FormOps.ErrorBox("Select a registered course to remove.");
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox("btnRemoveCourse_Click: " + ex.Message);
            }
        }

        private void tbxUserID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FillAvailableCoursesListBox();

                FillRegisteredCoursesListBox();
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
    }
}
