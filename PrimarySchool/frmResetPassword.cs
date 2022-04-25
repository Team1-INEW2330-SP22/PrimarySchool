using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace PrimarySchool
{
    public partial class frmResetPassword : Form
    {
        // Stores default text values for tbxEmail and tbxCode into private global string variables.
        private string strTypeEmail = " Type your email", strTypeCode = " Type the code sent to your email";

        //used for the recoveryToken generation
        private static Random random = new Random();

        public frmResetPassword()
        {
            InitializeComponent();
        }

        // Clears tbxEmail and makes text color black if user selects tbxEmail while default prompt is visible.
        private void tbxEmail_Enter(object sender, EventArgs e)
        {
            try
            {
                if (tbxEmail.Text.Equals(strTypeEmail))
                {
                    tbxEmail.Text = string.Empty;
                    tbxEmail.ForeColor = FormOps.GetColorFromPalette("black");
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Replaces tbxEmail Text value with default prompt if user leaves field empty.
        private void tbxEmail_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbxEmail.Text.Trim().Equals(string.Empty))
                {
                    tbxEmail.ForeColor = FormOps.GetColorFromPalette("mid blue");
                    tbxEmail.Text = strTypeEmail;
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Clears tbxCode and makes text color black if user selects tbxCode while default prompt is visible.
        private void tbxCode_Enter(object sender, EventArgs e)
        {
            try
            {
                if (tbxCode.Text.Equals(strTypeCode))
                {
                    tbxCode.Text = string.Empty;
                    tbxCode.ForeColor = FormOps.GetColorFromPalette("black");
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (ProgOps.CheckEmail(tbxEmail) == 1)
            {
                //Creates a random Token for password recovery
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                string passwordToken = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());

                //Saves Token to User Record
                ProgOps.UpdateTableWithToken(tbxEmail, passwordToken);

                //Calls Password Reset Token Email
                ProgOps.emailResetPwd(tbxEmail.Text, passwordToken);

                tbxEmail.Enabled = false;
                btnSend.Enabled = false;

                MessageBox.Show("If the email address is valid, a password reset token will be sent to the email address provided.", "Success");
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ProgOps.TokenChallange(tbxEmail, tbxCode) == 1)
            {
                frmEnterNewPassword resetPwd = new frmEnterNewPassword(tbxEmail, tbxCode);
                FormOps.ShowModal(resetPwd);
                this.Close();
            }
        }

        // Replaces tbxCode Text value with default prompt if user leaves field empty.
        private void tbxCode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbxCode.Text.Trim().Equals(string.Empty))
                {
                    tbxCode.ForeColor = FormOps.GetColorFromPalette("mid blue");
                    tbxCode.Text = strTypeCode;
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }
    }
}
