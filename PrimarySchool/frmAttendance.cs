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
    public partial class frmAttendance : Form
    {
        // Creates 'home' attribute so we can show Home again. Doesn't initialize.
        private frmHome home;

        // Creates global variable to hold selected course ID and sets it to 0.
        private int selectedCourseID = 0;

        // Initializes 'home' attribute to parameter.
        public frmAttendance(frmHome home)
        {
            this.home = home;
            InitializeComponent();
        }

        // Brings Home back upon closing Attendance.
        private void frmAttendance_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormOps.ShowModeless(home);
        }

        // Closes Attendance.
        private void mnuFileClose_Click(object sender, EventArgs e)
        {
            FormOps.CloseForm(this);
        }

        private void frmAttendance_Load(object sender, EventArgs e)
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

        // Populates cbxCourses with course names and cbxDate with dates.
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

                    DateTime date = new DateTime(2021, 9, 1);
                    DateTime endDate = new DateTime(2022, 6, 17);

                    DayOfWeek saturday = DayOfWeek.Saturday;
                    DayOfWeek sunday = DayOfWeek.Sunday;

                    do
                    {
                        if (date.DayOfWeek != saturday &&
                            date.DayOfWeek != sunday)
                        {
                            cbxDate.Items.Add(date.ToString("yyyy-MM-dd"));
                        }
                        date = date.AddDays(1);
                    } while (date <= endDate);

                    DayOfWeek weekday = DateTime.Now.DayOfWeek;
                    DateTime today = DateTime.Now;

                    if (weekday != saturday &&
                        weekday != sunday)
                    {
                        for (int x = 0; x < cbxDate.Items.Count; x++)
                        {
                            if (cbxDate.Items[x].Equals(today.ToString("yyyy-MM-dd")))
                            {
                                cbxDate.SelectedIndex = x;
                                lblDate.Text = cbxDate.Text;
                                break;
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

        // Fills labels.
        // Gets Course ID of selected course.
        // Calls FillDataGridView method.
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

                    FillDataGridView();
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Fills lblDate with selected date.
        // Calls FillDataGridView method.
        private void cbxDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = cbxDate.Text;
                FillDataGridView();
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
                        break;
                    default:
                        lblInstructor.Text = "[Instructor]";
                        mnuFileSave.Enabled = false;
                        mnuEdit.Enabled = false;
                        mnuEditClear.Enabled = false;
                        mnuEditReset.Enabled = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Fills dgvAttendance when both a course and a date have been selected.
        private void FillDataGridView()
        {
            if (!cbxCourses.Text.Equals(string.Empty) && !cbxDate.Text.Equals(string.Empty))
            {
                DataTable attendTable = ProgOps.GetAttendanceTable(selectedCourseID, cbxDate.Text);

                if (attendTable.Rows.Count == 0)
                {
                    dgvAttendance.DataSource = null;
                    dgvAttendance.Rows.Clear();
                    dgvAttendance.Columns.Clear();

                    ConfigureDataGridView(true);

                    DataTable studentsTable = ProgOps.GetStudentsInCourse(selectedCourseID);

                    if (dgvAttendance.Rows.Count > 0)
                    {
                        dgvAttendance.Rows.Clear();
                    }

                    for (int x = 0; x < studentsTable.Rows.Count; x++)
                    {
                        dgvAttendance.Rows.Add(new DataGridViewRow());
                        dgvAttendance.Rows[x].Cells[0].Value = studentsTable.Rows[x][0].ToString();
                        dgvAttendance.Rows[x].Cells[1].Value = studentsTable.Rows[x][1].ToString();
                        dgvAttendance.Rows[x].Cells[2].Value = studentsTable.Rows[x][2].ToString();
                        dgvAttendance.Rows[x].Cells[6].Value = cbxDate.Text;
                    }

                    studentsTable.Dispose();
                }
                else
                {
                    dgvAttendance.DataSource = null;
                    dgvAttendance.Rows.Clear();
                    dgvAttendance.Columns.Clear();
                    dgvAttendance.DataSource = attendTable;

                    ConfigureDataGridView(false);
                }

                attendTable.Dispose();
            }
        }

        // Configures and enables the DataGridView.
        private void ConfigureDataGridView(bool firstTime)
        {
            if (firstTime)
            {
                DataGridViewTextBoxColumn colStudentID = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn colFirstName = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn colLastName = new DataGridViewTextBoxColumn();

                DataGridViewCheckBoxColumn colPresent = new DataGridViewCheckBoxColumn();
                DataGridViewCheckBoxColumn colExcused = new DataGridViewCheckBoxColumn();

                DataGridViewTextBoxColumn colAbsenceReason = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn colDate = new DataGridViewTextBoxColumn();

                colStudentID.HeaderText = "Student ID";
                colFirstName.HeaderText = "First Name";
                colLastName.HeaderText = "Last Name";

                colPresent.HeaderText = "Present";
                colExcused.HeaderText = "Excused";

                colAbsenceReason.HeaderText = "Absence Reason";
                colDate.HeaderText = "Date";

                dgvAttendance.Columns.Add(colStudentID);
                dgvAttendance.Columns.Add(colFirstName);
                dgvAttendance.Columns.Add(colLastName);

                dgvAttendance.Columns.Add(colPresent);
                dgvAttendance.Columns.Add(colExcused);

                dgvAttendance.Columns.Add(colAbsenceReason);
                dgvAttendance.Columns.Add(colDate);
            }

            foreach (DataGridViewColumn column in dgvAttendance.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

                if (column.HeaderText.Equals("Student ID") || column.HeaderText.Equals("First Name") ||
                    column.HeaderText.Equals("Last Name") || column.HeaderText.Equals("Date"))
                {
                    column.ReadOnly = true;
                    column.Resizable = DataGridViewTriState.False;
                }

                if (column.HeaderText.Equals("Student ID"))
                {
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }

            dgvAttendance.Enabled = true;
        }
    }
}