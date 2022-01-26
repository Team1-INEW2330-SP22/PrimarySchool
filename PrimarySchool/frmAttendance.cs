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
    public partial class frmAttendance : Form
    {
        // Creates 'home' attribute so we can show Home again. Doesn't initialize.
        private frmHome home;

        // Initializes 'home' attribute to parameter.
        public frmAttendance(frmHome home)
        {
            this.home = home;
            InitializeComponent();
        }

        // Brings Home back upon closing Attendance.
        private void frmAttendance_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormOps.ShowModeless(home);
        }

        // Closes Attendance.
        private void mnuFileClose_Click(object sender, EventArgs e)
        {
            FormOps.CloseForm(this);
        }
    }
}
