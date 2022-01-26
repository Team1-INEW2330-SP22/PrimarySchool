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
    public partial class frmGradebook : Form
    {
        // Creates 'home' attribute so we can show Home again. Doesn't initialize.
        private frmHome home;

        // Initializes 'home' attribute to parameter.
        public frmGradebook(frmHome home)
        {
            this.home = home;
            InitializeComponent();
        }

        // Closes Gradebook.
        private void mnuFileClose_Click(object sender, EventArgs e)
        {
            FormOps.CloseForm(this);
        }

        // Brings Home back upon closing Gradebook.
        private void frmGradebook_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormOps.ShowModeless(home);
        }

        // Opens modal Assignments.
        private void mnuEditAssignments_Click(object sender, EventArgs e)
        {
            frmAssignments assignments = new frmAssignments(this);
            FormOps.ShowModal(assignments);
        }
    }
}
