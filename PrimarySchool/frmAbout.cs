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
