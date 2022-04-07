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

        // Creates form level variable to hold selected course ID and sets it to 0.
        private int selectedCourseID = 0;

        // Creates form level data table to use for DataGridView DataSource.
        //      Column [0]: Student ID
        //      Column [1]: First Name
        //      Column [2]: Last Name
        //      Column [3]: Present
        //      Column [4]: Excused
        //      Column [5]: Absence Reason
        //      Column [6]: Date
        private DataTable attendanceTable;

        // Lists to hold initial data values.
        private List<bool> presentList;
        private List<bool> excusedList;
        private List<string> reasonList;

        // List to hold changed rows.
        private List<int> changedRowsList;

        // Creates form level bool to indicate if current edits are saved.
        private bool saved;

        // Creates form level bool to indicate if current data is new.
        private bool newData;

        // Initializes 'home' attribute to parameter.
        public frmAttendance(frmHome home)
        {
            this.home = home;
            InitializeComponent();
        }

        // Brings Home back upon closing Attendance.
        private void frmAttendance_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SaveYesOrNo("Save changes before closing?");

                ClearDataTable();

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

        // Closes Attendance.
        private void mnuFileClose_Click(object sender, EventArgs e)
        {
            try
            {
                FormOps.CloseForm(this);
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void frmAttendance_Load(object sender, EventArgs e)
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

        // Populates cbxCourses with course names and cbxDate with dates.
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

                DateTime date = new DateTime(2021, 9, 1);
                DateTime endDate = new DateTime(2022, 6, 17);

                DayOfWeek saturday = DayOfWeek.Saturday;
                DayOfWeek sunday = DayOfWeek.Sunday;

                do
                {
                    if (date.DayOfWeek != saturday && date.DayOfWeek != sunday)
                    {
                        cbxDate.Items.Add(date.ToString("M/d/yyyy"));
                    }

                    date = date.AddDays(1);

                } while (date <= endDate);

                DayOfWeek weekday = DateTime.Now.DayOfWeek;
                DateTime today = DateTime.Now;

                if (weekday != saturday && weekday != sunday)
                {
                    for (int x = 0; x < cbxDate.Items.Count; x++)
                    {
                        if (cbxDate.Items[x].Equals(today.ToString("M/d/yyyy")))
                        {
                            cbxDate.SelectedIndex = x;
                            lblDate.Text = cbxDate.Text;
                            break;
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
                SaveYesOrNo("Save changes before switching courses?");

                LoadCourse();
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
                SaveYesOrNo("Save changes before switching dates?");

                LoadDate();
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
            try
            {
                if (!cbxCourses.Text.Equals(string.Empty) && !cbxDate.Text.Equals(string.Empty))
                {
                    ClearDataTable();

                    attendanceTable = ProgOps.GetAttendanceTable(selectedCourseID, cbxDate.Text);

                    if (attendanceTable.Rows.Count == 0)
                    {
                        newData = true;

                        ConfigDataGridView();

                        if (ProgOps.UserRole.Equals("Teacher"))
                        {
                            DataTable studentsTable = ProgOps.GetStudentsInCourse(selectedCourseID);

                            if (attendanceTable.Columns.Count > 0)
                            {
                                for (int x = 0; x < studentsTable.Rows.Count; x++)
                                {
                                    attendanceTable.Rows.Add(attendanceTable.NewRow());
                                    attendanceTable.Rows[x][0] = studentsTable.Rows[x][0];
                                    attendanceTable.Rows[x][1] = studentsTable.Rows[x][1].ToString();
                                    attendanceTable.Rows[x][2] = studentsTable.Rows[x][2].ToString();
                                    attendanceTable.Rows[x][3] = false;
                                    attendanceTable.Rows[x][4] = false;
                                    attendanceTable.Rows[x][5] = DBNull.Value;
                                    attendanceTable.Rows[x][6] = cbxDate.Text;
                                }
                            }

                            SetSavedStatus(false);

                            studentsTable.Clear();
                            studentsTable.Dispose();
                            studentsTable = null;
                        }
                    }
                    else
                    {
                        newData = false;

                        SetSavedStatus(true);

                        ClearDataGridView();

                        dgvAttendance.DataSource = attendanceTable;

                        ConfigDataGridView();
                    }
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
                if (ProgOps.UserRole.Equals("Teacher") && newData)
                {
                    if (attendanceTable == null)
                    {
                        attendanceTable = new DataTable();
                    }
                    else
                    {
                        ClearDataTable();
                        attendanceTable = new DataTable();
                    }

                    attendanceTable.Columns.Add("Student_ID", typeof(Int32));
                    attendanceTable.Columns.Add("First_Name", typeof(string));
                    attendanceTable.Columns.Add("Last_Name", typeof(string));
                    attendanceTable.Columns.Add("isPresent", typeof(bool));
                    attendanceTable.Columns.Add("isExcused", typeof(bool));
                    attendanceTable.Columns.Add("absenceReason", typeof(string));
                    attendanceTable.Columns.Add("Date", typeof(DateTime));

                    dgvAttendance.DataSource = attendanceTable;

                    dgvAttendance.Columns[0].HeaderText = "Student ID";
                    dgvAttendance.Columns[1].HeaderText = "First Name";
                    dgvAttendance.Columns[2].HeaderText = "Last Name";
                    dgvAttendance.Columns[3].HeaderText = "Present";
                    dgvAttendance.Columns[4].HeaderText = "Excused";
                    dgvAttendance.Columns[5].HeaderText = "Absence Reason";
                    dgvAttendance.Columns[6].HeaderText = "Date";
                }
                
                if (!ProgOps.UserRole.Equals("Teacher") && newData)
                {
                    ClearDataTable();

                    FormOps.ErrorBox("Attendance for this date has not been taken");
                }

                if (dgvAttendance.Columns.Count > 0)
                {
                    foreach (DataGridViewColumn column in dgvAttendance.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;

                        if (ProgOps.UserRole.Equals("Teacher"))
                        {
                            if (column.HeaderText.Equals("Student ID") || column.HeaderText.Equals("First Name") ||
                                column.HeaderText.Equals("Last Name") || column.HeaderText.Equals("Date"))
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

                        if (column.HeaderText.Equals("Student ID"))
                        {
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                    }

                    dgvAttendance.Enabled = true;
                }
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
                if (CheckDataTable())
                {
                    attendanceTable.Clear();
                    attendanceTable.Dispose();
                    attendanceTable = null;
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
                if (CheckDataTable())
                {
                    ClearDataLists();

                    presentList = new List<bool>();
                    excusedList = new List<bool>();
                    reasonList = new List<string>();

                    for (int x = 0; x < attendanceTable.Rows.Count; x++)
                    {
                        if (attendanceTable.Rows[x][3] == DBNull.Value)
                        {
                            presentList.Add(false);
                        }
                        else
                        {
                            presentList.Add(Convert.ToBoolean(attendanceTable.Rows[x][3]));
                        }

                        if (attendanceTable.Rows[x][4] == DBNull.Value)
                        {
                            excusedList.Add(false);
                        }
                        else
                        {
                            excusedList.Add(Convert.ToBoolean(attendanceTable.Rows[x][4]));
                        }

                        if (attendanceTable.Rows[x][5] == DBNull.Value)
                        {
                            reasonList.Add(string.Empty);
                        }
                        else
                        {
                            reasonList.Add(Convert.ToString(attendanceTable.Rows[x][5]));
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
                if (presentList != null)
                {
                    presentList.Clear();
                    presentList = null;
                }

                if (excusedList != null)
                {
                    excusedList.Clear();
                    excusedList = null;
                }

                if (reasonList != null)
                {
                    reasonList.Clear();
                    reasonList = null;
                }
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
                if (CheckDataTable())
                {
                    for (int x = 0; x < attendanceTable.Rows.Count; x++)
                    {
                        attendanceTable.Rows[x][3] = false;
                        attendanceTable.Rows[x][4] = false;
                        attendanceTable.Rows[x][5] = DBNull.Value;
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

        private void ResetTableData()
        {
            try
            {
                if (presentList != null 
                    && excusedList != null 
                    && reasonList != null 
                    && CheckDataTable())
                {
                    for (int x = 0; x < attendanceTable.Rows.Count; x++)
                    {
                        attendanceTable.Rows[x][3] = presentList[x];
                        attendanceTable.Rows[x][4] = excusedList[x];
                        attendanceTable.Rows[x][5] = reasonList[x];
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
                ResetTableData();

                InitChangedRows();

                SetSavedStatus(false);
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void dgvAttendance_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                if (CheckDataTable())
                {
                    string columnName = dgvAttendance.CurrentCell.OwningColumn.Name;

                    int row = dgvAttendance.CurrentCell.RowIndex, column = dgvAttendance.CurrentCell.ColumnIndex;

                    FormOps.ErrorBox("Invalid data detected on row " + (row + 1).ToString() + " of the " +
                        columnName + " column...\nPlease try again");

                    if (column == 3 || column == 4)
                    {
                        attendanceTable.Rows[row][column] = false;
                    }
                    else
                    {
                        attendanceTable.Rows[row][column] = DBNull.Value;
                    }

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
                    this.Text = "Primary School - Attendance *";
                }
                else
                {
                    this.Text = "Primary School - Attendance";
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

        private void dgvAttendance_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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

        private void ClearDataGridView()
        {
            try
            {
                dgvAttendance.DataSource = null;
                dgvAttendance.Rows.Clear();
                dgvAttendance.Columns.Clear();
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
                if (CheckDataTable())
                {
                    ClearChangedRows();

                    changedRowsList = new List<int>();

                    if (newData)
                    {
                        AddAllToChangedRows();
                    }
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

        private bool CheckDataTable()
        {
            try
            {
                if (attendanceTable != null
                    && attendanceTable.Rows.Count > 0)
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

        private void AddAllToChangedRows()
        {
            try
            {
                if (CheckDataTable())
                {
                    for (int x = 0; x < attendanceTable.Rows.Count; x++)
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

        private void Save()
        {
            try
            {
                if (CheckDataTable() && changedRowsList != null)
                {
                    if (newData)
                    {
                        ProgOps.InsertIntoAttendanceTable(attendanceTable, changedRowsList, selectedCourseID);

                        newData = false;
                    }
                    else
                    {
                        ProgOps.UpdateAttendanceTable(attendanceTable, changedRowsList, selectedCourseID);
                    }

                    SetSavedStatus(true);

                    InitChangedRows();
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
                if (!saved
                    && cbxCourses.SelectedIndex >= 0
                    && CheckDataTable()
                    && changedRowsList != null)
                {
                    if (FormOps.QuestionBox(question + "\nIf not, the data may be reset."))
                    {
                        if (newData)
                        {
                            ProgOps.InsertIntoAttendanceTable(attendanceTable, changedRowsList, selectedCourseID);

                            newData = false;

                            SetSavedStatus(true);

                            InitChangedRows();
                        }
                        else
                        {
                            ProgOps.UpdateAttendanceTable(attendanceTable, changedRowsList, selectedCourseID);

                            SetSavedStatus(true);

                            InitChangedRows();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void LoadDate()
        {
            try
            {
                if (cbxDate.SelectedIndex >= 0)
                {
                    lblDate.Text = cbxDate.Text;

                    FillDataGridView();

                    if (ProgOps.UserRole.Equals("Teacher"))
                    {
                        FillDataLists();
                        InitChangedRows();
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
                            CrystalReports.crptAttendance report = new CrystalReports.crptAttendance();

                            report.SetDatabaseLogon("group1fa212330", "1645456");

                            report.SetParameterValue("selectedCourseID", selectedCourseID);

                            DateTime date = Convert.ToDateTime(attendanceTable.Rows[0][6]);

                            report.SetParameterValue("date", date.ToString("yyyy-MM-dd"));

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
                        CrystalReports.crptAttendance report = new CrystalReports.crptAttendance();

                        report.SetDatabaseLogon("group1fa212330", "1645456");

                        report.SetParameterValue("selectedCourseID", selectedCourseID);

                        DateTime date = Convert.ToDateTime(attendanceTable.Rows[0][6]);

                        report.SetParameterValue("date", date.ToString("yyyy-MM-dd"));

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
                    FormOps.ErrorBox("Select a valid course/date combination before printing");
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }
    }
}