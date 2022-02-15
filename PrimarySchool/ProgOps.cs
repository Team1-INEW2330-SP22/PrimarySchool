﻿using System;
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
        // Connection string to database
        private const string CONNECT_STRING = @"Server=cstnt.tstc.edu;Database=inew2330sp22;User Id=group1fa212330;password=1645456";

        // Build connection to database
        private static SqlConnection _cntPrimarySchoolDatabase = new SqlConnection(CONNECT_STRING);

        // Get SqlConnection from outside ProgOps
        static public SqlConnection dbConnection
        {
            get
            {
                return _cntPrimarySchoolDatabase;
            }
        }

        // Command objects


        // Data adapters


        // Data tables


        // String builders
        private static StringBuilder _errorMessages = new StringBuilder();

        // Hold current user information
        private static int userID = 0;
        private static string userFullName = "User's Full Name";
        private static string userRole = "User's Role";

        // Get current user info from outside ProgOps
        static public int UserID
        {
            get
            { 
                return userID;
            }
        }
        static public string UserFullName
        {
            get
            { 
                return userFullName; 
            }
        }
        static public string UserRole
        {
            get
            {
                return userRole;
            }
        }

        // Logs user in
        // Gets user info if credentials are valid
        public static Boolean LogIn(TextBox tbxUsername, TextBox tbxPassword)
        {
            try
            {
                string logInQuery = "SELECT User_LoginName, User_LoginPwd " +
                    "FROM group1fa212330.Users " +
                    "WHERE User_LoginName = '" + tbxUsername.Text.Trim() + 
                    "' AND User_LoginPwd = '" + tbxPassword.Text + "';";

                SqlDataAdapter logInAdapter = new SqlDataAdapter(logInQuery, _cntPrimarySchoolDatabase);

                DataTable logInTable = new DataTable();

                logInAdapter.Fill(logInTable);

                if (logInTable.Rows.Count == 1)
                {
                    logInAdapter.Dispose();
                    logInTable.Dispose();

                    string getInfoQuery = "SELECT User_ID, User_FName + ' ' + User_LName AS 'Name', Role_Title " +
                        "FROM group1fa212330.Users AS U " +
                        "JOIN group1fa212330.User_Roles AS UR ON U.Role_ID = UR.Role_ID " +
                        "WHERE User_LoginName = '" + tbxUsername.Text.Trim() + "';";

                    SqlDataAdapter getInfoAdapter = new SqlDataAdapter(getInfoQuery, _cntPrimarySchoolDatabase);
                    DataTable getInfoTable = new DataTable();

                    getInfoAdapter.Fill(getInfoTable);

                    userID = Convert.ToInt32(getInfoTable.Rows[0][0]);
                    userFullName = Convert.ToString(getInfoTable.Rows[0][1]);
                    userRole = Convert.ToString(getInfoTable.Rows[0][2]);

                    getInfoAdapter.Dispose();
                    getInfoTable.Dispose();

                    return true;
                }
                else
                {
                    logInAdapter.Dispose();
                    logInTable.Dispose();

                    FormOps.ErrorBox("Check username and password");

                    return false;
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return false;
            }
        }

        // Resets user info
        public static void LogOut()
        {
            try
            {
                userID = 0;
                userFullName = "User's Full Name";
                userRole = "User's Role";
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Opens database
        public static void OpenDatabase()
        {
            try
            {
                // Opens the connection
                _cntPrimarySchoolDatabase.Open();

                // Show message stating that connection to database was succesful
                MessageBox.Show("Connection to database successfully opened", "Database Connection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                if (ex is SqlException)
                { // Handles SqlExceptions
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        _errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + ex.Errors[i].Message + "\n" +
                            "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                            "Source: " + ex.Errors[i].Source + "\n" +
                            "Procedure: " + ex.Errors[i].Procedure + "\n");
                    }
                    MessageBox.Show(_errorMessages.ToString(), "Error on Open", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                { // Handles generic error messages
                    MessageBox.Show(ex.Message, "Error on Open", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Closes database and disposes of the connection objects
        public static void CloseDisposeDatabase()
        {
            try
            {
                // Close connection
                _cntPrimarySchoolDatabase.Close();

                // Show message stating that connection to database was succesful
                MessageBox.Show("Connection to database was successfully closed", "Database Connection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Dispose of the SQL objects
                _cntPrimarySchoolDatabase.Dispose();
            }
            catch (SqlException ex)
            {
                if (ex is SqlException)
                { // Handles SqlExceptions
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        _errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + ex.Errors[i].Message + "\n" +
                            "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                            "Source: " + ex.Errors[i].Source + "\n" +
                            "Procedure: " + ex.Errors[i].Procedure + "\n");
                    }
                    MessageBox.Show(_errorMessages.ToString(), "Error on Close", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                { // Handles generic error messages
                    MessageBox.Show(ex.Message, "Error on Close", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Returns data for Course Name ComboBox as a Data Table using current User ID.
        // **** USE ONLY WITH TEACHER USERS. ****
        public static DataTable GetCourseNamesForTeacher()
        {
            DataTable courseNamesTable = new DataTable();
            try
            {
                string courseNamesQuery = "SELECT Course_Name " +
                    "FROM group1fa212330.Courses " +
                    "WHERE User_ID = " + userID +
                    " ORDER BY Course_Name;";

                SqlDataAdapter courseNamesAdapter = new SqlDataAdapter(courseNamesQuery, _cntPrimarySchoolDatabase);

                courseNamesAdapter.Fill(courseNamesTable);

                courseNamesAdapter.Dispose();

                return courseNamesTable;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return courseNamesTable;
            }
        }

        // Get Course ID using Course Name and current User ID.
        // **** USE ONLY WITH TEACHER USERS. ****
        public static int GetCourseIDForTeacher(string courseName)
        {
            try
            {
                string courseIDQuery = "SELECT Course_ID " +
                       "FROM group1fa212330.Courses " +
                       "WHERE User_ID = " + userID + " AND Course_Name = '" + courseName + "';";
                SqlDataAdapter courseIDAdapter = new SqlDataAdapter(courseIDQuery, _cntPrimarySchoolDatabase);
                DataTable courseIDTable = new DataTable();
                courseIDAdapter.Fill(courseIDTable);

                int courseID = Convert.ToInt32(courseIDTable.Rows[0][0]);

                courseIDAdapter.Dispose();
                courseIDTable.Dispose();

                return courseID;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return 0;
            }
        }

        // Get Room ID using Course ID.
        public static int GetRoomID(int courseID)
        {
            try
            {
                string roomQuery = "SELECT R.Room_ID " +
                        "FROM group1fa212330.Rooms AS R " +
                        "JOIN group1fa212330.Seats AS S " +
                        "ON R.Room_ID = S.Room_ID " +
                        "JOIN group1fa212330.Seating_Chart AS SC " +
                        "ON S.Seat_ID = SC.Seat_ID " +
                        "JOIN group1fa212330.Courses AS C " +
                        "ON SC.Course_ID = C.Course_ID " +
                        "JOIN group1fa212330.Users AS U " +
                        "ON C.User_ID = U.User_ID " +
                        "WHERE C.Course_ID = " + courseID + ";";
                SqlDataAdapter roomAdapter = new SqlDataAdapter(roomQuery, _cntPrimarySchoolDatabase);
                DataTable roomTable = new DataTable();
                roomAdapter.Fill(roomTable);

                int roomID = 0;

                if (roomTable.Rows.Count == 1)
                {
                    roomID = Convert.ToInt32(roomTable.Rows[0][0]);
                }

                roomAdapter.Dispose();
                roomTable.Dispose();

                return roomID;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return 0;
            }
        }

        // Get Total Seats using Course ID.
        public static int GetTotalSeats(int courseID)
        {
            try
            {
                string totalSeatsQuery = "SELECT Number_Of_Seats " +
                    "FROM group1fa212330.Room_Sizes AS RS " +
                    "JOIN group1fa212330.Rooms AS R " +
                    "ON RS.Room_Size_ID = R.Room_Size_ID " +
                    "JOIN group1fa212330.Seats AS S " +
                    "ON R.Room_ID = S.Room_ID " +
                    "JOIN group1fa212330.Seating_Chart AS SC " +
                    "ON S.Seat_ID = SC.Seat_ID " +
                    "JOIN group1fa212330.Courses AS C " +
                    "ON SC.Course_ID = C.Course_ID " +
                    "WHERE C.Course_ID = " + courseID + ";";
                SqlDataAdapter totalSeatsAdapter = new SqlDataAdapter(totalSeatsQuery, _cntPrimarySchoolDatabase);
                DataTable totalSeatsTable = new DataTable();
                totalSeatsAdapter.Fill(totalSeatsTable);

                int totalSeatsID = 0;

                if (totalSeatsTable.Rows.Count == 1)
                {
                    totalSeatsID = Convert.ToInt32(totalSeatsTable.Rows[0][0]);
                }

                totalSeatsAdapter.Dispose();
                totalSeatsTable.Dispose();

                return totalSeatsID;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return 0;
            }
        }

        // Returns data for Gradebook DataGridView as a Data Table using Course ID.
        public static DataTable GetGradebookTable(int courseID)
        {
            DataTable gbTable = new DataTable();
            try
            {
                string gbQuery = "SELECT DISTINCT S.Student_ID AS 'Student ID', " +
                    "First_Name AS 'First Name', " +
                    "Last_Name AS 'Last Name', " +
                    "Assignment_Name AS Assignment, " +
                    "Grade, " +
                    "Comments " +
                    "FROM group1fa212330.Students AS S " +
                    "JOIN group1fa212330.Student_Registration AS SR " +
                    "ON S.Student_ID = SR.Student_ID " +
                    "JOIN group1fa212330.Courses AS C " +
                    "ON SR.Course_ID = C.Course_ID " +
                    "JOIN group1fa212330.Gradebook AS GB " +
                    "ON C.Course_ID = GB.Course_ID " +
                    "JOIN group1fa212330.Grade_Assignments AS GA " +
                    "ON GB.Assignment_ID = GA.Assignment_ID " +
                    "WHERE SR.Course_ID = " + courseID + " " +
                    "ORDER BY Last_Name;";
                SqlDataAdapter gbAdapter = new SqlDataAdapter(gbQuery, _cntPrimarySchoolDatabase);
                gbAdapter.Fill(gbTable);

                gbAdapter.Dispose();

                return gbTable;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return gbTable;
            }
        }

        // Returns data for Attendance DataGridView as a Data Table using Course ID and Date in string format.
        public static DataTable GetAttendanceTable(int courseID, string date)
        {
            DataTable attendTable = new DataTable();
            try
            {
                string attendQuery = "SELECT S.Student_ID AS 'Student ID', " +
                "First_Name AS 'First Name', " +
                "Last_Name AS 'Last Name', " +
                "isPresent AS 'Present', " +
                "isExcused as 'Excused',  " +
                "absenceReason AS 'Absence Reason', " +
                "Date " +
                "FROM group1fa212330.Attendance AS A " +
                "JOIN group1fa212330.Courses AS C " +
                "ON A.Course_ID = C.Course_ID " +
                "JOIN group1fa212330.Student_Registration AS SR " +
                "ON C.Course_ID = SR.Course_ID " +
                "JOIN group1fa212330.Students AS S " +
                "ON SR.Student_ID = S.Student_ID " +
                "WHERE SR.Course_ID = " + courseID + " " +
                "AND Date = '" + date + "';";
                SqlDataAdapter attendAdapter = new SqlDataAdapter(attendQuery, _cntPrimarySchoolDatabase);
                attendAdapter.Fill(attendTable);

                attendAdapter.Dispose();
                
                return attendTable;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return attendTable;
            }
        }

        // Returns data for Seats DataGridView as a Data Table using Course ID.
        public static DataTable GetSeatingChartTable(int courseID)
        {
            DataTable seatsTable = new DataTable();
            try
            {
                string seatsQuery = "SELECT S.Student_ID AS 'Student ID', " +
                    "First_Name AS 'First Name', " +
                    "Last_Name AS 'Last Name', " +
                    "SC.Seat_ID AS 'Seat ID', " +
                    "Row, " +
                    "Number " +
                    "FROM group1fa212330.Students AS S " +
                    "JOIN group1fa212330.Seating_Chart AS SC " +
                    "ON S.Student_ID = SC.Student_ID " +
                    "JOIN group1fa212330.Seats AS S1 " +
                    "ON SC.Seat_ID = S1.Seat_ID " +
                    "WHERE Course_ID = " + courseID + ";";
                SqlDataAdapter seatsAdapter = new SqlDataAdapter(seatsQuery, _cntPrimarySchoolDatabase);
                seatsAdapter.Fill(seatsTable);

                seatsAdapter.Dispose();

                return seatsTable;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return seatsTable;
            }
        }

        // Returns full names of students in a course as a Data Table using Course ID.
        public static DataTable GetStudentsInCourse(int courseID)
        {
            DataTable studentsTable = new DataTable();
            try
            {
                string studentsQuery = "SELECT S.Student_ID AS 'Student ID', " +
                "First_Name AS 'First Name', " +
                "Last_Name AS 'Last Name' " +
                "FROM group1fa212330.Students AS S " +
                "JOIN group1fa212330.Student_Registration AS SR " +
                "ON S.Student_ID = SR.Student_ID " +
                "JOIN group1fa212330.Courses AS C " +
                "ON SR.Course_ID = C.Course_ID " +
                "WHERE SR.Course_ID = " + courseID + " " +
                "ORDER BY Last_Name;";
                SqlDataAdapter studentsAdapter = new SqlDataAdapter(studentsQuery, _cntPrimarySchoolDatabase);
                studentsAdapter.Fill(studentsTable);

                studentsAdapter.Dispose();

                return studentsTable;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return studentsTable;
            }
        }
    }
}
