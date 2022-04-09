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
    public partial class frmSeatingChart : Form
    {
        // Creates 'home' attribute so we can show Home again. Doesn't initialize.
        private frmHome home;

        // Creates form level variable to hold selected course ID and sets it to 0.
        private int selectedCourseID = 0;

        // Creates form level data table to use for DataGridView DataSource.
        //      Column [0]: Student ID
        //      Column [1]: First Name
        //      Column [2]: Last Name
        //      Column [3]: Seat ID
        private DataTable seatChartTable;

        // List to hold initial Seat IDs in chart.
        // Sometimes short-handed as "Data List".
        private List<int> seatList;

        // List to hold changed rows.
        private List<int> changedRowsList;

        // Creates form level bool to indicate if current edits are saved.
        private bool saved;

        // Initializes 'home' attribute to parameter.
        public frmSeatingChart(frmHome home)
        {
            this.home = home;
            InitializeComponent();
        }

        // Closes Seating Chart.
        private void mnuFileClose_Click(object sender, EventArgs e)
        {
            FormOps.CloseModeless(this);
        }

        // Calls SaveYesOrNo method
        // Clears and disposes DataTable(s)
        // Checks if User Role is Teacher for if statement
        // --Clears data list(s)
        // --Clears list of changed rows
        // Brings back Home form
        private void frmSeatingChart_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SaveYesOrNo("Save changes before closing?");

                if (seatChartTable != null)
                {
                    seatChartTable.Clear();
                    seatChartTable.Dispose();
                }

                if (ProgOps.UserRole.Equals("Teacher"))
                {
                    if (seatList != null)
                    {
                        seatList.Clear();
                    }

                    if (changedRowsList != null)
                    {
                        changedRowsList.Clear();
                    }
                }

                FormOps.ShowModeless(home);
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Calls SetState method with User Role as argument
        // Calls FillComboBox method
        // Calls FillListBox method
        // Calls SetSavedStatus method with true argument
        private void frmSeatingChart_Load(object sender, EventArgs e)
        {
            try
            {
                SetState(ProgOps.UserRole);

                FillComboBox();

                FillListBox();

                SetSavedStatus(true);
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Calls ProgOps method GetCourseNames
        // Fills ComboBox with course names via for loop
        // Clears and disposes DataTable of course names
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
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Calls SaveYesOrNo method
        // Calls LoadCourse method
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
                        mnuEditRandomize.Enabled = true;
                        break;
                    default:
                        lblInstructor.Text = "[Instructor]";
                        mnuFileSave.Enabled = false;
                        mnuEdit.Enabled = false;
                        mnuEditClear.Enabled = false;
                        mnuEditReset.Enabled = false;
                        mnuEditRandomize.Enabled = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Calls FillDataTable(s) method
        // Calls SetSavedStatus method with true argument
        // Calls ClearDataGridView method
        // Calls CheckDataTables for if statement
        // --Sets DataGridView DataSource to seatChartTable if above true
        // --Calls ConfigDataGridView method
        // Displays error message if above false
        private void FillDataGridView()
        {
            try
            {
                FillDataTable();

                SetSavedStatus(true);

                ClearDataGridView();

                if (CheckDataTable())
                {
                    dgvSeatingChart.DataSource = seatChartTable;

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

        // Calls NullifyDataTable(s) method
        // Calls ProgOps GetSeatingChartTable method to fill seatChartTable
        private void FillDataTable()
        {
            try
            {
                NullifyDataTable();

                seatChartTable = ProgOps.GetSeatingChartTable(selectedCourseID);
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Checks that DataTable(s) is(are) not null in if statement(s)
        // --Clears, disposes, and makes DataTable(s) null if above true
        private void NullifyDataTable()
        {
            try
            {
                if (seatChartTable != null)
                {
                    seatChartTable.Clear();
                    seatChartTable.Dispose();
                    seatChartTable = null;
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Sets DataGridView data source to null
        // Clears DataGridView rows
        // Clears DataGridView columns
        private void ClearDataGridView()
        {
            try
            {
                dgvSeatingChart.DataSource = null;
                dgvSeatingChart.Rows.Clear();
                dgvSeatingChart.Columns.Clear();
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Configures DataGridView based on column information
        // Enables DataGridView
        private void ConfigDataGridView()
        {
            try
            {
                foreach (DataGridViewColumn column in dgvSeatingChart.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;

                    if (ProgOps.UserRole.Equals("Teacher"))
                    {
                        if (column.HeaderText.Equals("Student ID") || column.HeaderText.Equals("First Name") ||
                        column.HeaderText.Equals("Last Name"))
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


                    if (column.HeaderText.Equals("Student ID") || column.HeaderText.Equals("Seat ID"))
                    {
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }

                ((DataGridViewTextBoxColumn)dgvSeatingChart.Columns["Seat ID"]).MaxInputLength = 4;

                dgvSeatingChart.Enabled = true;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Adds column headers to ListBox if ListBox is empty
        // Clears ListBox, adds column headers, and rows if ListBox is not empty
        private void FillListBox()
        {
            try
            {
                if (lbxSeatList.Items.Count <= 0)
                {
                    lbxSeatList.Items.Add("Seat ID\tRow\tNumber");
                }
                else
                {
                    lbxSeatList.Items.Clear();

                    lbxSeatList.Items.Add("Seat ID\tRow\tNumber");

                    DataTable seatsListTable = ProgOps.GetSeatsList(selectedCourseID);

                    for (int x = 0; x < seatsListTable.Rows.Count; x++)
                    {
                        lbxSeatList.Items.Add(seatsListTable.Rows[x][0] + "\t" +
                            seatsListTable.Rows[x][1] + "\t" + seatsListTable.Rows[x][2]);
                    }

                    seatsListTable.Clear();
                    seatsListTable.Dispose();
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Calls CheckDataTable(s) for if statement
        // --Calls ClearDataList(s) if above true
        // --Initializes new data list(s)
        // --Uses for loop to fill data list(s) with data from DataTable
        private void FillDataList()
        {
            try
            {
                if (CheckDataTable())
                {
                    ClearDataList();

                    seatList = new List<int>();

                    for (int x = 0; x < seatChartTable.Rows.Count; x++)
                    {
                        seatList.Add(Convert.ToInt32(seatChartTable.Rows[x][3]));
                    }
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Checks if data list(s) are not null
        // --Clears and nulls data list(s) if above true
        private void ClearDataList()
        {
            try
            {
                if (seatList != null)
                {
                    seatList.Clear();
                    seatList = null;
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Randomizes the Seating Chart
        // (Based on Fisher-Yates shuffle)
        private void RandomizeChart()
        {
            try
            {
                if (seatList != null && CheckDataTable())
                {
                    List<int> tempList = new List<int>();

                    for (int x = 0; x < seatList.Count; x++)
                    {
                        tempList.Add(seatList[x]);
                    }

                    Random rand = new Random();

                    int seatCount = tempList.Count;

                    while (seatCount > 1)
                    {
                        seatCount--;

                        int randomSeat = rand.Next(seatCount + 1);

                        int value = tempList[randomSeat];

                        tempList[randomSeat] = tempList[seatCount];

                        tempList[seatCount] = value;
                    }

                    for (int x = 0; x < seatChartTable.Rows.Count; x++)
                    {
                        seatChartTable.Rows[x][3] = tempList[x];
                    }

                    tempList.Clear();

                    AddAllToChangedRows();

                    SetSavedStatus(false);
                }
                else
                {
                    FormOps.ErrorBox("Nothing to randomize");
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Calls RandomizeChart method
        private void mnuEditRandomize_Click(object sender, EventArgs e)
        {
            try
            {
                RandomizeChart();
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Calls CheckDataTable(s) for if statement
        // --Clears modifiable data in table, using for loop, if above true
        // --Calls AddAllToChangedRows method if above true
        // --Calls SetSavedStatus with false argument if above true
        // Displays error message if above false
        private void ClearTableData()
        {
            try
            {
                if (CheckDataTable())
                {
                    for (int x = 0; x < seatChartTable.Rows.Count; x++)
                    {
                        seatChartTable.Rows[x][3] = DBNull.Value;
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

        // Calls ClearTableData method
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

        // Calls CheckDataTable(s) for if statement
        // Checks if data list(s) is(are) not null for if statement
        // --Uses for loop to fill DataTable with data from data list(s) if above true
        // --Calls AddAllToChangedRows method
        // --Calls SetSavedStatus with false argument
        // Displays error message if above false
        private void ResetTableData()
        {
            try
            {
                if (seatList != null && CheckDataTable())
                {
                    for (int x = 0; x < seatChartTable.Rows.Count; x++)
                    {
                        seatChartTable.Rows[x][3] = seatList[x];
                    }

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

        // Calls ResetTableData method
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

        private void dgvSeatingChart_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                if (CheckDataTable())
                {
                    string columnName = dgvSeatingChart.CurrentCell.OwningColumn.Name;

                    int row = dgvSeatingChart.CurrentCell.RowIndex, column = dgvSeatingChart.CurrentCell.ColumnIndex;

                    FormOps.ErrorBox("Invalid data detected on row " + (row + 1).ToString() + " of the " +
                        columnName + " column...\nPlease try again");

                    seatChartTable.Rows[row][column] = DBNull.Value;

                    SetSavedStatus(false);

                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Sets saved status based on boolean parameter
        // If not saved, adds asterisk (*) to form text
        // If saved, sets form text to default value
        private void SetSavedStatus(bool status)
        {
            try
            {
                saved = status;

                if (!saved)
                {
                    this.Text = "Primary School - Seating Chart *";
                }
                else
                {
                    this.Text = "Primary School - Seating Chart";
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void dgvSeatingChart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CheckDataTable())
                {
                    int row = e.RowIndex;

                    AddToChangedRows(row);

                    SetSavedStatus(false);
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Calls Save method
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

        private bool ValidateData()
        {
            try
            {
                if (CheckDataTable())
                {
                    bool noNulls = true, correctRange = true, allUnique = true;

                    string errorMessage = "Invalid input detected";

                    for (int x = 0; x < seatChartTable.Rows.Count; x++)
                    {
                        if (seatChartTable.Rows[x][3] == DBNull.Value)
                        {
                            errorMessage = "Every student must be assigned a Seat ID";
                            noNulls = false;
                        }
                    }

                    if (noNulls)
                    {
                        int lowest = seatList.Min();

                        int highest = seatList.Max();

                        for (int x = 0; x < seatChartTable.Rows.Count; x++)
                        {
                            int value = Convert.ToInt32(seatChartTable.Rows[x][3]);

                            if (value < lowest || value > highest)
                            {
                                errorMessage = "Check that all Seat IDs are in the Seat List";
                                correctRange = false;
                                break;
                            }
                        }
                    }

                    if (noNulls && correctRange)
                    {
                        for (int x = 0; x < seatChartTable.Rows.Count; x++)
                        {
                            int value = Convert.ToInt32(seatChartTable.Rows[x][3]);

                            for (int y = 0; y < seatChartTable.Rows.Count; y++)
                            {
                                if (value == Convert.ToInt32(seatChartTable.Rows[y][3]) && y != x)
                                {
                                    errorMessage = "Check that no Seat IDs are repeated";
                                    allUnique = false;
                                    break;
                                }
                            }

                            if (!allUnique)
                            {
                                break;
                            }
                        }
                    }

                    if (noNulls && correctRange && allUnique)
                    {
                        return true;
                    }
                    else
                    {
                        FormOps.ErrorBox(errorMessage);
                        return false;
                    }
                }
                else
                {
                    FormOps.ErrorBox("Data table is null");
                    return false;
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox("ValidateData: " + ex.Message);
                return false;
            }
        }

        // Calls CheckDataTable(s) for if statement
        // --Calls ClearChangedRows if CheckDataTable(s) true
        // --Initializes new list of changes rows if CheckDataTable(s) true
        private void InitChangedRows()
        {
            try
            {
                if (CheckDataTable())
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

        // Calls CheckDataTable(s) for if statement
        // Checks if list of changed rows is not null for if statement
        // Checks if specified row is not contained in list of changed rows for if statement
        // --Adds specified row to list of changed rows if above true
        private void AddToChangedRows(int row)
        {
            try
            {
                if (CheckDataTable()
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

        // If list of changed rows is not null, clear the list and make it null
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

        // Checks cbxCourses selected index greater than or equal to 0
        // --Sets course name label to selected course
        // --Calls ProgOps method GetCourseID to fill selectedCourseID
        // --If User Role is not Teacher
        // ----Calls ProgOps method GetInstructorName for instructor name label
        // --Calls ProgOps method GetRoomID
        // --If Room ID equals 0
        // ----Set room label to Room Not Set
        // --Else
        // ----Set room label to Room ID
        // --Calls FillDataGridView method
        // --If User Role is Teacher
        // ----Calls FillDataList(s) method
        // ----Calls InitChangedRows method
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

                    int totalSeats = ProgOps.GetTotalSeats(selectedCourseID);

                    if (totalSeats == 0)
                    {
                        lblTotalSeats.Text = "Room Not Set";
                    }
                    else
                    {
                        lblTotalSeats.Text = totalSeats.ToString() + " Total Seats";
                    }

                    FillDataGridView();

                    FillListBox();

                    if (ProgOps.UserRole.Equals("Teacher"))
                    {
                        FillDataList();
                        InitChangedRows();
                    }
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Calls CheckDataTable(s) for if statement
        // Checks if list of changed rows is not null for if statement
        // --Call ProgOps UpdateGradebookTable method if above true
        // --Call SetSavedStatus method with true argument if above true
        // Display error message if above false
        private void Save()
        {
            try
            {
                if (CheckDataTable() && changedRowsList != null)
                {
                    if (ValidateData())
                    {
                        ProgOps.UpdateSeatingChartTable(seatChartTable, changedRowsList, selectedCourseID);

                        InitChangedRows();

                        SetSavedStatus(true);
                    }
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

        // Checks saved, CheckDataTable(s), and changedRowsList for if statement
        // --Prompts to save with yes or no question if above true (question is parameter)
        // ----Calls ValidateData method for if statement
        // ------Calls ProgOps UpdateGradebookTable method if above if users chooses yes
        // ------Calls InitChangedRows method if users chooses yes
        // ------Calls SetSavedStatus with true argument if users chooses yes
        // ----Displays error if above false
        private void SaveYesOrNo(string question)
        {
            try
            {
                if (!saved && CheckDataTable() && changedRowsList != null)
                {
                    if (FormOps.QuestionBox(question + "\nIf not, the data may be reset."))
                    {
                        if (ValidateData())
                        {
                            ProgOps.UpdateSeatingChartTable(seatChartTable, changedRowsList, selectedCourseID);

                            InitChangedRows();

                            SetSavedStatus(true);
                        }
                        else
                        {
                            FormOps.ErrorBox("Failed to save changes");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Returns true if DataTable(s) is(are) null and contain(s) more than 0 rows
        // Returns false if DataTable(s) is(are) not null or contain(s) 0 rows
        private bool CheckDataTable()
        {
            try
            {
                if (seatChartTable != null 
                    && seatChartTable.Rows.Count > 0)
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

        // Calls CheckDataTable(s) for if statement
        // --Calls AddToChangedRows with each row as argument in for loop
        private void AddAllToChangedRows()
        {
            try
            {
                if (CheckDataTable())
                {
                    for (int x = 0; x < seatChartTable.Rows.Count; x++)
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
                if (CheckDataTable())
                {
                    if (!saved)
                    {
                        FormOps.ErrorBox("Cannot print data that has not been saved");

                        SaveYesOrNo("Save then print?");

                        if (saved)
                        {
                            CrystalReports.crptSeatingChart report = new CrystalReports.crptSeatingChart();

                            report.SetDatabaseLogon("group1fa212330", "1645456");

                            report.SetParameterValue("selectedCourseID", selectedCourseID);

                            frmViewer viewer = new frmViewer();

                            viewer.crvViewer.ReportSource = null;

                            viewer.crvViewer.ReportSource = report;

                            FormOps.ShowModal(viewer);

                            report.Dispose();

                            viewer.Dispose();
                        }
                    }
                    else
                    {
                        CrystalReports.crptSeatingChart report = new CrystalReports.crptSeatingChart();

                        report.SetDatabaseLogon("group1fa212330", "1645456");

                        report.SetParameterValue("selectedCourseID", selectedCourseID);

                        frmViewer viewer = new frmViewer();

                        viewer.crvViewer.ReportSource = null;

                        viewer.crvViewer.ReportSource = report;

                        FormOps.ShowModal(viewer);

                        report.Dispose();

                        viewer.Dispose();
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