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
    public partial class frmLogin : Form
    {
        // Stores default text values for tbxUsername and tbxPassword into private global string variables.
        private string strTypeUser = " Type your username", strTypePassword = " Type your password";

        public frmLogin()
        {
            InitializeComponent();
        }

        // Proceeds to Home if LogIn method returns true.
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProgOps.LogIn(tbxUsername, tbxPassword))
                {
                    frmHome home = new frmHome(this);
                    FormOps.ShowModelessAndHide(home, this);
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // NOT CURRENTLY BEING USED ******************************
        // Checks user credentials.
        // Displays MessageBox if user credentials aren't correct.
        private bool LogIn()
        {
            try
            {
                if (tbxUsername.Text.Trim().Equals("team1") && 
                    tbxPassword.Text.Equals("pass"))
                {
                    return true;
                }
                else
                {
                    FormOps.ErrorBox("Check username and password.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return false;
            }
        }

        // Replaces tbxUsername Text value with default prompt if user leaves field empty.
        private void tbxUsername_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbxUsername.Text.Trim().Equals(string.Empty))
                {
                    tbxUsername.ForeColor = FormOps.GetColorFromPalette("mid blue");
                    tbxUsername.Text = strTypeUser;
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Closes application.
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Closes DB connection.
        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ProgOps.CloseDisposeDatabase();
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Opens DB connection.
        // Clears tbxUsername.
        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                ProgOps.OpenDatabase();
                tbxUsername.Text = string.Empty;
                tbxUsername.ForeColor = FormOps.GetColorFromPalette("black");
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Resets tbxPassword to default prompt if user leaves field empty.
        private void tbxPassword_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbxPassword.Text.Trim().Equals(string.Empty))
                {
                    tbxPassword.ForeColor = FormOps.GetColorFromPalette("mid blue");
                    tbxPassword.Text = strTypePassword;
                    tbxPassword.PasswordChar = '\0';
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Resets form to default state.
        public void Reset()
        {
            try
            {
                tbxUsername.ForeColor = FormOps.GetColorFromPalette("mid blue");
                tbxUsername.Text = strTypeUser;
                tbxPassword.ForeColor = FormOps.GetColorFromPalette("mid blue");
                tbxPassword.Text = strTypePassword;
                tbxPassword.PasswordChar = '\0';
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Clears tbxUsername and makes text color black if user selects tbxUsername while default prompt is visible.
        private void tbxUsername_Enter(object sender, EventArgs e)
        {
            try
            {
                if (tbxUsername.Text.Equals(strTypeUser))
                {
                    tbxUsername.Text = string.Empty;
                    tbxUsername.ForeColor = FormOps.GetColorFromPalette("black");
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Opens Reset Password as modal.
        private void lblForgot_Click(object sender, EventArgs e)
        {
            frmResetPassword resetPassword = new frmResetPassword();
            FormOps.ShowModal(resetPassword);
        }

        // Reveals password.
        private void pbxEyeball_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxPassword.PasswordChar.Equals('*'))
                {
                    tbxPassword.PasswordChar = '\0';
                }
                else
                {
                    tbxPassword.PasswordChar = '*';
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // If user press Enter key inside tbxUsername, tbxPassword gets focus.
        private void tbxUsername_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    tbxPassword.Focus();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // If user press Enter key inside tbxPassword, btnLogin performs click.
        private void tbxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnLogIn.Focus();
                    btnLogIn.PerformClick();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Clears tbxPassword if user selects it while the default prompt is visible,
        // sets the text color to black,
        // and sets the password character.
        private void tbxPassword_Enter(object sender, EventArgs e)
        {
            try
            {
                if (tbxPassword.Text.Equals(strTypePassword))
                {
                    tbxPassword.Text = string.Empty;
                    tbxPassword.ForeColor = FormOps.GetColorFromPalette("black");
                    tbxPassword.PasswordChar = '*';
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }
    }
}
