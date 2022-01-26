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
    public partial class frmTeachers : Form
    {
        // Creates 'home' attribute so we can show Home again. Doesn't initialize.
        private frmHome home;

        // Initializes 'home' attribute to parameter.
        public frmTeachers(frmHome home)
        {
            this.home = home;
            InitializeComponent();
        }

        // Shows Home.
        private void frmTeachers_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormOps.ShowModeless(home);
        }

        // Closes Teachers.
        private void mnuFileClose_Click(object sender, EventArgs e)
        {
            FormOps.CloseForm(this);
        }
    }
}
