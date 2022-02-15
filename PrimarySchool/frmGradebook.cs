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
            FormOps.ShowModeless(home);
        }

        // Opens modal Assignments.
        private void mnuEditAssignments_Click(object sender, EventArgs e)
        {
            frmAssignments assignments = new frmAssignments(this);
            FormOps.ShowModal(assignments);
        }


        private void frmGradebook_Load(object sender, EventArgs e)
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
            DataTable gbTable = ProgOps.GetGradebookTable(selectedCourseID);

            dgvGradebook.DataSource = null;
            dgvGradebook.Rows.Clear();
            dgvGradebook.Columns.Clear();

            dgvGradebook.DataSource = gbTable;

            gbTable.Dispose();

            ConfigureDataGridView();
        }

        // Configures and enables the DataGridView.
        private void ConfigureDataGridView()
        {
            DataGridViewTextBoxColumn colFinal = new DataGridViewTextBoxColumn();

            colFinal.HeaderText = "Final";

            dgvGradebook.Columns.Add(colFinal);

            foreach (DataGridViewColumn column in dgvGradebook.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

                if (column.HeaderText.Equals("Student ID") || column.HeaderText.Equals("First Name") ||
                    column.HeaderText.Equals("Last Name") || column.HeaderText.Equals("Assignment") ||
                    column.HeaderText.Equals("Final"))
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

            ((DataGridViewTextBoxColumn)dgvGradebook.Columns["Grade"]).MaxInputLength = 3;
            ((DataGridViewTextBoxColumn)dgvGradebook.Columns["Comments"]).MaxInputLength = 255;

            dgvGradebook.Enabled = true;
        }
    }
}
