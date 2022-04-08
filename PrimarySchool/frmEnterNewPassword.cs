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
        string emailAddress, tokenCode;
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
