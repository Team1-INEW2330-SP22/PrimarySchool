using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

// Performs various database (DB) related operations for Primary School.

namespace PrimarySchool
{
    class ProgOps
    {
        //connection string to database
        private const string CONNECT_STRING = @"Server=cstnt.tstc.edu;Database=inew2330sp22;User Id=group1fa212330;password=1645456";
        //build a connection to database
        private static SqlConnection _cntPrimarSchoolDatabase = new SqlConnection(CONNECT_STRING);
        //command objects

        //data adapters

        //data tables

        //string builders
        private static StringBuilder _errorMessages = new StringBuilder();



        public static void OpenDatabase()
        {
            //method to open database
            try
            {
                //open the connection to phone database
                _cntPrimarSchoolDatabase.Open();
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
                _cntPrimarSchoolDatabase.Close();
                //message stating that connection to database was succesful
                MessageBox.Show("Connection to database was successfully closed.", "Database Connection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                //dispose of the sql objects
                _cntPrimarSchoolDatabase.Dispose();
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
    }
}
