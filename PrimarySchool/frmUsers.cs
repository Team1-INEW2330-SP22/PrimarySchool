using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;             //using for beeps, sounds

namespace PrimarySchool
{
    public partial class frmUsers : Form
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
        public frmUsers(frmHome home)
        {
            this.home = home;
            InitializeComponent();
        }

        // Prevents closing of form during edits.
        // Closes and disposes of DB things (do later).
        // Shows Home.
        private void frmUsers_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (state.Equals("Edit") || state.Equals("Add New"))
                {
                    MessageBox.Show("You must finish the current edit before stopping the application.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
                else
                {
                    //Saves Changes before closing form
                    ProgOps.UpdateUserRecordsOnClose();
                    ProgOps.UserLoginObjectDisposal();
                    FormOps.ShowModeless(home);
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Closes Users.
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
                        tbxStreetAddress.ReadOnly = true;
                        tbxCity.ReadOnly = true;
                        tbxState.ReadOnly = true;
                        tbxZip.ReadOnly = true;
                        tbxPhone.ReadOnly = true;
                        btnFirst.Enabled = true;
                        btnLast.Enabled = true;
                        btnNext.Enabled = true;
                        btnPrevious.Enabled = true;
                        btnEdit.Enabled = true;
                        btnAddNew.Enabled = true;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;
                        gbxSearch.Enabled = true;
                        gbxCredentials.Enabled = false;
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
                        mnuCredentials.Enabled = false;
                        mnuSubmit.Enabled = false;
                        tbxLastName.Focus();
                        CheckDatabaseTies();
                        break;
                    // Acts as both 'Add New' and 'Edit' state.
                    default:
                        tbxLastName.ReadOnly = false;
                        tbxFirstName.ReadOnly = false;
                        tbxMiddleName.ReadOnly = false;
                        tbxDateOfBirth.ReadOnly = false;
                        tbxEmail.ReadOnly = false;
                        tbxStreetAddress.ReadOnly = false;
                        tbxCity.ReadOnly = false;
                        tbxState.ReadOnly = false;
                        tbxZip.ReadOnly = false;
                        tbxPhone.ReadOnly = false;
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
                        gbxCredentials.Enabled = true;
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
                        mnuCredentials.Enabled = true;
                        mnuSubmit.Enabled = true;
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
        private void frmUsers_Load(object sender, EventArgs e)
        {
            //Pointer to help file
            helpme.HelpNamespace = Application.StartupPath + "\\helpme.chm";

            //ProgOps.OpenDatabase();
            ProgOps.GetUserRecords(tbxUserID, tbxLastName, tbxFirstName, tbxMiddleName, tbxDateOfBirth,
                                    tbxStreetAddress, tbxCity, tbxState, tbxZip, tbxPhone, tbxRole, tbxUsername, tbxUserPassword, tbxEmail);
            //establish currency manager to control buttons previous and next
            manager = (CurrencyManager)this.BindingContext[ProgOps.DTUsersTable];
            //set state
            SetState("View");
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
            FormOps.ErrorBox("This shouldn't appear.");
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

                if (tbxEmail.Text.Trim().Equals(string.Empty))
                {
                    message = "You must enter an Email.";
                    tbxEmail.Focus();
                    allOK = false;
                }

                if (tbxStreetAddress.Text.Trim().Equals(string.Empty))
                {
                    message = "You must enter a Street Adress.";
                    tbxStreetAddress.Focus();
                    allOK = false;
                }

                if (tbxCity.Text.Trim().Equals(string.Empty))
                {
                    message = "You must enter a City.";
                    tbxCity.Focus();
                    allOK = false;
                }

                if (tbxState.Text.Trim().Equals(string.Empty))
                {
                    message = "You must enter State.";
                    tbxState.Focus();
                    allOK = false;
                }

                if (tbxZip.Text.Trim().Equals(string.Empty))
                {
                    message = "You must enter Zip.";
                    tbxZip.Focus();
                    allOK = false;
                }

                if (tbxPhone.Text.Trim().Equals(string.Empty))
                {
                    message = "You must enter Phone Number.";
                    tbxPhone.Focus();
                    allOK = false;
                }

                if (tbxRole.Text.Trim().Equals(string.Empty))
                {
                    message = "You must enter Role.";
                    tbxRole.Focus();
                    allOK = false;
                }

                if (tbxRole.Text.Trim().Equals("1") || tbxRole.Text.Trim().Equals("2")
                    || tbxRole.Text.Trim().Equals("3"))
                {

                }
                else
                {
                    message = "You must enter a number between 1 and 3 for Role.";
                    tbxRole.Focus();
                    allOK = false;
                }

                if (tbxUsername.Text.Trim().Equals(string.Empty))
                {
                    message = "You must enter a Username.";
                    tbxUsername.Focus();
                    allOK = false;
                }

                if (tbxUserPassword.Text.Trim().Equals(string.Empty))
                {
                    message = "You must enter a Password.";
                    tbxUserPassword.Focus();
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
            if (!ValidateData())
            {
                return;
            }


            //string savedName = tbxUserID.Text;
            //int savedRow;

            try
            {
                manager.EndCurrentEdit();

                CheckDatabaseTies();

                //ProgOps.DTUsersTable.DefaultView.Sort = "User_LName";

                //savedRow = ProgOps.DTUsersTable.DefaultView.Find(savedName);

                //manager.Position = savedRow;

                tbxUserPassword.PasswordChar = '*';

                MessageBox.Show("Record saved.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

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

                tbxUserPassword.PasswordChar = '*';

                CheckDatabaseTies();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbxSearch.Text.Equals(""))
            {
                return;
            }
            int savedRow = manager.Position;
            DataRow[] foundRows;
            ProgOps.DTUsersTable.DefaultView.Sort = "User_LName";
            foundRows = ProgOps.DTUsersTable.Select("User_LName LIKE '" + tbxSearch.Text + "*'");
            if (foundRows.Length == 0)
            {
                manager.Position = savedRow;
            }
            else
            {
                manager.Position = ProgOps.DTUsersTable.DefaultView.Find(foundRows[0]["User_LName"]);
            }
        }

        private void pbxEyeballUserPassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxUserPassword.PasswordChar.Equals('*'))
                {
                    tbxUserPassword.PasswordChar = '\0';
                }
                else
                {
                    tbxUserPassword.PasswordChar = '*';
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

        private void tbxUserID_TextChanged(object sender, EventArgs e)
        {
            CheckDatabaseTies();
        }

        private void CheckDatabaseTies()
        {
            try
            {
                if (!tbxUserID.Text.Equals(string.Empty))
                {
                    int userID = Convert.ToInt32(tbxUserID.Text);

                    DataTable courses = ProgOps.GetRegisteredCoursesForTeacher(userID);

                    if (courses.Rows.Count > 0 || tbxUserID.Text.Equals("1009"))
                    {
                        btnDelete.Enabled = false;
                        mnuDelete.Enabled = false;
                        tbxRole.Enabled = false;
                        tbxStatus.Text = "Not Active";
                    }
                    else
                    {
                        btnDelete.Enabled = true;
                        mnuDelete.Enabled = true;
                        tbxRole.Enabled = true;
                        tbxStatus.Text = "Active";
                    }

                    courses.Clear();
                    courses.Dispose();
                }
                else
                {
                    btnDelete.Enabled = false;
                    mnuDelete.Enabled = false;
                    tbxRole.Enabled = false;
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
