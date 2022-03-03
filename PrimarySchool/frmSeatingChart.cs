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

        // Creates global variable to hold selected course ID and sets it to 0.
        private int selectedCourseID = 0;

        // Creates global data table to use for DataGridView DataSource.
        private DataTable seatChartTable;

        // List to hold initial Seat IDs in chart.
        private List<int> seatList;

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
                ClearDataTable();

                if (ProgOps.UserRole.Equals("Teacher"))
                {
                    ClearList();
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
                        ClearList();

                        FillList();
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
                ClearDataTable();

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

        private void ClearDataTable()
        {
            try
            {
                if (seatChartTable != null)
                {
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

                ((DataGridViewTextBoxColumn)dgvSeatingChart.Columns["Seat ID"]).MaxInputLength = 2;

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

                    seatsListTable.Dispose();

                    seatsListTable = null;
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void FillList()
        {
            try
            {
                if (dgvSeatingChart.Rows.Count > 0)
                {
                    seatList = new List<int>();

                    for (int x = 0; x < dgvSeatingChart.Rows.Count; x++)
                    {
                        seatList.Add(Convert.ToInt32(dgvSeatingChart.Rows[x].Cells[3].Value));
                    }
                }
            }
            catch(Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void ClearList()
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
                if (seatList != null && dgvSeatingChart.Rows.Count > 0)
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

                    for (int x = 0; x < dgvSeatingChart.Rows.Count; x++)
                    {
                        dgvSeatingChart.Rows[x].Cells[3].Value = tempList[x];
                    }

                    tempList.Clear();

                    tempList = null;
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
            RandomizeChart();
        }

        private void ClearModifiable()
        {
            try
            {
                if (dgvSeatingChart.Rows.Count > 0)
                {
                    for (int x = 0; x < dgvSeatingChart.Rows.Count; x++)
                    {
                        dgvSeatingChart.Rows[x].Cells[3].Value = DBNull.Value;
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

        private void mnuEditClear_Click(object sender, EventArgs e)
        {
            ClearModifiable();
        }

        private void ResetModifiable()
        {
            try
            {
                if (seatList != null && dgvSeatingChart.Rows.Count > 0)
                {
                    for (int x = 0; x < dgvSeatingChart.Rows.Count; x++)
                    {
                        dgvSeatingChart.Rows[x].Cells[3].Value = seatList[x];
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
            ResetModifiable();
        }
    }
}