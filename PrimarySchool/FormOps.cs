using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Enables easy repitition for basic form-related operations.

namespace PrimarySchool
{
    class FormOps
    {
        // Closes form.
        public static void CloseForm(Form form)
        {
            try
            {
                form.Close();
            }
            catch (Exception ex)
            {
                ErrorBox(ex.Message);
            }
        }

        // Opens modal form.
        public static void ShowModal(Form form)
        {
            try
            {
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorBox(ex.Message);
            }
        }

        // Opens first form as modal and hides second form.
        public static void ShowModalAndHide(Form show, Form hide)
        {
            try
            {
                hide.Hide();
                show.ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorBox(ex.Message);
            }
        }

        // Opens modeless form.
        public static void ShowModeless(Form form)
        {
            try
            {
                form.Show();
            }
            catch (Exception ex)
            {
                ErrorBox(ex.Message);
            }
        }

        // Opens first form as modeless and hides second form.
        public static void ShowModelessAndHide(Form show, Form hide)
        {
            try
            {
                hide.Hide();
                show.Show();
            }
            catch (Exception ex)
            {
                ErrorBox(ex.Message);
            }
        }

        // Displays MessageBox with 'Error' as header, OK button, and Error icon.
        public static void ErrorBox(string message)
        {
            MessageBox.Show(message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }
    }
}
