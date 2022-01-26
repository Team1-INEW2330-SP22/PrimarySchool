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
    public partial class frmAssignments : Form
    {
        // Creates 'gradebook' attribute so we can perform certain operations on Gradebook from Assignments.
        // Doesn't initialize.
        private frmGradebook gradebook;

        // Initializes 'gradebook' attribute to parameter.
        public frmAssignments(frmGradebook gradebook)
        {
            this.gradebook = gradebook;
            InitializeComponent();
        }

        // Closes Assignments.
        private void mnuFileClose_Click(object sender, EventArgs e)
        {
            FormOps.CloseForm(this);
        }
    }
}
