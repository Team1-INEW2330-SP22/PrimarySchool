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
        // Sometimes short-handed as "Data Lists".
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
                SaveYesOrNo("Save changes before closing?");

                ClearDataTables();

                if (ProgOps.UserRole.Equals("Teacher"))
                {
                    ClearDataLists();
                    ClearChangedRows();
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
                    SaveYesOrNo("Save changes before going to Assignments?");

                    frmAssignments assignments = new frmAssignments(this, lblCourseName.Text, selectedCourseID);

                    FormOps.ShowModal(assignments);

                    LoadCourse();
                }
                else
                {
                    FormOps.ErrorBox("Select a course before going to Assignments");
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
                SaveYesOrNo("Save changes before switching courses?");

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
                FillDataTables();

                SetSavedStatus(true);

                ClearDataGridView();

                if (CheckDataTables())
                {
                    dgvGradebook.DataSource = gradebookTable;

                    ConfigDataGridView();
                }
                else
                {
                    FormOps.ErrorBox("Data could not be found");
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void ClearDataGridView()
        {
            try
            {
                dgvGradebook.DataSource = null;
                dgvGradebook.Rows.Clear();
                dgvGradebook.Columns.Clear();
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void FillDataTables()
        {
            try
            {
                ClearDataTables();

                gradebookTable = ProgOps.GetGradebookTable(selectedCourseID);

                hiddenGradebookTable = ProgOps.GetHiddenGradebookTable(selectedCourseID);
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void ClearDataTables()
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
        private void ConfigDataGridView()
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

        private void ClearTableData()
        {
            try
            {
                if (CheckDataTables())
                {
                    for (int x = 0; x < gradebookTable.Rows.Count; x++)
                    {
                        gradebookTable.Rows[x][3] = DBNull.Value;
                        gradebookTable.Rows[x][4] = DBNull.Value;
                    }

                    AddAllToChangedRows();

                    SetSavedStatus(false);
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

        private void InitChangedRows()
        {
            try
            {
                if (CheckDataTables())
                {
                    ClearChangedRows();

                    changedRowsList = new List<int>();
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void AddToChangedRows(int row)
        {
            try
            {
                if (CheckDataTables()
                    && changedRowsList != null
                    && !changedRowsList.Contains(row))
                {
                    changedRowsList.Add(row);
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void ClearChangedRows()
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

        private void FillDataLists()
        {
            try
            {
                if (CheckDataTables())
                {
                    ClearDataLists();

                    gradeList = new List<double>();
                    commentsList = new List<string>();

                    for (int x = 0; x < gradebookTable.Rows.Count; x++)
                    {
                        if (gradebookTable.Rows[x][3] == DBNull.Value)
                        {
                            gradeList.Add(-1);
                        }
                        else
                        {
                            gradeList.Add(Convert.ToDouble(gradebookTable.Rows[x][3]));
                        }

                        if (gradebookTable.Rows[x][4] == DBNull.Value)
                        {
                            commentsList.Add(string.Empty);
                        }
                        else
                        {
                            commentsList.Add(gradebookTable.Rows[x][4].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void ClearDataLists()
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

        private void ResetTableData()
        {
            try
            {
                if (CheckDataTables() && gradeList != null && commentsList != null)
                {
                    for (int x = 0; x < gradebookTable.Rows.Count; x++)
                    {
                        if (gradeList[x] < 0)
                        {
                            gradebookTable.Rows[x][3] = DBNull.Value;
                        }
                        else
                        {
                            gradebookTable.Rows[x][3] = gradeList[x].ToString();
                        }

                        gradebookTable.Rows[x][3] = Convert.ToDouble(gradebookTable.Rows[x][3]).ToString("F");

                        if (commentsList[x].Equals(string.Empty))
                        {
                            gradebookTable.Rows[x][4] = DBNull.Value;
                        }
                        else
                        {
                            gradebookTable.Rows[x][4] = commentsList[x];
                        }
                    }

                    //InitChangedRows();

                    AddAllToChangedRows();

                    SetSavedStatus(false);
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
                ClearTableData();
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
                ResetTableData();
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
                if (CheckDataTables())
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
                            gradebookTable.Rows[row][column] = dgvGradebook.Rows[row].Cells[column].Value.ToString().Trim();
                        }
                    }

                    CalculateFinalGrades();

                    AddToChangedRows(row);

                    SetSavedStatus(false);
                }
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
                Save();
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
                if (CheckDataTables())
                {
                    string columnName = dgvGradebook.CurrentCell.OwningColumn.Name;

                    int row = dgvGradebook.CurrentCell.RowIndex, column = dgvGradebook.CurrentCell.ColumnIndex;

                    FormOps.ErrorBox("Invalid data detected on row " + (row + 1).ToString() + " of the " +
                        columnName + " column...\nPlease try again");

                    gradebookTable.Rows[row][column] = DBNull.Value;

                    SetSavedStatus(false);

                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void CalculateFinalGrades()
        {
            try
            {
                lbxFinalGrades.Items.Clear();

                if (CheckDataTables())
                {
                    int studentID = Convert.ToInt32(hiddenGradebookTable.Rows[0][0]);

                    List<int> tempStudentIdList = new List<int>();
                    List<int> tempCategoryIdList = new List<int>();
                    List<double> tempWeightList = new List<double>();
                    List<int> tempCountList = new List<int>();
                    List<double> tempPointsList = new List<double>();

                    List<int> studentIdList = new List<int>();
                    List<int> categoryIdList = new List<int>();
                    List<double> weightList = new List<double>();
                    List<int> countList = new List<int>();
                    List<double> pointsList = new List<double>();

                    List<double> dividedWeightList = new List<double>();

                    for (int x = 0; x < hiddenGradebookTable.Rows.Count; x++)
                    {
                        if (studentID == Convert.ToInt32(hiddenGradebookTable.Rows[x][0]))
                        {
                            if (!tempCategoryIdList.Contains(Convert.ToInt32(hiddenGradebookTable.Rows[x][2])))
                            {
                                tempStudentIdList.Add(Convert.ToInt32(hiddenGradebookTable.Rows[x][0]));
                                tempCategoryIdList.Add(Convert.ToInt32(hiddenGradebookTable.Rows[x][2]));
                                tempWeightList.Add(Convert.ToDouble(hiddenGradebookTable.Rows[x][3]));

                                if (gradebookTable.Rows[x][3] != DBNull.Value)
                                {
                                    tempCountList.Add(1);
                                    tempPointsList.Add(Convert.ToDouble(gradebookTable.Rows[x][3]));
                                }
                                else
                                {
                                    tempCountList.Add(0);
                                    tempPointsList.Add(0);
                                }
                            }
                            else
                            {
                                for (int y = 0; y < tempCategoryIdList.Count; y++)
                                {
                                    if (tempCategoryIdList[y] == Convert.ToInt32(hiddenGradebookTable.Rows[x][2])
                                        && gradebookTable.Rows[x][3] != DBNull.Value)
                                    {
                                        tempCountList[y]++;
                                        tempPointsList[y] += Convert.ToDouble(gradebookTable.Rows[x][3]);
                                    }
                                }
                            }
                        }

                        if (studentID != Convert.ToInt32(hiddenGradebookTable.Rows[x][0])
                            || (x + 1) == hiddenGradebookTable.Rows.Count)
                        {
                            for (int y = 0; y < tempCategoryIdList.Count; y++)
                            {
                                studentIdList.Add(tempStudentIdList[y]);
                                categoryIdList.Add(tempCategoryIdList[y]);
                                weightList.Add(tempWeightList[y]);
                                countList.Add(tempCountList[y]);
                                pointsList.Add(tempPointsList[y]);
                            }

                            tempStudentIdList.Clear();
                            tempCategoryIdList.Clear();
                            tempWeightList.Clear();
                            tempCountList.Clear();
                            tempPointsList.Clear();

                            if ((x + 1) != hiddenGradebookTable.Rows.Count)
                            {
                                studentID = Convert.ToInt32(hiddenGradebookTable.Rows[x][0]);

                                if (!tempCategoryIdList.Contains(Convert.ToInt32(hiddenGradebookTable.Rows[x][2])))
                                {
                                    tempStudentIdList.Add(Convert.ToInt32(hiddenGradebookTable.Rows[x][0]));
                                    tempCategoryIdList.Add(Convert.ToInt32(hiddenGradebookTable.Rows[x][2]));
                                    tempWeightList.Add(Convert.ToDouble(hiddenGradebookTable.Rows[x][3]));

                                    if (gradebookTable.Rows[x][3] != DBNull.Value)
                                    {
                                        tempCountList.Add(1);
                                        tempPointsList.Add(Convert.ToDouble(gradebookTable.Rows[x][3]));
                                    }
                                    else
                                    {
                                        tempCountList.Add(0);
                                        tempPointsList.Add(0);
                                    }
                                }
                                else
                                {
                                    for (int y = 0; y < tempCategoryIdList.Count; y++)
                                    {
                                        if (tempCategoryIdList[y] == Convert.ToInt32(hiddenGradebookTable.Rows[x][2])
                                            && gradebookTable.Rows[x][3] != DBNull.Value)
                                        {
                                            tempCountList[y]++;
                                            tempPointsList[y] += Convert.ToDouble(gradebookTable.Rows[x][3]);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    for (int x = 0; x < studentIdList.Count; x++)
                    {
                        dividedWeightList.Add(Convert.ToDouble(weightList[x] / countList[x]));
                    }

                    studentID = studentIdList[0];

                    double final = 0;

                    List<double> finalGradeList = new List<double>();

                    for (int x = 0; x < studentIdList.Count; x++)
                    {
                        if (studentID == studentIdList[x])
                        {
                            final += pointsList[x] * (dividedWeightList[x] * .01);
                        }

                        if (studentID != studentIdList[x] || (x + 1) == studentIdList.Count)
                        {
                            finalGradeList.Add(final);

                            if ((x + 1) != studentIdList.Count)
                            {
                                studentID = studentIdList[x];

                                final = 0;

                                if (studentID == studentIdList[x])
                                {
                                    final += pointsList[x] * (dividedWeightList[x] * .01);
                                }
                            }
                        }
                    }

                    studentID = Convert.ToInt32(hiddenGradebookTable.Rows[0][0]);

                    string studentName = gradebookTable.Rows[0][0].ToString().Substring(0, 1)
                        + ". " + gradebookTable.Rows[0][1].ToString();

                    List<string> studentNameList = new List<string>();

                    studentNameList.Add(studentName);

                    for (int x = 0; x < gradebookTable.Rows.Count; x++)
                    {
                        if (studentID != Convert.ToInt32(hiddenGradebookTable.Rows[x][0]))
                        {
                            studentID = Convert.ToInt32(hiddenGradebookTable.Rows[x][0]);

                            studentName = gradebookTable.Rows[x][0].ToString().Substring(0, 1)
                                + ". " + gradebookTable.Rows[x][1].ToString();

                            studentNameList.Add(studentName);
                        }
                    }

                    for (int x = 0; x < finalGradeList.Count; x++)
                    {
                        lbxFinalGrades.Items.Add(studentNameList[x]
                            + ": " + finalGradeList[x].ToString("F"));
                    }

                    tempStudentIdList.Clear();
                    tempStudentIdList = null;
                    tempCategoryIdList.Clear();
                    tempCategoryIdList = null;
                    tempWeightList.Clear();
                    tempWeightList = null;
                    tempCountList.Clear();
                    tempCountList = null;
                    tempPointsList.Clear();
                    tempPointsList = null;

                    studentIdList.Clear();
                    studentIdList = null;
                    categoryIdList.Clear();
                    categoryIdList = null;
                    weightList.Clear();
                    weightList = null;
                    countList.Clear();
                    countList = null;
                    pointsList.Clear();
                    pointsList = null;

                    dividedWeightList.Clear();
                    dividedWeightList = null;

                    finalGradeList.Clear();
                    finalGradeList = null;

                    studentNameList.Clear();
                    studentNameList = null;
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

                for (int x = 0; x < gradebookTable.Rows.Count; x++)
                {
                    gradebookTable.Rows[x][3] = Convert.ToDecimal(rand.Next(65, 100));

                    AddToChangedRows(x);
                }

                SetSavedStatus(false);
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
                        FillDataLists();
                        InitChangedRows();
                    }

                    CalculateFinalGrades();
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private bool CheckDataTables()
        {
            try
            {
                if (gradebookTable != null
                    && gradebookTable.Rows.Count > 0
                    && hiddenGradebookTable != null
                    && hiddenGradebookTable.Rows.Count > 0)
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

        private void Save()
        {
            try
            {
                if (CheckDataTables() && changedRowsList != null)
                {
                    ProgOps.UpdateGradebookTable(gradebookTable, hiddenGradebookTable,
                        changedRowsList, selectedCourseID);

                    InitChangedRows();

                    SetSavedStatus(true);
                }
                else
                {
                    FormOps.ErrorBox("Nothing to save");
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void SaveYesOrNo(string question)
        {
            try
            {
                if (!saved && CheckDataTables() && changedRowsList != null)
                {
                    if (FormOps.QuestionBox(question + "\nIf not, the data may be reset."))
                    {
                        ProgOps.UpdateGradebookTable(gradebookTable, hiddenGradebookTable,
                            changedRowsList, selectedCourseID);

                        InitChangedRows();

                        SetSavedStatus(true);
                    }
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            GenerateRandomGrades();
        }

        private void AddAllToChangedRows()
        {
            try
            {
                if (CheckDataTables())
                {
                    for (int x = 0; x < gradebookTable.Rows.Count; x++)
                    {
                        AddToChangedRows(x);
                    }
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void mnuFilePrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckDataTables())
                {
                    if (!saved)
                    {
                        FormOps.ErrorBox("Cannot print data that has not been saved");

                        SaveYesOrNo("Save then print?");

                        if (saved)
                        {
                            CrystalReports.crptGradebook report = new CrystalReports.crptGradebook();

                            report.SetDatabaseLogon("group1fa212330", "1645456");

                            report.SetParameterValue("selectedCourseID", selectedCourseID);

                            frmViewer viewer = new frmViewer();

                            viewer.crvViewer.ReportSource = null;

                            viewer.crvViewer.ReportSource = report;

                            viewer.ShowDialog();

                            viewer.crvViewer.ReportSource = null;

                            report.Dispose();
                            report = null;

                            viewer.Dispose();
                            viewer = null;
                        }
                    }
                    else
                    {
                        CrystalReports.crptGradebook report = new CrystalReports.crptGradebook();

                        report.SetDatabaseLogon("group1fa212330", "1645456");

                        report.SetParameterValue("selectedCourseID", selectedCourseID);

                        frmViewer viewer = new frmViewer();

                        viewer.crvViewer.ReportSource = null;

                        viewer.crvViewer.ReportSource = report;

                        viewer.ShowDialog();

                        viewer.crvViewer.ReportSource = null;

                        report.Dispose();
                        report = null;

                        viewer.Dispose();
                        viewer = null;
                    }
                }
                else
                {
                    FormOps.ErrorBox("Select a course before printing");
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }
    }
}