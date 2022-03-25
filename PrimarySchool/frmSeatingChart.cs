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
            FormOps.CloseForm(this);
        }

        // Brings back Home.
        private void frmSeatingChart_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!saved)
                {
                    if (FormOps.QuestionBox("Save changes before closing?" +
                        "\nIf not, the data will be reset."))
                    {
                        if (ValidateData())
                        {
                            // Update database.
                            ProgOps.UpdateSeatingChartTable(seatChartTable, changedRowsList,
                                selectedCourseID);
                        }
                        else
                        {
                            FormOps.ErrorBox("Failed to save changes");
                        }
                    }
                }

                ClearSeatChartDataTable();

                if (ProgOps.UserRole.Equals("Teacher"))
                {
                    ClearSeatList();
                    ClearChangedRowsList();
                }   

                FormOps.ShowModeless(home);
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

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

        // Populates cbxCourses with course names.
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
                        if (ValidateData())
                        {
                            // Update database.
                            ProgOps.UpdateSeatingChartTable(seatChartTable, changedRowsList,
                                selectedCourseID);
                        }
                        else
                        {
                            FormOps.ErrorBox("Failed to save changes");
                        }
                    }

                    SetSavedStatus(true);
                }

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
                        ClearSeatList();
                        FillSeatList();
                        ClearChangedRowsList();
                        InitializeChangedRowsList();
                    } 
                }
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

        // Fills DataGridView.
        private void FillDataGridView()
        {
            try
            {
                ClearSeatChartDataTable();

                seatChartTable = ProgOps.GetSeatingChartTable(selectedCourseID);

                dgvSeatingChart.DataSource = null;
                dgvSeatingChart.Rows.Clear();
                dgvSeatingChart.Columns.Clear();

                dgvSeatingChart.DataSource = seatChartTable;

                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void ClearSeatChartDataTable()
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

        // Configures and enables the DataGridView.
        private void ConfigureDataGridView()
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

        // Adds column headers to ListBox if ListBox is empty.
        // Clears ListBox, adds column headers, and rows if ListBox is not empty.
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
                    seatsListTable = null;
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void FillSeatList()
        {
            try
            {
                if ( seatChartTable != null && seatChartTable.Rows.Count > 0)
                {
                    seatList = new List<int>();

                    for (int x = 0; x < seatChartTable.Rows.Count; x++)
                    {
                        seatList.Add(Convert.ToInt32(seatChartTable.Rows[x][3]));
                    }
                }
            }
            catch(Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void ClearSeatList()
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

        // Randomizes the Seating Chart.
        private void RandomizeChart()
        {
            try
            {
                if (seatList != null && seatChartTable != null && 
                    seatChartTable.Rows.Count > 0)
                {
                    List<int> tempList = new List<int>();

                    for (int x = 0; x < seatList.Count; x++)
                    {
                        tempList.Add(seatList[x]);
                    }

                    Random rand = new Random();

                    // Based on Fisher-Yates shuffle **********

                    int seatCount = tempList.Count;

                    while (seatCount > 1)
                    {
                        seatCount--;

                        int randomSeat = rand.Next(seatCount + 1);

                        int value = tempList[randomSeat];

                        tempList[randomSeat] = tempList[seatCount];

                        tempList[seatCount] = value;
                    }

                    // ****************************************

                    for (int x = 0; x < seatChartTable.Rows.Count; x++)
                    {
                        seatChartTable.Rows[x][3] = tempList[x];
                    }

                    tempList.Clear();
                    tempList = null;

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

        // Calls RandomizeChart method.
        private void mnuEditRandomize_Click(object sender, EventArgs e)
        {
            try
            {
                RandomizeChart();

                if (seatChartTable != null)
                {
                    for (int x = 0; x < seatChartTable.Rows.Count; x++)
                    {
                        AddRowToChangedRowsList(x);
                    }
                } 
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
                if (seatChartTable != null && seatChartTable.Rows.Count > 0)
                {
                    for (int x = 0; x < seatChartTable.Rows.Count; x++)
                    {
                        seatChartTable.Rows[x][3] = DBNull.Value;
                    }

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

        private void mnuEditClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearModifiableData();

                if (seatChartTable != null)
                {
                    for (int x = 0; x < seatChartTable.Rows.Count; x++)
                    {
                        AddRowToChangedRowsList(x);
                    }
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
                if (seatList != null && seatChartTable != null && 
                    seatChartTable.Rows.Count > 0)
                {
                    for (int x = 0; x < seatChartTable.Rows.Count; x++)
                    {
                        seatChartTable.Rows[x][3] = seatList[x];
                    }

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

        private void mnuEditReset_Click(object sender, EventArgs e)
        {
            try
            {
                ResetModifiableData();
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
                if (seatChartTable != null)
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
                if (seatChartTable != null)
                {
                    int row = e.RowIndex;

                    AddRowToChangedRowsList(row);

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
                if (seatChartTable != null && seatChartTable.Rows.Count > 0)
                {
                    if (ValidateData())
                    {
                        // Update database.
                        ProgOps.UpdateSeatingChartTable(seatChartTable, changedRowsList,
                            selectedCourseID);

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

        private bool ValidateData()
        {
            try
            {
                if (seatChartTable != null)
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
                FormOps.ErrorBox("CheckUserInput: " + ex.Message);
                return false;
            }
        }

        private void InitializeChangedRowsList()
        {
            try
            {
                if (seatChartTable != null && seatChartTable.Rows.Count > 0)
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
                if (seatChartTable != null && changedRowsList != null 
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
    }
}