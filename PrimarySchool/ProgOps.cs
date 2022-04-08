using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Configuration;

// Performs various database (DB) related operations for Primary School.

namespace PrimarySchool
{
    class ProgOps
    {
        //connection string to database
        private const string CONNECT_STRING = @"Server=cstnt.tstc.edu;Database=inew2330sp22;User Id=group1fa212330;password=1645456";
        
        //build a connection to database
        private static SqlConnection _cntPrimarySchoolDatabase = new SqlConnection(CONNECT_STRING);

        //Establishing Add Command Objects - rth040322
        private static SqlCommand _sqlUsersCommand;                                  //Cmd Object for Users Table
        private static SqlCommand _sqlUserLoginCommand; 
        private static SqlCommand _sqlAddTokenCommand;
        private static SqlCommand _sqlUpdatePassCommand;
        private static SqlCommand _sqlTokenChallangeCommand;

        //Establishing Data Adapter - rth040322
        private static SqlDataAdapter _daUsers = new SqlDataAdapter();               //SqlDataAdapter Object for Users Table
        private static SqlDataAdapter _daUsersLogin = new SqlDataAdapter();
        private static SqlDataAdapter _daTokenChallange = new SqlDataAdapter();

        //Establishing Data Tables - rth040322
        private static DataTable _dtUsersTable = new DataTable();                    //DataTable Object for Users Table
        private static DataTable _dtUserLoginTable = new DataTable();
        private static DataTable _daTokenChallangeTable = new DataTable();

        //string builders
        private static StringBuilder _errorMessages = new StringBuilder();

