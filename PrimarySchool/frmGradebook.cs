using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PrimarySchool
{
    public partial class frmGradebook : Form
    {
        // Creates 'home' attribute so we can show Home again. Doesn't initialize.
        private frmHome home;

        // Creates form level variable to hold selected course ID and sets it to 0.
        private int selectedCourseID = 0;

        // Creates form level data table to use for DataGridView DataSource.
        //      Column [0]: First Name
        //      Column [1]: Last Name
        //      Column [2]: Assignment
        //      Column [3]: Grade
        //      Column [4]: Comments
        private DataTable gradebookTable;

        // Creates form level data table for additional data to use in code.
        //      Column [0]: Student ID
        //      Column [1]: Assignment ID
        //      Column [2]: Category ID
        //      Column [3]: Category Weight
        private DataTable hiddenGradebookTable;

        // Lists to hold initial values for Grade and Comments.
        private List<double> gradeList;
        private List<string> commentsList;

        // List to hold changed rows.
        private List<int> changedRowsList;

        // Creates form level bool to indicate if current edits are saved.
        private bool saved;

        // Initializes 'home' attribute to parameter.
        public frmGradebook(frmHome home)
        {
            this.home = home;
            InitializeComponent();
        }

        // Closes Gradebook.
        private void mnuFileClose_Click(object sender, EventArgs e)
        {
            FormOps.CloseForm(this);
        }

        // Brings Home back upon closing Gradebook.
        private void frmGradebook_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!saved)
                {
                    if (FormOps.QuestionBox("Save changes before closing?" +
                        "\nIf not, the data will be reset."))
                    {
                        // Update database.
                        ProgOps.UpdateGradebookTable(gradebookTable, hiddenGradebookTable, 
                            changedRowsList, selectedCourseID);
                    }
                }

                ClearGradebookDataTables();

                if (ProgOps.UserRole.Equals("Teacher"))
                {
                    ClearGradeAndCommentsLists();
                    ClearChangedRowsList();
                }

                FormOps.ShowModeless(home);
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Opens modal Assignments.
        private void mnuEditAssignments_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxCourses.SelectedIndex >= 0)
                {
                    if (!saved)
                    {
                        if (FormOps.QuestionBox("Save changes before going to Assignments?" +
                            "\nIf not, the data will be reset."))
                        {
                            // Update database.
                            ProgOps.UpdateGradebookTable(gradebookTable, hiddenGradebookTable,
                                changedRowsList, selectedCourseID);
                        }
                        else
                        {
                            ResetModifiableData();
                        }

                        SetSavedStatus(true);
                    }

                    frmAssignments assignments = new frmAssignments(this, lblCourseName.Text, selectedCourseID);

                    FormOps.ShowModal(assignments);

                    LoadCourse();
                }
                else
                {
                    FormOps.ErrorBox("Choose a course before going to Assignments");
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }


        private void frmGradebook_Load(object sender, EventArgs e)
        {
            try
            {
                SetState(ProgOps.UserRole);

                FillComboBox();

                SetSavedStatus(true);
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Fills cbxCourses with course names.
        private void FillComboBox()
        {
            try
            {
                DataTable courseNamesTable = ProgOps.GetCourseNames();

                for (int x = 0; x < courseNamesTable.Rows.Count; x++)
                {
                    cbxCourses.Items.Add(courseNamesTable.Rows[x][0]);
                }

                courseNamesTable.Clear();
                courseNamesTable.Dispose();
                courseNamesTable = null;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Fills labels and calls FillDataGridView method.
        private void cbxCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!saved)
                {
                    if (FormOps.QuestionBox("Save changes before switching courses?" +
                        "\nIf not, the data will be reset."))
                    {
                        // Update database.
                        ProgOps.UpdateGradebookTable(gradebookTable, hiddenGradebookTable, 
                            changedRowsList, selectedCourseID);
                    }

                    SetSavedStatus(true);
                }

                LoadCourse();
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Sets form state based on user role.
        private void SetState(string role)
        {
            try
            {
                switch (role)
                {
                    case "Teacher":
                        lblInstructor.Text = ProgOps.UserFullName;
                        mnuFileSave.Enabled = true;
                        mnuEdit.Enabled = true;
                        mnuEditClear.Enabled = true;
                        mnuEditReset.Enabled = true;
                        mnuEditAssignments.Enabled = true;
                        break;
                    default:
                        lblInstructor.Text = "[Instructor]";
                        mnuFileSave.Enabled = false;
                        mnuEdit.Enabled = false;
                        mnuEditClear.Enabled = false;
                        mnuEditReset.Enabled = false;
                        mnuEditAssignments.Enabled = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Fills DataGridView.
        private void FillDataGridView()
        {
            try
            {
                ClearGradebookDataTables();

                FillGradebookDataTables();

                dgvGradebook.DataSource = null;
                dgvGradebook.Rows.Clear();
                dgvGradebook.Columns.Clear();

                dgvGradebook.DataSource = gradebookTable;

                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void FillGradebookDataTables()
        {
            try
            {
                gradebookTable = ProgOps.GetGradebookTable(selectedCourseID);

                hiddenGradebookTable = ProgOps.GetHiddenGradebookTable(selectedCourseID);
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void ClearGradebookDataTables()
        {
            try
            {
                if (gradebookTable != null)
                {
                    gradebookTable.Clear();
                    gradebookTable.Dispose();
                    gradebookTable = null;
                }

                if (hiddenGradebookTable != null)
                {
                    hiddenGradebookTable.Clear();
                    hiddenGradebookTable.Dispose();
                    hiddenGradebookTable = null;
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Configures and enables the DataGridView.
        private void ConfigureDataGridView()
        {
            try
            {
                foreach (DataGridViewColumn column in dgvGradebook.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;

                    if (ProgOps.UserRole.Equals("Teacher"))
                    {
                        if (column.HeaderText.Equals("First Name") || column.HeaderText.Equals("Last Name") || 
                            column.HeaderText.Equals("Assignment"))
                        {
                            column.ReadOnly = true;
                            column.Resizable = DataGridViewTriState.False;
                        }
                    }
                    else
                    {
                        column.ReadOnly = true;
                        column.Resizable = DataGridViewTriState.False;
                    }

                    if (column.HeaderText.Equals("Grade"))
                    {
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }

                ((DataGridViewTextBoxColumn)dgvGradebook.Columns["Grade"]).MaxInputLength = 6;
                ((DataGridViewTextBoxColumn)dgvGradebook.Columns["Comments"]).MaxInputLength = 255;

                dgvGradebook.Enabled = true;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void ClearModifiableData()
        {
            try
            {
                if (dgvGradebook.Rows.Count > 0)
                {
                    for (int x = 0; x < dgvGradebook.Rows.Count; x++)
                    {
                        gradebookTable.Rows[x][3] = DBNull.Value;
                        gradebookTable.Rows[x][4] = DBNull.Value;
                    }
                }
                else
                {
                    FormOps.ErrorBox("Nothing to clear");
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void InitializeChangedRowsList()
        {
            try
            {
                if (dgvGradebook.Rows.Count > 0)
                {
                    changedRowsList = new List<int>();
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void AddRowToChangedRowsList(int row)
        {
            try
            {
                if (!changedRowsList.Contains(row))
                {
                    changedRowsList.Add(row);
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void ClearChangedRowsList()
        {
            try
            {
                if (changedRowsList != null)
                {
                    changedRowsList.Clear();
                    changedRowsList = null;
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void FillGradeAndCommentsLists()
        {
            try
            {
                if (dgvGradebook.Rows.Count > 0)
                {
                    gradeList = new List<double>();
                    commentsList = new List<string>();

                    for (int x = 0; x < dgvGradebook.Rows.Count; x++)
                    {
                        if (dgvGradebook.Rows[x].Cells[3].Value == DBNull.Value)
                        {
                            gradeList.Add(-1);
                        }
                        else
                        {
                            gradeList.Add(Convert.ToDouble(dgvGradebook.Rows[x].Cells[3].Value));
                        }

                        if (dgvGradebook.Rows[x].Cells[4].Value == DBNull.Value)
                        {
                            commentsList.Add(string.Empty);
                        }
                        else
                        {
                            commentsList.Add(dgvGradebook.Rows[x].Cells[4].Value.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void ClearGradeAndCommentsLists()
        {
            try
            {
                if (gradeList != null)
                {
                    gradeList.Clear();
                    gradeList = null;
                }

                if (commentsList != null)
                {
                    commentsList.Clear();
                    commentsList = null;
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void ResetModifiableData()
        {
            try
            {
                if (gradeList != null && commentsList != null && dgvGradebook.Rows.Count > 0)
                {
                    for (int x = 0; x < dgvGradebook.Rows.Count; x++)
                    {
                        if (gradeList[x] < 0)
                        {
                            gradebookTable.Rows[x][3] = DBNull.Value;
                        }
                        else
                        {
                            gradebookTable.Rows[x][3] = gradeList[x].ToString();
                        }

                        dgvGradebook.Rows[x].Cells[3].Value = 
                            Convert.ToDouble(dgvGradebook.Rows[x].Cells[3].Value).ToString("F");

                        if (commentsList[x].Equals(string.Empty))
                        {
                            gradebookTable.Rows[x][4] = DBNull.Value;
                        }
                        else
                        {
                            gradebookTable.Rows[x][4] = commentsList[x];
                        }
                    }
                }
                else
                {
                    FormOps.ErrorBox("Nothing to reset");
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void mnuEditClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearModifiableData();

                SetSavedStatus(false);

                for (int x = 0; x < dgvGradebook.Rows.Count; x++)
                {
                    AddRowToChangedRowsList(x);
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void mnuEditReset_Click(object sender, EventArgs e)
        {
            try
            {
                ResetModifiableData();

                ClearChangedRowsList();
                InitializeChangedRowsList();

                if (saved)
                {
                    SetSavedStatus(false);
                }
                else
                {
                    SetSavedStatus(true);
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void dgvGradebook_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = e.RowIndex, column = e.ColumnIndex;

                if (column == 3)
                {
                    if (dgvGradebook.Rows[row].Cells[column].Value != DBNull.Value)
                    {
                        if (Convert.ToInt32(dgvGradebook.Rows[row].Cells[column].Value) < 0)
                        {
                            gradebookTable.Rows[row][column] = 0;
                        }
                    }
                }

                if (column == 4)
                {
                    if (dgvGradebook.Rows[row].Cells[column].Value.ToString().Trim().Equals(string.Empty))
                    {
                        gradebookTable.Rows[row][column] = DBNull.Value;
                    }
                    else
                    {
                        gradebookTable.Rows[row][column] = 
                            dgvGradebook.Rows[row].Cells[column].Value.ToString().Trim();
                    }
                }

                AddRowToChangedRowsList(row);

                SetSavedStatus(false);
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Update database
                ProgOps.UpdateGradebookTable(gradebookTable, hiddenGradebookTable, 
                    changedRowsList, selectedCourseID);

                SetSavedStatus(true);
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
            
        }

        private void SetSavedStatus(bool status)
        {
            try
            {
                saved = status;

                if (!saved)
                {
                    this.Text = "Primary School - Gradebook *";
                }
                else
                {
                    this.Text = "Primary School - Gradebook";
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void dgvGradebook_DataError(object sender, DataGridViewDataErrorEventArgs e)
        { 
            try
            {
                string columnName = dgvGradebook.CurrentCell.OwningColumn.Name;

                int row = dgvGradebook.CurrentCell.RowIndex, column = dgvGradebook.CurrentCell.ColumnIndex;

                FormOps.ErrorBox("Invalid data detected on row " + (row + 1).ToString() + " of the " + 
                    columnName + " column...\nPlease try again");

                gradebookTable.Rows[row][column] = DBNull.Value;

                SetSavedStatus(false);

                e.Cancel = true;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void CalculateFinalGrade()
        {
            try
            {
                if (dgvGradebook.Rows.Count > 0)
                {
                    lbxFinalGrades.Items.Clear();

                    int studentID = Convert.ToInt32(hiddenGradebookTable.Rows[0][0]);

                    string studentName = dgvGradebook.Rows[0].Cells[0].Value.ToString() + 
                        " " + dgvGradebook.Rows[0].Cells[1].Value.ToString();

                    double final = 0;

                    for (int x = 0; x < dgvGradebook.Rows.Count; x++)
                    {
                        if (studentID == Convert.ToInt32(hiddenGradebookTable.Rows[x][0]))
                        {
                            if (dgvGradebook.Rows[x].Cells[3].Value != DBNull.Value)
                            {
                                // Perform calculation
                                //final++;
                            }
                        }

                        if (studentID != Convert.ToInt32(hiddenGradebookTable.Rows[x][0]) || 
                            (x + 1) == dgvGradebook.Rows.Count)
                        {
                            lbxFinalGrades.Items.Add(studentName + ": " + final.ToString("F") + "%");

                            if ((x + 1) != dgvGradebook.Rows.Count)
                            {
                                studentID = Convert.ToInt32(hiddenGradebookTable.Rows[x][0]);

                                studentName = dgvGradebook.Rows[x].Cells[0].Value.ToString() + 
                                    " " + dgvGradebook.Rows[x].Cells[1].Value.ToString();

                                final = 0;

                                if (dgvGradebook.Rows[x].Cells[3].Value != DBNull.Value)
                                {
                                    // Perform calculation
                                    //final++;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void GenerateRandomGrades()
        {
            try
            {
                Random rand = new Random();

                for (int x = 0; x < dgvGradebook.Rows.Count; x++)
                {
                    gradebookTable.Rows[x][3] = Convert.ToDecimal(rand.Next(65, 100));
                    AddRowToChangedRowsList(x);
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void LoadCourse()
        {
            try
            {
                if (cbxCourses.SelectedIndex >= 0)
                {
                    lblCourseName.Text = cbxCourses.SelectedItem.ToString();

                    selectedCourseID = ProgOps.GetCourseID(lblCourseName.Text);

                    if (!ProgOps.UserRole.Equals("Teacher"))
                    {
                        lblInstructor.Text = ProgOps.GetInstructorName(selectedCourseID);
                    }

                    int roomID = ProgOps.GetRoomID(selectedCourseID);

                    if (roomID == 0)
                    {
                        lblRoom.Text = "Room Not Set";
                    }
                    else
                    {
                        lblRoom.Text = "Room " + roomID.ToString();
                    }

                    FillDataGridView();

                    if (ProgOps.UserRole.Equals("Teacher"))
                    {
                        ClearGradeAndCommentsLists();
                        FillGradeAndCommentsLists();
                        ClearChangedRowsList();
                        InitializeChangedRowsList();
                    }

                    CalculateFinalGrade();
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }
    }
}
