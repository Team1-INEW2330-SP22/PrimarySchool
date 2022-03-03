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

        // Creates global variable to hold selected course ID and sets it to 0.
        private int selectedCourseID = 0;

        // Creates global data table to use for DataGridView DataSource.
        private DataTable gradebookTable;

        // Lists to hold initial values for Grade and Comments.
        private List<double> gradeList;
        private List<string> commentsList;

        // Creates global bool to indicate if current edits are saved.
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

                    }
                }

                ClearDataTable();

                if (ProgOps.UserRole.Equals("Teacher"))
                {
                    ClearLists();
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
                if (!saved)
                {
                    if (FormOps.QuestionBox("Save changes before going to Assignments?" +
                        "\nIf not, the data will be reset."))
                    {
                        // Update database.

                    }
                    else
                    {
                        ResetModifiable();
                    }

                    SetSavedStatus(true);
                }

                frmAssignments assignments = new frmAssignments(this);

                FormOps.ShowModal(assignments);
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

                    FillDataGridView();

                    if (ProgOps.UserRole.Equals("Teacher"))
                    {
                        ClearLists();

                        FillLists();
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
                ClearDataTable();

                gradebookTable = ProgOps.GetGradebookTable(selectedCourseID);

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

        private void ClearDataTable()
        {
            try
            {
                if (gradebookTable != null)
                {
                    gradebookTable.Dispose();

                    gradebookTable = null;
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
                DataGridViewTextBoxColumn colFinal = new DataGridViewTextBoxColumn();

                colFinal.HeaderText = "Final";

                dgvGradebook.Columns.Add(colFinal);

                foreach (DataGridViewColumn column in dgvGradebook.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;

                    if (ProgOps.UserRole.Equals("Teacher"))
                    {
                        if (column.HeaderText.Equals("Student ID") || column.HeaderText.Equals("First Name") ||
                        column.HeaderText.Equals("Last Name") || column.HeaderText.Equals("Assignment") ||
                        column.HeaderText.Equals("Final"))
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

                    if (column.HeaderText.Equals("Student ID") || column.HeaderText.Equals("Grade") ||
                        column.HeaderText.Equals("Final"))
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

        private void ClearModifiable()
        {
            try
            {
                if (dgvGradebook.Rows.Count > 0)
                {
                    for (int x = 0; x < dgvGradebook.Rows.Count; x++)
                    {
                        dgvGradebook.Rows[x].Cells[4].Value = DBNull.Value;

                        dgvGradebook.Rows[x].Cells[5].Value = DBNull.Value;

                        dgvGradebook.Rows[x].Cells[6].Value = DBNull.Value;
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

        private void FillLists()
        {
            try
            {
                if (dgvGradebook.Rows.Count > 0)
                {
                    gradeList = new List<double>();
                    commentsList = new List<string>();

                    for (int x = 0; x < dgvGradebook.Rows.Count; x++)
                    {
                        if (dgvGradebook.Rows[x].Cells[4].Value == DBNull.Value)
                        {
                            gradeList.Add(-1);
                        }
                        else if (dgvGradebook.Rows[x].Cells[4].Value != DBNull.Value)
                        {
                            gradeList.Add(Convert.ToDouble(dgvGradebook.Rows[x].Cells[4].Value));
                        }

                        if (dgvGradebook.Rows[x].Cells[5].Value == DBNull.Value)
                        {
                            commentsList.Add(string.Empty);
                        }
                        else if (dgvGradebook.Rows[x].Cells[5].Value != DBNull.Value)
                        {
                            commentsList.Add(Convert.ToString(dgvGradebook.Rows[x].Cells[5].Value));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void ClearLists()
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

        private void ResetModifiable()
        {
            try
            {
                if (gradeList != null && commentsList != null && dgvGradebook.Rows.Count > 0)
                {
                    for (int x = 0; x < dgvGradebook.Rows.Count; x++)
                    {
                        if (gradeList[x] <= -1)
                        {
                            dgvGradebook.Rows[x].Cells[4].Value = DBNull.Value;
                        }
                        else if (gradeList[x] > -1)
                        {
                            dgvGradebook.Rows[x].Cells[4].Value = gradeList[x].ToString("F");
                        }

                        if (commentsList[x].Equals(string.Empty))
                        {
                            dgvGradebook.Rows[x].Cells[5].Value = DBNull.Value;
                        }
                        else if (!commentsList[x].Equals(string.Empty))
                        {
                            dgvGradebook.Rows[x].Cells[5].Value = commentsList[x];
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
            ClearModifiable();
        }

        private void mnuEditReset_Click(object sender, EventArgs e)
        {
            ResetModifiable();

            SetSavedStatus(true);
        }

        private void dgvGradebook_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            SetSavedStatus(false);
        }

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            SetSavedStatus(true);
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
    }
}
