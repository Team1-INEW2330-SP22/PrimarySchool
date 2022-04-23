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
    public partial class frmAssignments : Form
    {
        // Creates 'gradebook' attribute so we can perform certain operations on Gradebook from Assignments...
        // ...doesn't initialize
        private frmGradebook gradebook;

        // Creates form level variable to hold selected course name
        private string courseName;

        // Creates form level variable to hold selected course ID
        private int selectedCourseID;

        // Creates 'state' attribute to hold current state
        private string state;

        // Creates currency manager
        private CurrencyManager manager;

        // Holds currency manager position
        private int bookmark;

        // Holds default value for tbxSearch
        private string strSearch = "Name";

        // Creates form level data table for categories
        //      Column [0]: Category_ID
        //      Column [1]: Category_Name
        //      Column [2]: Category_Weight
        private DataTable categoriesTable;

        // Initializes 'gradebook' attribute to parameter
        public frmAssignments(frmGradebook gradebook, string courseName, int selectedCourseID)
        {
            this.gradebook = gradebook;
            this.courseName = courseName;
            this.selectedCourseID = selectedCourseID;
            InitializeComponent();
        }

        // Closes Assignments
        private void mnuFileClose_Click(object sender, EventArgs e)
        {
            FormOps.CloseModal(this);
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
                        tbxAssignmentName.ReadOnly = true;
                        tbxCategory.ReadOnly = true;
                        tbxDescription.ReadOnly = true;
                        btnFirst.Enabled = true;
                        btnLast.Enabled = true;
                        btnNext.Enabled = true;
                        btnPrevious.Enabled = true;
                        btnEdit.Enabled = true;
                        btnAdd.Enabled = true;
                        btnRemove.Enabled = true;
                        btnCreate.Enabled = true;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;
                        gbxSearch.Enabled = true;
                        tbxSearch.ReadOnly = false;
                        btnSearch.Enabled = true;
                        mnuNavigation.Enabled = true;
                        mnuFirst.Enabled = true;
                        mnuLast.Enabled = true;
                        mnuNext.Enabled = true;
                        mnuPrevious.Enabled = true;
                        mnuEditRecord.Enabled = true;
                        mnuAdd.Enabled = true;
                        mnuSave.Enabled = false;
                        mnuRemove.Enabled = true;
                        mnuCancel.Enabled = false;
                        mnuSearch.Enabled = true;
                        tbxAssignmentName.Focus();
                        break;
                    // Acts as both 'Create New' and 'Edit' state
                    default:
                        tbxAssignmentName.ReadOnly = false;
                        tbxCategory.ReadOnly = false;
                        tbxDescription.ReadOnly = false;
                        btnFirst.Enabled = false;
                        btnLast.Enabled = false;
                        btnNext.Enabled = false;
                        btnPrevious.Enabled = false;
                        btnEdit.Enabled = false;
                        btnAdd.Enabled = false;
                        btnRemove.Enabled = false;
                        btnCreate.Enabled = false;
                        btnSave.Enabled = true;
                        btnCancel.Enabled = true;
                        gbxSearch.Enabled = false;
                        tbxSearch.ReadOnly = true;
                        btnSearch.Enabled = false;
                        mnuNavigation.Enabled = false;
                        mnuFirst.Enabled = false;
                        mnuLast.Enabled = false;
                        mnuNext.Enabled = false;
                        mnuPrevious.Enabled = false;
                        mnuEditRecord.Enabled = false;
                        mnuAdd.Enabled = false;
                        mnuSave.Enabled = true;
                        mnuRemove.Enabled = false;
                        mnuCancel.Enabled = true;
                        mnuSearch.Enabled = false;
                        tbxAssignmentName.Focus();
                        break;
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Calls Edit()
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        // Calls Cancel()
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        // Calls DB commmand
        // Fills currency manager
        // Sets state to 'View'
        private void frmAssignments_Load(object sender, EventArgs e)
        {
            try
            {
                tbxCourseName.Text = courseName;

                ProgOps.DatabaseCommandAssignments(tbxAssignmentID, tbxCategory,
                    tbxAssignmentName, tbxDescription);

                manager = (CurrencyManager)this.BindingContext[ProgOps.AssignmentsTable];

                FillCategoriesDataTable();

                FillListBox();

                SetState("View");
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Prevents closing of form during edits
        // Closes and disposes of DB things
        private void frmAssignments_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (state.Equals("Edit") || state.Equals("Create New"))
                {
                    FormOps.ErrorBox("You must finish the current edit before closing Assignments.");

                    e.Cancel = true;
                }
                else
                {
                    ClearCategoriesDataTable();

                    ProgOps.DisposeAssignments();
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

        // Calls GoToLast()
        private void btnLast_Click(object sender, EventArgs e)
        {
            GoToLast();
        }

        // Calls GoToPrevious()
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            GoToPrevious();
        }

        // Calls GoToNext()
        private void btnNext_Click(object sender, EventArgs e)
        {
            GoToNext();
        }

        // Calls Save()
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        // Calls GoToFirst()
        private void mnuFirst_Click(object sender, EventArgs e)
        {
            GoToFirst();
        }

        // Calls GoToFirst()
        private void mnuLast_Click(object sender, EventArgs e)
        {
            GoToLast();
        }

        // Calls GoToPrevious()
        private void mnuPrevious_Click(object sender, EventArgs e)
        {
            GoToPrevious();
        }

        // Calls GoToNext()
        private void mnuNext_Click(object sender, EventArgs e)
        {
            GoToNext();
        }

        // Calls Save()
        private void mnuSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        // Calls Cancel()
        private void mnuCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        // Calls CreateNew()
        private void mnuAddNew_Click(object sender, EventArgs e)
        {
            CreateNew();
        }

        // Calls Edit()
        private void mnuEditRecord_Click(object sender, EventArgs e)
        {
            Edit();
        }

        // Checks validity of edited/new data
        private bool ValidateData()
        {
            try
            {
                string message = "Invalid input detected.";

                bool allOK = true;

                if (tbxAssignmentName.Text.Trim().Equals(string.Empty))
                {
                    message = "You must enter a Name.";
                    tbxAssignmentName.Focus();
                    allOK = false;
                }

                if (tbxCategory.Text.Trim().Equals(string.Empty))
                {
                    message = "You must enter a Category ID.";
                    tbxCategory.Focus();
                    allOK = false;
                }

                List<int> categoryIDList = new List<int>();

                for (int x = 0; x < categoriesTable.Rows.Count; x++)
                {
                    categoryIDList.Add(Convert.ToInt32(categoriesTable.Rows[x][0]));
                }

                if (!categoryIDList.Contains(Convert.ToInt32(tbxCategory.Text.Trim())))
                {
                    message = "You must enter a valid Category ID.\n\n" +
                        "Review the list box on the right side of the form.";
                    tbxCategory.Focus();
                    categoryIDList.Clear();
                    allOK = false;
                }

                categoryIDList.Clear();

                if (tbxDescription.Text.Trim().Equals(string.Empty))
                {
                    message = "You must enter a Description.";
                    tbxDescription.Focus();
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
        // Updates database
        // Sorts by ID
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

                ProgOps.UpdateAssignments();

                ProgOps.AssignmentsTable.DefaultView.Sort = "Assignment_Name";

                MessageBox.Show("Record saved.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                SetState("View");
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Cancels current edit
        // Prevents error if user cancels before saving new record
        // Sets state to 'View'
        private void Cancel()
        {
            try
            {
                manager.CancelCurrentEdit();

                if (state.Equals("Create New"))
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
        // Set state to 'Create New'
        // Adds new record to data table
        private void CreateNew()
        {
            try
            {
                bookmark = manager.Position;

                SetState("Create New");

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

        private void FillCategoriesDataTable()
        {
            try
            {
                categoriesTable = ProgOps.GetCategoriesTable();
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void ClearCategoriesDataTable()
        {
            try
            {
                if (categoriesTable != null)
                {
                    categoriesTable.Clear();
                    categoriesTable.Dispose();
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Calls CreateNew()
        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateNew();
        }

        private void FillListBox()
        {
            try
            {
                if (categoriesTable != null)
                {
                    lbxCategories.Items.Add("Category ID - Category Name - Weight");
                    lbxCategories.Items.Add("");

                    for (int x = 0; x < categoriesTable.Rows.Count; x++)
                    {
                        lbxCategories.Items.Add(categoriesTable.Rows[x][0].ToString() +
                            " - " + categoriesTable.Rows[x][1].ToString() +
                            " - " + categoriesTable.Rows[x][2].ToString() + "%");
                    }
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Calls AddToCourse()
        private void mnuAdd_Click(object sender, EventArgs e)
        {
            AddToCourse();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddToCourse();
        }

        private void AddToCourse()
        {
            try
            {
                if (!tbxAssignmentID.Text.Trim().Equals(string.Empty))
                {
                    ProgOps.AddAssignmentToCourse(selectedCourseID, Convert.ToInt32(tbxAssignmentID.Text));
                }
                else
                {
                    FormOps.ErrorBox("Unable to add because the Assignment ID is not listed.\n\n" +
                        "To fix this, try again after closing and reopening Assignments.");
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void RemoveFromCourse()
        {
            try
            {
                if (!tbxAssignmentID.Text.Trim().Equals(string.Empty))
                {
                    ProgOps.RemoveAssignmentFromCourse(selectedCourseID, Convert.ToInt32(tbxAssignmentID.Text));
                }
                else
                {
                    FormOps.ErrorBox("Unable to remove because the Assignment ID is not listed.\n\n" +
                        "To fix this, try again after closing and reopening Assignments.");
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveFromCourse();
        }

        private void mnuRemove_Click(object sender, EventArgs e)
        {
            RemoveFromCourse();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
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

                ProgOps.AssignmentsTable.DefaultView.Sort = "Assignment_Name";

                foundRows = ProgOps.AssignmentsTable.Select("Assignment_Name LIKE '" + tbxSearch.Text + "*'");

                if (foundRows.Length == 0)
                {
                    manager.Position = savedRow;
                }
                else
                {
                    manager.Position = ProgOps.AssignmentsTable.DefaultView.Find(foundRows[0]["Assignment_Name"]);
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void mnuSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }
    }
}
