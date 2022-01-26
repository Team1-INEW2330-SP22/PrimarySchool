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
    public partial class frmUsers : Form
    {
        // Creates 'home' attribute so we can show Home again. Doesn't initialize.
        private frmHome home;

        // Initializes 'home' attribute to parameter.
        public frmUsers(frmHome home)
        {
            this.home = home;
            InitializeComponent();
        }

        // Shows Home.
        private void frmUsers_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormOps.ShowModeless(home);
        }

        // Closes Users.
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormOps.CloseForm(this);
        }
    }
}
