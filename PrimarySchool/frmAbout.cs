using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Application: Primary School
 * Group: Team 1
 * Names: Tyler Anderson, Max Cancino, Ryan Hicks
 * Date: 4/27/2022
 * Course: INEW-2330-7Z1
 * Semester: SP/22
 */

namespace PrimarySchool
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        // Closes About.
        private void mnuFileClose_Click(object sender, EventArgs e)
        {
            FormOps.CloseModal(this);
        }

        // Closes About.
        private void btnReturnToHome_Click(object sender, EventArgs e)
        {
            FormOps.CloseModal(this);
        }
    }
}
