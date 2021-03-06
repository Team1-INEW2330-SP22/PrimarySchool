using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Application: Primary School
 * Group: Team 1
 * Names: Tyler Anderson, Max Cancino, Ryan Hicks
 * Date: 4/27/2022
 * Course: INEW-2330-7Z1
 * Semester: SP/22
 */

namespace PrimarySchool
{
    public partial class frmHome : Form
    {
        // Creates 'login' attribute so we can show Login again. Doesn't initialize.
        private frmLogin login;

        // Initializes 'login' attribute to parameter.
        public frmHome(frmLogin login)
        {
            this.login = login;
            InitializeComponent();
        }

        // Closes Home.
        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Resets Login and shows Login.
        private void mnuFileLogOut_Click(object sender, EventArgs e)
        {
            FormOps.CloseModeless(this);
        }

        // Closes Login when the Home screen is closed.
        private void frmHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProgOps.LogOut();
            login.Reset();
            FormOps.ShowModeless(login);
        }

        // Hides Home and opens Gradebook.
        private void mnuTeacherGradebook_Click(object sender, EventArgs e)
        {
            frmGradebook gradebook = new frmGradebook(this);
            FormOps.ShowModelessAndHide(gradebook, this);
        }

        // Hides Home and opens Attendance.
        private void mnuTeacherAttendance_Click(object sender, EventArgs e)
        {
            frmAttendance attendance = new frmAttendance(this);
            FormOps.ShowModelessAndHide(attendance, this);
        }

        // Shows modal About.
        private void mnuHelpAbout_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            FormOps.ShowModal(about);
        }

        // Hides Home and opens Seating Chart.
        private void mnuTeacherSeatingChart_Click(object sender, EventArgs e)
        {
            frmSeatingChart seatingChart = new frmSeatingChart(this);
            FormOps.ShowModelessAndHide(seatingChart, this);
        }

        // Hides Home and opens Teachers.
        private void mnuOfficerTeachers_Click(object sender, EventArgs e)
        {
            frmTeachers teachers = new frmTeachers(this);
            FormOps.ShowModelessAndHide(teachers, this);
        }

        // Hides Home and opens Students.
        private void mnuOfficerStudents_Click(object sender, EventArgs e)
        {
            frmStudents students = new frmStudents(this);
            FormOps.ShowModelessAndHide(students, this);
        }

        // Hides Home and opens Courses.
        private void mnuOfficerCourses_Click(object sender, EventArgs e)
        {
            frmCourses courses = new frmCourses(this);
            FormOps.ShowModelessAndHide(courses, this);
        }

        // Hides Home and opens Users.
        private void mnuAdminUsers_Click(object sender, EventArgs e)
        {
            frmUsers users = new frmUsers(this);
            FormOps.ShowModelessAndHide(users, this);
        }

        // Sets program state based on user role.
        private void SetState(string role)
        {
            try
            {
                switch (role)
                {
                    case "Teacher":
                        mnuTeacher.Enabled = true;
                        mnuTeacherGradebook.Enabled = true;
                        mnuTeacherAttendance.Enabled = true;
                        mnuTeacherSeatingChart.Enabled = true;
                        mnuOfficer.Enabled = false;
                        mnuOfficerTeachers.Enabled = false;
                        mnuOfficerStudents.Enabled = false;
                        mnuOfficerCourses.Enabled = false;
                        mnuAdmin.Enabled = false;
                        mnuAdminUsers.Enabled = false;
                        break;
                    case "Academic Officer":
                        mnuTeacher.Enabled = false;
                        mnuTeacherGradebook.Enabled = false;
                        mnuTeacherAttendance.Enabled = false;
                        mnuTeacherSeatingChart.Enabled = false;
                        mnuOfficer.Enabled = true;
                        mnuOfficerTeachers.Enabled = true;
                        mnuOfficerStudents.Enabled = true;
                        mnuOfficerCourses.Enabled = true;
                        mnuAdmin.Enabled = false;
                        mnuAdminUsers.Enabled = false;
                        break;
                    case "Administrator":
                        mnuTeacher.Enabled = true;
                        mnuTeacherGradebook.Enabled = true;
                        mnuTeacherAttendance.Enabled = true;
                        mnuTeacherSeatingChart.Enabled = true;
                        mnuOfficer.Enabled = true;
                        mnuOfficerTeachers.Enabled = true;
                        mnuOfficerStudents.Enabled = true;
                        mnuOfficerCourses.Enabled = true;
                        mnuAdmin.Enabled = true;
                        mnuAdminUsers.Enabled = true;
                        break;
                    default:
                        mnuTeacher.Enabled = false;
                        mnuTeacherGradebook.Enabled = false;
                        mnuTeacherAttendance.Enabled = false;
                        mnuTeacherSeatingChart.Enabled = false;
                        mnuOfficer.Enabled = false;
                        mnuOfficerTeachers.Enabled = false;
                        mnuOfficerStudents.Enabled = false;
                        mnuOfficerCourses.Enabled = false;
                        mnuAdmin.Enabled = false;
                        mnuAdminUsers.Enabled = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Sets state.
        private void frmHome_Load(object sender, EventArgs e)
        {
            //Pointer to help file
            helpme.HelpNamespace = Application.StartupPath + "\\helpme.chm";

            try
            {
                SetState(ProgOps.UserRole);
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void mnuHelpInstructions_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpme.HelpNamespace);
        }
    }
}
