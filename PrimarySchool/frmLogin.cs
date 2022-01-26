﻿using System;
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

        // Proceeds to Home if LogIn method returns true.
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (LogIn())
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
                    FormOps.ErrorBox("Check username and password");
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
                    tbxUsername.ForeColor = System.Drawing.ColorTranslator.FromHtml("#89B4D2");
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
                tbxUsername.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0B090B");
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
                    tbxPassword.ForeColor = System.Drawing.ColorTranslator.FromHtml("#89B4D2");
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
                tbxUsername.ForeColor = System.Drawing.ColorTranslator.FromHtml("#89B4D2");
                tbxUsername.Text = strTypeUser;
                tbxPassword.ForeColor = System.Drawing.ColorTranslator.FromHtml("#89B4D2");
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
                    tbxUsername.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0B090B");
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

        // Clears tbxPassword if user selects it while the default prompt is visible, sets the text color to black,
        // and sets the password character.
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
                FormOps.ErrorBox(ex.Message);
            }
        }
    }
}
