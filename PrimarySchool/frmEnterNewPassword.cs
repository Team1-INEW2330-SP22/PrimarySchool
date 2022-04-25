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
    public partial class frmEnterNewPassword : Form
    {
        // Stores default text values for tbxNewPass and tbxConfirm into private global string variables.
        private string strType = " Type your new password", strConfirm = " Confirm your new password";

        string emailAddress, tokenCode;

        private void tbxNewPass_Enter(object sender, EventArgs e)
        {
            try
            {
                if (tbxNewPass.Text.Equals(strType))
                {
                    tbxNewPass.Text = string.Empty;
                    tbxNewPass.ForeColor = FormOps.GetColorFromPalette("black");
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void tbxNewPass_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbxNewPass.Text.Trim().Equals(string.Empty))
                {
                    tbxNewPass.ForeColor = FormOps.GetColorFromPalette("mid blue");
                    tbxNewPass.Text = strType;
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void tbxConfirm_Enter(object sender, EventArgs e)
        {
            try
            {
                if (tbxConfirm.Text.Equals(strConfirm))
                {
                    tbxConfirm.Text = string.Empty;
                    tbxConfirm.ForeColor = FormOps.GetColorFromPalette("black");
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void tbxConfirm_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbxConfirm.Text.Trim().Equals(string.Empty))
                {
                    tbxConfirm.ForeColor = FormOps.GetColorFromPalette("mid blue");
                    tbxConfirm.Text = strConfirm;
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        public frmEnterNewPassword(TextBox email, TextBox token)
        {
            this.emailAddress = email.Text;
            this.tokenCode = token.Text;
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (tbxNewPass.Text == tbxConfirm.Text)
            {
                ProgOps.UpdateNewPass(emailAddress, tokenCode, tbxNewPass);
                this.Close();
            }
            else
            {
                MessageBox.Show("Passwords do not match");
                tbxNewPass.Clear();
                tbxConfirm.Clear();
            }
        }
    }
}
