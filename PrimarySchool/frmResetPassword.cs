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
    public partial class frmResetPassword : Form
    {
        // Stores default text values for tbxEmail and tbxCode into private global string variables.
        private string strTypeEmail = " Type your email", strTypeCode = " Type the code sent to your email";

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
                    tbxEmail.ForeColor = System.Drawing.ColorTranslator.FromHtml(FormOps.GetColorHex("black"));
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
                    tbxEmail.ForeColor = System.Drawing.ColorTranslator.FromHtml(FormOps.GetColorHex("mid blue"));
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
                    tbxCode.ForeColor = System.Drawing.ColorTranslator.FromHtml(FormOps.GetColorHex("black"));
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }
        
        // Replaces tbxCode Text value with default prompt if user leaves field empty.
        private void tbxCode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbxCode.Text.Trim().Equals(string.Empty))
                {
                    tbxCode.ForeColor = System.Drawing.ColorTranslator.FromHtml(FormOps.GetColorHex("mid blue"));
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
