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
    public partial class frmHome : Form
    {
        // Creates 'login' attribute of frmHome so we can close
        // frmLogin from Home screen. Doesn't initialize.
        private frmLogin login;

        // Initializes 'login' attribute to frmLogin passed as parameter/argument.
        public frmHome(frmLogin login)
        {
            this.login = login;
            InitializeComponent();
        }

        // Closes Home.
        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Returns to reset Login form.
        private void mnuFileLogOut_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                login.Reset();
                login.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Closes the Login form when the Home screen is closed.
        private void frmHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                login.Close();
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
