using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

// Enables easy repitition for basic form-related operations.

namespace PrimarySchool
{
    class FormOps
    {
        // Closes modeless form.
        public static void CloseModeless(Form form)
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

        // Closes modal form.
        public static void CloseModal(Form form)
        {
            try
            {
                form.Close();
                form.Dispose();
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

        // Returns a color from our color palette.
        public static Color GetColorFromPalette(string color)
        {
            switch (color)
            {
                case "dark blue":
                    return System.Drawing.ColorTranslator.FromHtml("#3B77A5");
                case "mid blue":
                    return System.Drawing.ColorTranslator.FromHtml("#89B4D2");
                case "light blue":
                    return System.Drawing.ColorTranslator.FromHtml("#E2EBF3");
                case "gray":
                    return System.Drawing.ColorTranslator.FromHtml("#C3C5BE");
                case "black":
                    return System.Drawing.ColorTranslator.FromHtml("#0B090B");
                default:
                    // Returns red if the string isn't correct.
                    return System.Drawing.ColorTranslator.FromHtml("#FF0000");
            }
        }

        // Asks a question and returns a boolean value depending on the answer.
        public static Boolean QuestionBox(string question)
        {
            try
            {
                SystemSounds.Beep.Play();
                DialogResult response;
                response = MessageBox.Show(question,
                    "Question", 
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (response == DialogResult.No)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                ErrorBox(ex.Message);
                return false;
            }
        }
    }
}
