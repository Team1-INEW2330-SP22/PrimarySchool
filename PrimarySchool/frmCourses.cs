using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        // Initializes 'home' attribute to parameter.
        public frmCourses(frmHome home)
        {
            this.home = home;
            InitializeComponent();
        }
        
        // Calls DB commmand (do later).
        // Fills currency manager (do later).
        // Sets state to 'View'.
        private void frmCourses_Load(object sender, EventArgs e)
        {


            SetState("View");
        }

        // Prevents closing of form during edits.
        // Closes and disposes of DB things (do later).
        // Shows Home.
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

                    FormOps.ShowModeless(home);
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Closes Courses.
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
                        tbxCourseName.ReadOnly = true;
                        tbxSubject.ReadOnly = true;
                        tbxTeacher.ReadOnly = true;
                        tbxRoom.ReadOnly = true;
                        tbxCapacity.ReadOnly = true;
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
                        tbxSearch.ReadOnly = true;
                        btnSearch.Enabled = true;
                        gbxStudents.Enabled = false;
                        lbxAvailableStudents.Enabled = false;
                        lbxCourseStudents.Enabled = false;
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
                    // Acts as both 'Add New' and 'Edit' state.
                    default:
                        tbxCourseName.ReadOnly = false;
                        tbxSubject.ReadOnly = false;
                        tbxTeacher.ReadOnly = false;
                        tbxRoom.ReadOnly = false;
                        tbxCapacity.ReadOnly = false;
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
                        tbxSearch.ReadOnly = false;
                        btnSearch.Enabled = false;
                        gbxStudents.Enabled = true;
                        lbxAvailableStudents.Enabled = true;
                        lbxCourseStudents.Enabled = true;
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

        // Calls GoToFirst().
        private void btnFirst_Click(object sender, EventArgs e)
        {
            GoToFirst();
        }

        // Calls GoToFirst().
        private void mnuFirst_Click(object sender, EventArgs e)
        {
            GoToFirst();
        }

        // Calls GoToLast().
        private void btnLast_Click(object sender, EventArgs e)
        {
            GoToLast();
        }

        // Calls GoToLast().
        private void mnuLast_Click(object sender, EventArgs e)
        {
            GoToLast();
        }

        // Calls GoToPrevious().
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            GoToPrevious();
        }

        // Calls GoToPrevious().
        private void mnuPrevious_Click(object sender, EventArgs e)
        {
            GoToPrevious();
        }

        // Calls GoToNext();
        private void btnNext_Click(object sender, EventArgs e)
        {
            GoToNext();
        }

        // Calls GoToNext();
        private void mnuNext_Click(object sender, EventArgs e)
        {
            GoToNext();
        }

        // Calls Edit().
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        // Calls Edit().
        private void mnuEditRecord_Click(object sender, EventArgs e)
        {
            Edit();
        }

        // Calls Save().
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        // Calls Save().
        private void mnuSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        // Calls Cancel().
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        // Calls Cancel().
        private void mnuCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        // Calls AddNew().
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddNew();
        }

        // Calls AddNew().
        private void mnuAddNew_Click(object sender, EventArgs e)
        {
            AddNew();
        }

        // Calls Delete().
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
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
                //manager.Position = 0;
                //SystemSounds.Beep.Play();
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
                //manager.Position = manager.Count - 1;
                //SystemSounds.Beep.Play();
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
                //if (manager.Position == 0)
                //{
                //    SystemSounds.Beep.Play();
                //}
                //manager.Position--;
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
                //if (manager.Position == manager.Count - 1)
                //{
                //    SystemSounds.Beep.Play();
                //}
                //manager.Position++;
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
            if (!ValidateData())
            {
                return;
            }

            try
            {
                //manager.EndCurrentEdit();

                //MessageBox.Show("Record saved.", "Save",
                //    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (!FormOps.QuestionBox("Are you sure you want to delete this course?"))
            {
                return;
            }
            else
            {
                try
                {
                    //manager.RemoveAt(manager.Position);
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
            //try
            //{
            //    manager.CancelCurrentEdit();
            //    if (state.Equals("Add New"))
            //    {
            //        manager.Position = bookmark;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    FormOps.ErrorBox(ex.Message);
            //}
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
                //bookmark = manager.Position;
                SetState("Add New");
                //manager.AddNew();

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
    }
}
