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
    public partial class frmLogin : Form
    {
        // Stores default text values for tbxUsername and tbxPassword into private global string variables.
        private string strTypeUser = " Type your username", strTypePassword = " Type your password";

        public frmLogin()
        {
            InitializeComponent();
        }

        // Proceeds to Home form if LogIn method returns true.
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (LogIn())
                {
                    frmHome home = new frmHome(this);
                    home.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

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
                    MessageBox.Show("Check username and password",
                        "Incorrect Credentials",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

        // Replaces tbxUsername Text value with default ' Type your username' prompt
        // if user leaves field empty.
        private void tbxUsername_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbxUsername.Text.Trim().Equals(string.Empty))
                {
                    tbxUsername.ForeColor = System.Drawing.ColorTranslator.FromHtml("#89B4D2");
                    tbxUsername.Text = strTypeUser;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Closes DB connection (do later).
        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Opens DB connection (do later).
        // Clears tbxUsername.
        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                tbxUsername.Text = string.Empty;
                tbxUsername.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0B090B");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Resets tbxPassword to default prompt if user leaves field empty.
        private void tbxPassword_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbxPassword.Text.Trim().Equals(string.Empty))
                {
                    tbxPassword.ForeColor = System.Drawing.ColorTranslator.FromHtml("#89B4D2");
                    tbxPassword.Text = strTypePassword;
                    tbxPassword.PasswordChar = '\0';
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Resets form to default state.
        public void Reset()
        {
            try
            {
                tbxUsername.ForeColor = System.Drawing.ColorTranslator.FromHtml("#89B4D2");
                tbxUsername.Text = strTypeUser;
                tbxPassword.ForeColor = System.Drawing.ColorTranslator.FromHtml("#89B4D2");
                tbxPassword.Text = strTypePassword;
                tbxPassword.PasswordChar = '\0';
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Clears username field and makes text color black if user selects tbxUsername
        // when default ' Type your username' prompt is visible.
        private void tbxUsername_Enter(object sender, EventArgs e)
        {
            try
            {
                if (tbxUsername.Text.Equals(strTypeUser))
                {
                    tbxUsername.Text = string.Empty;
                    tbxUsername.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0B090B");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Clears tbxPassword when user selects it while the default prompt is visible,
        // sets the text color to black, and sets the password character.
        private void tbxPassword_Enter(object sender, EventArgs e)
        {
            try
            {
                if (tbxPassword.Text.Equals(strTypePassword))
                {
                    tbxPassword.Text = string.Empty;
                    tbxPassword.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0B090B");
                    tbxPassword.PasswordChar = '*';
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