        public static void OpenDatabase()
        {
            //method to open database
            try
            {
                //open the connection to phone database
                _cntPrimarySchoolDatabase.Open();
                //message stating that connection to database was succesful
                MessageBox.Show("Connection to database was successfully opened.", "Database Connection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                if (ex is SqlException)
                {//handles more specific SqlException here.
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        _errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + ex.Errors[i].Message + "\n" +
                            "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                            "Source: " + ex.Errors[i].Source + "\n" +
                            "Procedure: " + ex.Errors[i].Procedure + "\n");
                    }
                    MessageBox.Show(_errorMessages.ToString(), "Error on Open", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {//handles generic ones here
                    MessageBox.Show(ex.Message, "Error on Open", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void CloseDisposeDatabase()
        {
            //method to close database and dispose of the connection object
            try
            {
                //close connection
                _cntPrimarySchoolDatabase.Close();
                //message stating that connection to database was succesful
                MessageBox.Show("Connection to database was successfully closed.", "Database Connection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                //dispose of the sql objects
                _cntPrimarySchoolDatabase.Dispose();
            }
            catch (SqlException ex)
            {
                if (ex is SqlException)
                {//handles more specific SqlException here.
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        _errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + ex.Errors[i].Message + "\n" +
                            "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                            "Source: " + ex.Errors[i].Source + "\n" +
                            "Procedure: " + ex.Errors[i].Procedure + "\n");
                    }
                    MessageBox.Show(_errorMessages.ToString(), "Error on Close", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {//handles generic ones here
                    MessageBox.Show(ex.Message, "Error on Close", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void UserLoginObjectDisposal()
        {
            //Dispose of UserLogin command adapter and objects
            _sqlUsersCommand.Dispose();
            _daUsersLogin.Dispose();
            _dtUsersTable.Dispose();
        }

        public static int UserLogin_DBCmd(TextBox tbxUserName, TextBox tbxUserPassword)
        {
            //Set Objects to null
            _sqlUsersCommand = null;
            _daUsers = null;
            _dtUsersTable = null;

            //reset data adapter and datatable to new
            _daUsers = new SqlDataAdapter();
            _dtUsersTable = new DataTable();

            //Employees Table SQL Statement
            string sqlUsers = "SELECT * FROM group1fa212330.Users WHERE User_LoginName = '" + tbxUserName.Text + "' AND User_LoginPwd = '" + tbxUserPassword.Text + "';";

            try
            {
                //Establish the Command Object
                _sqlUsersCommand = new SqlCommand(sqlUsers, _cntPrimarySchoolDatabase);

                //Establish Data Adapter
                _daUsers.SelectCommand = _sqlUsersCommand;

                //Establish Data Table
                _daUsers.Fill(_dtUsersTable);

            }
            catch (Exception ex)
            {
                //Message stating connection was successfull
                MessageBox.Show(ex.Message, "Error in Processing SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (_dtUsersTable.Rows.Count > 0)
            {
                MessageBox.Show("Welcome to the PrimarySchool application.", "Login Successful");
                return 1;
            }
            else
            {
                MessageBox.Show("The username or password you have entered is invalid.", "Invalid Login");
                return 0;
            }

        }

        public static int CheckEmail(TextBox tbxEmail)
        {
            //Set Objects to null
            _sqlUsersCommand = null;
            _daUsers = null;
            _dtUsersTable = null;

            //reset data adapter and datatable to new
            _daUsers = new SqlDataAdapter();
            _dtUsersTable = new DataTable();

            //Employees Table SQL Statement
            string sqlUser = "SELECT * FROM group1fa212330.Users WHERE User_Email = '" + tbxEmail.Text + "'";

            try
            {
                //Establish the Command Object
                _sqlUsersCommand = new SqlCommand(sqlUser, _cntPrimarySchoolDatabase);

                //Establish Data Adapter
                _daUsers.SelectCommand = _sqlUsersCommand;

                //Establish Data Table
                _daUsers.Fill(_dtUsersTable);

            }
            catch (Exception ex)
            {
                //Message stating connection was successfull
                MessageBox.Show(ex.Message, "Error in Processing SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (_dtUsersTable.Rows.Count > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static void UpdateTableWithToken(TextBox tbxEmail, string token)
        {
            //Set Objects to null
            _sqlUsersCommand = null;
            _daUsers = null;
            _dtUsersTable = null;

            //reset data adapter and datatable to new
            _daUsers = new SqlDataAdapter();
            _dtUsersTable = new DataTable();

            //Employees Table SQL Statement
            string sqlUser = "UPDATE group1fa212330.Users SET User_Email_Token = @token WHERE User_Email = @email";

            try
            {
                //Establish the Command Object
                _sqlUsersCommand = new SqlCommand(sqlUser, _cntPrimarySchoolDatabase);

                _sqlUsersCommand.Parameters.AddWithValue("@token", token);
                _sqlUsersCommand.Parameters.AddWithValue("@email", tbxEmail.Text);

                _sqlUsersCommand.ExecuteNonQuery();
                _sqlUsersCommand.Parameters.Clear();
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }

            //Old Code rth0408
            //using(_cntPrimarySchoolDatabase)
            //using (_sqlAddTokenCommand = _cntPrimarySchoolDatabase.CreateCommand())
            //{
            //    _sqlAddTokenCommand.Parameters.AddWithValue("@token", token);
            //    _sqlAddTokenCommand.Parameters.AddWithValue("@email", tbxEmail.Text);

            //    _sqlAddTokenCommand.CommandText = "UPDATE group1fa212330.Users SET User_Email_Token = @token WHERE User_Email = @email";

            //    _sqlAddTokenCommand.ExecuteNonQuery();
            //}
        }
        
        public static void emailResetPwd(string email, string token)
        {
            using (MailMessage message = new MailMessage(ConfigurationManager.AppSettings["FromEmail"], email))
            {
                message.Subject = "Forgotten Password";
                message.Body = "You reset token is: " + token;
                message.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["Host"];
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"]);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                smtp.Send(message);
            }
        }

        public static int TokenChallange(TextBox tbxEmail, TextBox tbxToken)
        {
            //Set Command Object to null
            _sqlUsersCommand = null;
            _daUsers = null;
            _dtUsersTable = null;

            //reset data adapter and datatable to new
            _daUsers = new SqlDataAdapter();
            _dtUsersTable = new DataTable();

            //Employees Table SQL Statement
            string sqlToken = "SELECT * FROM group1fa212330.Users WHERE User_Email = '" + tbxEmail.Text + "' AND User_Email_Token = '" + tbxToken.Text + "';";

            try
            {
                //Establish the Command Object
                _sqlUsersCommand = new SqlCommand(sqlToken, _cntPrimarySchoolDatabase);

                //Establish Data Adapter
                _daUsers.SelectCommand = _sqlUsersCommand;

                //Establish Data Table
                _daUsers.Fill(_dtUsersTable);

            }
            catch (Exception ex)
            {
                //Message stating connection was successfull
                MessageBox.Show(ex.Message, "Error in Processing SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (_dtUsersTable.Rows.Count > 0)
            {
                MessageBox.Show("Token Challange Accepted", "Login Successful");
                return 1;
            }
            else
            {
                MessageBox.Show("Token Challange Failed", "Invalid Login");
                return 0;
            }

        }

        public static void UpdateNewPass(string email, string token, TextBox tbxPassword)
        {
            //Set Objects to null
            _sqlUsersCommand = null;
            _daUsers = null;
            _dtUsersTable = null;

            //reset data adapter and datatable to new
            _daUsers = new SqlDataAdapter();
            _dtUsersTable = new DataTable();

            //Employees Table SQL Statement
            string sqlUser = "UPDATE group1fa212330.Users SET User_LoginPwd = @newPass, User_Email_Token = NULL WHERE User_Email = @email AND User_Email_Token = @token";

            try
            {
                //Establish the Command Object
                _sqlUsersCommand = new SqlCommand(sqlUser, _cntPrimarySchoolDatabase);

                _sqlUsersCommand.Parameters.AddWithValue("@token", token);
                _sqlUsersCommand.Parameters.AddWithValue("@email", email);
                _sqlUsersCommand.Parameters.AddWithValue("@newPass", tbxPassword.Text);

                _sqlUsersCommand.ExecuteNonQuery();
                _sqlUsersCommand.Parameters.Clear();
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }



            //Old Code
            //using (_cntPrimarySchoolDatabase)
            //using (_sqlUpdatePassCommand = _cntPrimarySchoolDatabase.CreateCommand())
            //{
            //    _sqlUpdatePassCommand.Parameters.AddWithValue("@token", token);
            //    _sqlUpdatePassCommand.Parameters.AddWithValue("@email", email);
            //    _sqlUpdatePassCommand.Parameters.AddWithValue("@newPass", tbxPassword.Text);

            //    _sqlUpdatePassCommand.CommandText = "UPDATE group1fa212330.Users SET User_LoginPwd = @newPass, User_Email_Token = NULL WHERE User_Email = @email AND User_Email_Token = @token";

            //    _sqlUpdatePassCommand.ExecuteNonQuery();
            //}
        }
    }
}
