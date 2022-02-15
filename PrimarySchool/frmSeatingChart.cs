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
            FormOps.ShowModeless(home);
        }

        private void frmSeatingChart_Load(object sender, EventArgs e)
        {
            try
            {
                SetState(ProgOps.UserRole);
                PopulateComboBox();
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Populates cbxCourses with course names.
        private void PopulateComboBox()
        {
            try
            {
                if (ProgOps.UserRole.Equals("Teacher"))
                {
                    DataTable courseNamesTable = ProgOps.GetCourseNamesForTeacher();

                    for (int x = 0; x < courseNamesTable.Rows.Count; x++)
                    {
                        cbxCourses.Items.Add(courseNamesTable.Rows[x][0]);
                    }

                    courseNamesTable.Dispose();
                }
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
                if (ProgOps.UserRole.Equals("Teacher"))
                {
                    lblCourseName.Text = cbxCourses.SelectedItem.ToString();

                    selectedCourseID = ProgOps.GetCourseIDForTeacher(lblCourseName.Text);

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
                        lblTotalSeats.Text = roomID.ToString() + " Total Seats";
                    }

                    FillDataGridView();
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
            DataTable seatsTable = ProgOps.GetSeatingChartTable(selectedCourseID);

            dgvSeatingChart.DataSource = null;
            dgvSeatingChart.Rows.Clear();
            dgvSeatingChart.Columns.Clear();

            dgvSeatingChart.DataSource = seatsTable;

            seatsTable.Dispose();

            ConfigureDataGridView();
        }

        // Configures and enables the DataGridView.
        private void ConfigureDataGridView()
        {
            foreach (DataGridViewColumn column in dgvSeatingChart.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

                if (column.HeaderText.Equals("Student ID") || column.HeaderText.Equals("First Name") ||
                    column.HeaderText.Equals("Last Name"))
                {
                    column.ReadOnly = true;
                    column.Resizable = DataGridViewTriState.False;
                }

                if (column.HeaderText.Equals("Student ID") || column.HeaderText.Equals("Seat ID") ||
                    column.HeaderText.Equals("Row") || column.HeaderText.Equals("Number"))
                {
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }

            ((DataGridViewTextBoxColumn)dgvSeatingChart.Columns["Seat ID"]).MaxInputLength = 2;
            ((DataGridViewTextBoxColumn)dgvSeatingChart.Columns["Row"]).MaxInputLength = 2;
            ((DataGridViewTextBoxColumn)dgvSeatingChart.Columns["Row"]).MaxInputLength = 2;

            dgvSeatingChart.Enabled = true;
        }
    }
}