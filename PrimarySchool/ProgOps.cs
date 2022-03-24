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
        // Connection string to database
        private const string CONNECT_STRING = 
            @"Server=cstnt.tstc.edu;Database=inew2330sp22;User Id=group1fa212330;password=1645456";

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
        private static SqlCommand assignmentsCommand;
        // Command objects - MMC
        private static SqlCommand _sqlTeachersCommand;

        // Data adapters
        private static SqlDataAdapter assignmentsAdapter;
        // Data adapters - MMC
        private static SqlDataAdapter _daTeachers = new SqlDataAdapter();

        // Data tables - MMC
        private static DataTable _dtTeachersTable = new DataTable();

        // Data tables
        private static DataTable assignmentsTable;

        // Public getter for assignmentsTable.
        public static DataTable AssignmentsTable
        {
            get
            {
                return assignmentsTable;
            }
        }

        // String builders
        // String builders - MMC
        private static StringBuilder _errorMessages = new StringBuilder();

        public static DataTable DTTeachersTable
        {
            get { return _dtTeachersTable; }
        }

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

                SqlDataAdapter logInAdapter = 
                    new SqlDataAdapter(logInQuery, _cntPrimarySchoolDatabase);

                DataTable logInTable = new DataTable();

                logInAdapter.Fill(logInTable);

                if (logInTable.Rows.Count == 1)
                {
                    logInAdapter.Dispose();
                    logInAdapter = null;

                    logInTable.Dispose();
                    logInTable = null;

                    string getInfoQuery = "SELECT User_ID, " +
                        "User_FName + ' ' + User_LName AS 'Name', " +
                        "Role_Title " +
                        "FROM group1fa212330.Users AS U " +
                        "JOIN group1fa212330.User_Roles AS UR ON U.Role_ID = UR.Role_ID " +
                        "WHERE User_LoginName = '" + tbxUsername.Text.Trim() + "';";

                    SqlDataAdapter getInfoAdapter = 
                        new SqlDataAdapter(getInfoQuery, _cntPrimarySchoolDatabase);
                    DataTable getInfoTable = new DataTable();

                    getInfoAdapter.Fill(getInfoTable);

                    userID = Convert.ToInt32(getInfoTable.Rows[0][0]);
                    userFullName = Convert.ToString(getInfoTable.Rows[0][1]);
                    userRole = Convert.ToString(getInfoTable.Rows[0][2]);

                    getInfoAdapter.Dispose();
                    getInfoAdapter = null;

                    getInfoTable.Dispose();
                    getInfoTable = null;

                    return true;
                }
                else
                {
                    logInAdapter.Dispose();
                    logInAdapter = null;

                    logInTable.Dispose();
                    logInTable = null;

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

        // Returns data for Course Name ComboBox as a Data Table.
        // Runs different queries based on User Role.
        public static DataTable GetCourseNames()
        {

            DataTable courseNamesTable = new DataTable();

            try
            {
                string courseNamesQuery;

                if (userRole.Equals("Teacher"))
                {
                    courseNamesQuery = 
                        "SELECT Course_Name " +
                        "FROM group1fa212330.Courses " +
                        "WHERE User_ID = " + userID +
                        " ORDER BY Course_Name;";
                }
                else
                {
                    courseNamesQuery = 
                        "SELECT Course_Name " +
                        "FROM group1fa212330.Courses " +
                        "ORDER BY Course_Name";
                }

                SqlDataAdapter courseNamesAdapter = 
                    new SqlDataAdapter(courseNamesQuery, _cntPrimarySchoolDatabase);

                courseNamesAdapter.Fill(courseNamesTable);

                courseNamesAdapter.Dispose();
                courseNamesAdapter = null;

                return courseNamesTable;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return courseNamesTable;
            }
        }

        // Get Course ID using Course Name.
        // Works for both Teacher and non-Teachers because
        // Course_Name now has a Unique constraint.
        public static int GetCourseID(string courseName)
        {
            try
            {
                string courseIDQuery = 
                    "SELECT Course_ID " +
                    "FROM group1fa212330.Courses " +
                    "WHERE Course_Name = '" + courseName + "';";

                SqlDataAdapter courseIDAdapter =
                    new SqlDataAdapter(courseIDQuery, _cntPrimarySchoolDatabase);

                DataTable courseIDTable = new DataTable();

                courseIDAdapter.Fill(courseIDTable);

                int courseID = Convert.ToInt32(courseIDTable.Rows[0][0]);

                courseIDAdapter.Dispose();
                courseIDAdapter = null;

                courseIDTable.Clear();
                courseIDTable.Dispose();
                courseIDTable = null;

                return courseID;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return 0;
            }
        }

        // Get Instructor Name as string using Course ID.
        public static string GetInstructorName(int courseID)
        {
            try
            {
                string instructorNameQuery = 
                    "SELECT User_FName + ' ' + User_LName AS 'Instructor Name' " +
                    "FROM group1fa212330.Users AS U " +
                    "JOIN group1fa212330.Courses AS C " +
                    "ON U.User_ID = C.User_ID " +
                    "WHERE Course_ID = " + courseID + ";";

                SqlDataAdapter instructorNameAdapter =
                    new SqlDataAdapter(instructorNameQuery, _cntPrimarySchoolDatabase);

                DataTable instructorNameTable = new DataTable();

                instructorNameAdapter.Fill(instructorNameTable);

                string instructorName = Convert.ToString(instructorNameTable.Rows[0][0]);

                instructorNameAdapter.Dispose();
                instructorNameAdapter = null;

                instructorNameTable.Clear();
                instructorNameTable.Dispose();
                instructorNameTable = null;

                return instructorName;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return "[Instructor Name]";
            }
        }

        // Get Room ID using Course ID.
        public static int GetRoomID(int courseID)
        {
            try
            {
                string roomQuery = 
                    "SELECT DISTINCT Room_ID " +
                    "FROM group1fa212330.Seating_Chart " +
                    "WHERE Course_ID = " + courseID + ";";

                SqlDataAdapter roomAdapter = 
                    new SqlDataAdapter(roomQuery, _cntPrimarySchoolDatabase);

                DataTable roomTable = new DataTable();

                roomAdapter.Fill(roomTable);

                int roomID = 0;

                if (roomTable.Rows.Count == 1)
                {
                    roomID = Convert.ToInt32(roomTable.Rows[0][0]);
                }

                roomAdapter.Dispose();
                roomAdapter = null;

                roomTable.Clear();
                roomTable.Dispose();
                roomTable = null;

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
                string totalSeatsQuery = 
                    "SELECT DISTINCT Number_Of_Seats " +
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

                SqlDataAdapter totalSeatsAdapter = 
                    new SqlDataAdapter(totalSeatsQuery, _cntPrimarySchoolDatabase);

                DataTable totalSeatsTable = new DataTable();

                totalSeatsAdapter.Fill(totalSeatsTable);

                int totalSeatsID = 0;

                if (totalSeatsTable.Rows.Count == 1)
                {
                    totalSeatsID = Convert.ToInt32(totalSeatsTable.Rows[0][0]);
                }

                totalSeatsAdapter.Dispose();
                totalSeatsAdapter = null;

                totalSeatsTable.Clear();
                totalSeatsTable.Dispose();
                totalSeatsTable = null;

                return totalSeatsID;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return 0;
            }
        }

        //Get Teacher information for Academic Officers - Teacher Tab
        public static void TeachersCommand(TextBox txUserID, TextBox txLName, TextBox txFname,
            TextBox txMName, TextBox txDOB, TextBox txMailingAddress, TextBox txStreet, TextBox txCity,
            TextBox txState, TextBox txZip, TextBox txPhone, TextBox txTotalCourses)
        {
            try
            {
                //statement for the command string
                string sqlStatement = "SELECT Users.User_ID, User_LName, User_FName, User_MName, User_DOB, User_MailingAddress, User_MailingAddress AS User_StreetAddress, " +
                    "User_City, User_State, User_Zip, User_Phone_Number, Count(Courses.Course_ID) AS NumOfCourses " +
                    "FROM group1fa212330.Users " +
                    "JOIN group1fa212330.Courses ON Users.User_ID = Courses.User_ID " +
                    "GROUP BY Users.User_ID, User_LName, User_FName, User_MName, User_DOB, User_MailingAddress, User_City, User_State, User_Zip, User_Phone_Number;";
                //establish command object
                _sqlTeachersCommand = new SqlCommand(sqlStatement, _cntPrimarySchoolDatabase);
                //establish data adapter
                _daTeachers.SelectCommand = _sqlTeachersCommand;
                //fill data table
                _daTeachers.Fill(_dtTeachersTable);
                //bind controls to data table
                txUserID.DataBindings.Add("Text", _dtTeachersTable, "User_ID");
                txLName.DataBindings.Add("Text", _dtTeachersTable, "User_LName");
                txFname.DataBindings.Add("Text", _dtTeachersTable, "User_FName");
                txMName.DataBindings.Add("Text", _dtTeachersTable, "User_MName");
                txDOB.DataBindings.Add("Text", _dtTeachersTable, "User_DOB");
                txMailingAddress.DataBindings.Add("Text", _dtTeachersTable, "User_MailingAddress");
                txStreet.DataBindings.Add("Text", _dtTeachersTable, "User_StreetAddress");
                txCity.DataBindings.Add("Text", _dtTeachersTable, "User_City");
                txState.DataBindings.Add("Text", _dtTeachersTable, "User_State");
                txZip.DataBindings.Add("Text", _dtTeachersTable, "User_Zip");
                txPhone.DataBindings.Add("Text", _dtTeachersTable, "User_Phone_Number");
                txTotalCourses.DataBindings.Add("Text", _dtTeachersTable, "NumOfCourses");
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
                    MessageBox.Show(_errorMessages.ToString(), "Error on DatabaseCommand", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {//handles generic ones here
                    MessageBox.Show(ex.Message, "Error on DatabaseCommand", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Returns data for Gradebook DataGridView as a Data Table using Course ID.
        public static DataTable GetGradebookTable(int courseID)
        {

            DataTable gradebookTable = new DataTable();

            try
            {
                string gradebookQuery =
                    "SELECT First_Name AS 'First Name', " +
                    "Last_Name AS 'Last Name', " +
                    "Assignment_Name AS 'Assignment', " +
                    "Grade, " +
                    "Comments " +
                    "FROM group1fa212330.Gradebook AS GB " +
                    "JOIN group1fa212330.Students AS S " +
                    "ON GB.Student_ID = S.Student_ID " +
                    "JOIN group1fa212330.Grade_Assignments AS GA " +
                    "ON GB.Assignment_ID = GA.Assignment_ID " +
                    "WHERE Course_ID = " + courseID + " " +
                    "ORDER BY Last_Name, GB.Assignment_ID;";

                SqlDataAdapter gradebookAdapter = 
                    new SqlDataAdapter(gradebookQuery, _cntPrimarySchoolDatabase);

                gradebookAdapter.Fill(gradebookTable);

                gradebookAdapter.Dispose();
                gradebookAdapter = null;

                return gradebookTable;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return gradebookTable;
            }
        }

        // Returns a table parallel to the Gradebook table that contains Assignment ID,
        // Category ID, and Category Weight to be used in code.
        public static DataTable GetHiddenGradebookTable(int courseID)
        {

            DataTable hiddenGradebookTable = new DataTable();

            try
            {
                string hiddenGradebookQuery =
                    "SELECT  GB.Student_ID, " +
                    "GB.Assignment_ID, " +
                    "GA.Category_ID, " +
                    "Category_Weight " +
                    "FROM group1fa212330.Grade_Assignments AS GA " +
                    "JOIN group1fa212330.Grade_Categories AS GC " +
                    "ON GA.Category_ID = GC.Category_ID " +
                    "JOIN group1fa212330.Gradebook AS GB " +
                    "ON GA.Assignment_ID = GB.Assignment_ID " +
                    "JOIN group1fa212330.Students AS S " +
                    "ON GB.Student_ID = S.Student_ID " +
                    "WHERE Course_ID = " + courseID + " " +
                    "ORDER BY Last_Name, GB.Assignment_ID;";

                SqlDataAdapter hiddenGradebookAdapter =
                    new SqlDataAdapter(hiddenGradebookQuery, _cntPrimarySchoolDatabase);

                hiddenGradebookAdapter.Fill(hiddenGradebookTable);

                hiddenGradebookAdapter.Dispose();
                hiddenGradebookAdapter = null;

                return hiddenGradebookTable;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return hiddenGradebookTable;
            }
        }

        public static void UpdateGradebookTable(DataTable gradebookTable, 
            DataTable hiddenGradebookTable, List<int> changedRowsList, 
            int courseID)
        {
            try
            {
                SqlCommand update = new SqlCommand("UPDATE group1fa212330.Gradebook " +
                    "SET Grade = @Grade, Comments = @Comments " +
                    "WHERE Student_ID = @Student_ID " +
                    "AND Assignment_ID = @Assignment_ID " +
                    "AND Course_ID = @Course_ID;", _cntPrimarySchoolDatabase);

                for (int x = 0; x < changedRowsList.Count; x++)
                {
                    int row = changedRowsList[x];

                    if (gradebookTable.Rows[row][3] == DBNull.Value)
                    {
                        update.Parameters.AddWithValue("@Grade", DBNull.Value);
                    }
                    else
                    {
                        update.Parameters.AddWithValue("@Grade", gradebookTable.Rows[row][3]);
                    }

                    if (gradebookTable.Rows[row][4] == DBNull.Value || 
                        gradebookTable.Rows[row][4].ToString().Trim().Equals(string.Empty))
                    {
                        update.Parameters.AddWithValue("@Comments", DBNull.Value);
                    }
                    else
                    {
                        update.Parameters.AddWithValue("@Comments", gradebookTable.Rows[row][4]);
                    }

                    update.Parameters.AddWithValue("@Student_ID", hiddenGradebookTable.Rows[row][0]);

                    update.Parameters.AddWithValue("@Assignment_ID", hiddenGradebookTable.Rows[row][1]);

                    update.Parameters.AddWithValue("@Course_ID", courseID);

                    update.ExecuteNonQuery();

                    update.Parameters.Clear();
                }

                MessageBox.Show("Database successfully updated", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox("Update Gradebook Table: " + ex.Message);
            }
        }

        // Returns data for Attendance DataGridView as a Data Table using Course ID and Date in string format.
        public static DataTable GetAttendanceTable(int courseID, string date)
        {

            DataTable attendTable = new DataTable();

            try
            {
                string attendQuery =
                    "SELECT A.Student_ID AS 'Student ID', " +
                    "First_Name AS 'First Name', " +
                    "Last_Name AS 'Last Name', " +
                    "isPresent AS Present, " +
                    "isExcused AS Excused, " +
                    "absenceReason AS 'Absence Reason', " +
                    "Date " +
                    "FROM group1fa212330.Attendance AS A " +
                    "JOIN group1fa212330.Students AS S " +
                    "ON A.Student_ID = S.Student_ID " +
                    "WHERE Course_ID = " + courseID + " " +
                    "AND Date = '" + date + "' " +
                    "ORDER BY Last_Name;";

                SqlDataAdapter attendAdapter = 
                    new SqlDataAdapter(attendQuery, _cntPrimarySchoolDatabase);

                attendAdapter.Fill(attendTable);

                attendAdapter.Dispose();
                attendAdapter = null;
                
                return attendTable;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return attendTable;
            }
        }

        public static void InsertIntoAttendanceTable(DataTable attendanceTable, 
            List<int> changedRowsList, int courseID)
        {
            try
            {
                SqlCommand insert = new SqlCommand("INSERT INTO group1fa212330.Attendance " +
                    "(Course_ID, Student_ID, isPresent, absenceReason, isExcused, Date) " +
                    "VALUES " +
                    "(@CourseID, @StudentID, @isPresent, @absenceReason, @isExcused, @Date);",
                    _cntPrimarySchoolDatabase);

                for (int x = 0; x < changedRowsList.Count; x++)
                {
                    int row = changedRowsList[x];

                    insert.Parameters.AddWithValue("@CourseID", courseID);

                    insert.Parameters.AddWithValue("@StudentID", attendanceTable.Rows[x][0]);

                    insert.Parameters.AddWithValue("@isPresent", attendanceTable.Rows[x][3]);

                    insert.Parameters.AddWithValue("@absenceReason", attendanceTable.Rows[x][5]);

                    insert.Parameters.AddWithValue("@isExcused", attendanceTable.Rows[x][4]);

                    DateTime date = Convert.ToDateTime(attendanceTable.Rows[x][6].ToString());

                    insert.Parameters.AddWithValue("@Date", date.ToString("yyyy-MM-dd"));

                    insert.ExecuteNonQuery();

                    insert.Parameters.Clear();
                }

                MessageBox.Show("Database successfully updated", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        public static void UpdateAttendanceTable(DataTable attendanceTable,
            List<int> changedRowsList, int courseID)
        {
            try
            {
                SqlCommand update = new SqlCommand("UPDATE group1fa212330.Attendance " +
                    "SET isPresent = @isPresent, " +
                    "absenceReason = @absenceReason, " +
                    "isExcused = @isExcused " +
                    "WHERE Course_ID = @CourseID AND " +
                    "Student_ID = @StudentID AND " +
                    "Date = @Date;", _cntPrimarySchoolDatabase);

                for (int x = 0; x < changedRowsList.Count; x++)
                {
                    int row = changedRowsList[x];

                    update.Parameters.AddWithValue("@isPresent", attendanceTable.Rows[x][3]);

                    update.Parameters.AddWithValue("@absenceReason", attendanceTable.Rows[x][5]);

                    update.Parameters.AddWithValue("@isExcused", attendanceTable.Rows[x][4]);

                    update.Parameters.AddWithValue("@CourseID", courseID);

                    update.Parameters.AddWithValue("@StudentID", attendanceTable.Rows[x][0]);

                    DateTime date = Convert.ToDateTime(attendanceTable.Rows[x][6].ToString());

                    update.Parameters.AddWithValue("@Date", date.ToString("yyyy-MM-dd"));

                    update.ExecuteNonQuery();

                    update.Parameters.Clear();
                }

                MessageBox.Show("Database successfully updated", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Returns data for Seats DataGridView as a Data Table using Course ID.
        public static DataTable GetSeatingChartTable(int courseID)
        {

            DataTable seatsTable = new DataTable();

            try
            {
                string seatsQuery = 
                    "SELECT S.Student_ID AS 'Student ID', " +
                    "First_Name AS 'First Name', " +
                    "Last_Name AS 'Last Name', " +
                    "SC.Seat_ID AS 'Seat ID' " +
                    "FROM group1fa212330.Students AS S " +
                    "JOIN group1fa212330.Seating_Chart AS SC " +
                    "ON S.Student_ID = SC.Student_ID " +
                    "WHERE Course_ID = " + courseID + " " +
                    "ORDER BY SC.Seat_ID;";

                SqlDataAdapter seatsAdapter = 
                    new SqlDataAdapter(seatsQuery, _cntPrimarySchoolDatabase);

                seatsAdapter.Fill(seatsTable);

                seatsAdapter.Dispose();
                seatsAdapter = null;

                return seatsTable;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return seatsTable;
            }
        }

        // Returns data for Seats ListBox as a Data Table using Course ID.
        public static DataTable GetSeatsList(int courseID)
        {

            DataTable seatsListTable = new DataTable();

            try
            {
                string seatsListQuery = 
                    "SELECT SC.Seat_ID AS 'Seat ID', Row, Number " +
                    "FROM group1fa212330.Seating_Chart AS SC " +
                    "JOIN group1fa212330.Seats AS S " +
                    "ON SC.Seat_ID = S.Seat_ID " +
                    "WHERE Course_ID = " + courseID + " " +
                    "ORDER BY SC.Seat_ID;";

                SqlDataAdapter seatsListAdapter =
                    new SqlDataAdapter(seatsListQuery, _cntPrimarySchoolDatabase);

                seatsListAdapter.Fill(seatsListTable);

                seatsListAdapter.Dispose();
                seatsListAdapter = null;

                return seatsListTable;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return seatsListTable;
            }
        }

        public static void UpdateSeatingChartTable(DataTable seatingChartTable, 
            List<int> changedRowsList, int courseID)
        {
            try
            {
                SqlCommand update = new SqlCommand("UPDATE group1fa212330.Seating_Chart " +
                    "SET Seat_ID = @Seat_ID " +
                    "WHERE Student_ID = @Student_ID " +
                    "AND Course_ID = @Course_ID;", _cntPrimarySchoolDatabase);

                for (int x = 0; x < changedRowsList.Count; x++)
                {
                    int row = changedRowsList[x];

                    update.Parameters.AddWithValue("@Seat_ID", seatingChartTable.Rows[row][3]);

                    update.Parameters.AddWithValue("@Student_ID", seatingChartTable.Rows[row][0]);

                    update.Parameters.AddWithValue("@Course_ID", courseID);

                    update.ExecuteNonQuery();

                    update.Parameters.Clear();
                }

                MessageBox.Show("Database successfully updated", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox("UpdateSeatingChartTable: " + ex.Message);
            }
        }

        // Returns full names of students in a course as a Data Table using Course ID.
        public static DataTable GetStudentsInCourse(int courseID)
        {

            DataTable studentsTable = new DataTable();

            try
            {
                string studentsQuery = 
                    "SELECT S.Student_ID AS 'Student ID', " +
                    "First_Name AS 'First Name', " +
                    "Last_Name AS 'Last Name' " +
                    "FROM group1fa212330.Students AS S " +
                    "JOIN group1fa212330.Student_Registration AS SR " +
                    "ON S.Student_ID = SR.Student_ID " +
                    "JOIN group1fa212330.Courses AS C " +
                    "ON SR.Course_ID = C.Course_ID " +
                    "WHERE SR.Course_ID = " + courseID + " " +
                    "ORDER BY Last_Name;";

                SqlDataAdapter studentsAdapter = 
                    new SqlDataAdapter(studentsQuery, _cntPrimarySchoolDatabase);

                studentsAdapter.Fill(studentsTable);

                studentsAdapter.Dispose();
                studentsAdapter = null;

                return studentsTable;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return studentsTable;
            }
        }

        // Returns assignment Weight as a double using Assignment Name.
        public static double GetAssignmentWeight(string assignmentName)
        {
            try
            {
                string weightQuery =
                    "SELECT Category_Weight " +
                    "FROM group1fa212330.Grade_Categories AS GC " +
                    "JOIN group1fa212330.Grade_Assignments AS GA " +
                    "ON GC.Category_ID = GA.Category_ID " +
                    "WHERE Assignment_Name = '" + assignmentName + "';";

                SqlDataAdapter weightAdapter =
                    new SqlDataAdapter(weightQuery, _cntPrimarySchoolDatabase);

                DataTable weightTable = new DataTable();

                weightAdapter.Fill(weightTable);

                double weight = Convert.ToDouble(weightTable.Rows[0][0]);

                weightAdapter.Dispose();
                weightAdapter = null;

                weightTable.Clear();
                weightTable.Dispose();
                weightTable = null;

                return weight;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return 0;
            }
        }

        public static void DatabaseCommandAssignments(TextBox tbxAssignmentID, 
            TextBox tbxCategory, TextBox tbxAssignmentName, TextBox tbxDescription)
        {
            try
            {
                assignmentsTable = new DataTable();

                string query = "SELECT * " +
                    "FROM group1fa212330.Grade_Assignments ORDER BY Assignment_ID;";

                assignmentsCommand = new SqlCommand(query, _cntPrimarySchoolDatabase);

                assignmentsAdapter = new SqlDataAdapter();

                assignmentsAdapter.SelectCommand = assignmentsCommand;

                assignmentsAdapter.Fill(assignmentsTable);

                tbxAssignmentID.DataBindings.Add("Text", assignmentsTable, "Assignment_ID");
                tbxCategory.DataBindings.Add("Text", assignmentsTable, "Category_ID");
                tbxAssignmentName.DataBindings.Add("Text", assignmentsTable, "Assignment_Name");
                tbxDescription.DataBindings.Add("Text", assignmentsTable, "Assignment_Description");
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Update database for Assignments form.
        public static void UpdateAssignments()
        {

            StringBuilder errorMessages = new StringBuilder();

            try
            {
                SqlCommandBuilder assignmentAdapterCommands = 
                    new SqlCommandBuilder(assignmentsAdapter);

                assignmentsAdapter.Update(assignmentsTable);
            }
            catch (SqlException ex)
            {
                if (ex is SqlException)
                {
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + ex.Errors[i].Message + "\n" +
                            "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                            "Source: " + ex.Errors[i].Source + "\n" +
                            "Procedure: " + ex.Errors[i].Procedure + "\n");
                    }

                    FormOps.ErrorBox(errorMessages.ToString());
                }
                else
                {
                    FormOps.ErrorBox(ex.Message);
                }
            }
        }

        public static void DisposeAssignments()
        {
            try
            {
                if (assignmentsTable != null)
                {
                    assignmentsTable.Clear();
                    assignmentsTable.Dispose();
                    assignmentsTable = null;
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        public static DataTable GetCategoriesTable()
        {

            DataTable categoriesTable = new DataTable();

            try
            {
                string categoriesQuery =
                    "SELECT * " +
                    "FROM group1fa212330.Grade_Categories " +
                    "ORDER BY Category_ID;";

                SqlDataAdapter categoriesAdapter =
                    new SqlDataAdapter(categoriesQuery, _cntPrimarySchoolDatabase);

                categoriesAdapter.Fill(categoriesTable);

                categoriesAdapter.Dispose();
                categoriesAdapter = null;

                return categoriesTable;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return categoriesTable;
            }
        }

        public static void AddAssignmentToCourse(int courseID, int assignmentID)
        {
            try
            {
                string dataCheckQuery
                    = "SELECT * " +
                    "FROM group1fa212330.Gradebook " +
                    "WHERE Course_ID = " + courseID +
                    " AND Assignment_ID = " + assignmentID + ";";

                SqlDataAdapter dataCheckAdapter =
                    new SqlDataAdapter(dataCheckQuery, _cntPrimarySchoolDatabase);

                DataTable dataCheckTable = new DataTable();

                dataCheckAdapter.Fill(dataCheckTable);

                if (dataCheckTable.Rows.Count == 0)
                {
                    string studentIDsQuery
                    = "SELECT DISTINCT Student_ID " +
                    "FROM group1fa212330.Gradebook " +
                    "WHERE Course_ID = " + courseID + ";";

                    SqlDataAdapter studentIDsAdapter =
                        new SqlDataAdapter(studentIDsQuery, _cntPrimarySchoolDatabase);

                    DataTable studentIDsTable = new DataTable();

                    studentIDsAdapter.Fill(studentIDsTable);

                    SqlCommand insert = new SqlCommand("INSERT INTO group1fa212330.Gradebook " +
                        "(Course_ID, Student_ID, Assignment_ID, Grade, Comments) " +
                        "VALUES " +
                        "(@CourseID, @StudentID, @AssignmentID, NULL, NULL);", _cntPrimarySchoolDatabase);

                    for (int x = 0; x < studentIDsTable.Rows.Count; x++)
                    {

                        insert.Parameters.AddWithValue("@CourseID", courseID);

                        insert.Parameters.AddWithValue("@StudentID", studentIDsTable.Rows[x][0]);

                        insert.Parameters.AddWithValue("@AssignmentID", assignmentID);

                        insert.ExecuteNonQuery();

                        insert.Parameters.Clear();
                    }

                    studentIDsAdapter.Dispose();
                    studentIDsAdapter = null;

                    studentIDsTable.Clear();
                    studentIDsTable.Dispose();
                    studentIDsTable = null;
                }
                else
                {
                    FormOps.ErrorBox("This assignment is already part of the current course " +
                        "and therefore cannot be added");
                }

                dataCheckTable.Clear();
                dataCheckTable.Dispose();
                dataCheckTable = null;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        public static void RemoveAssignmentFromCourse(int courseID, int assignmentID)
        {
            try
            {
                string dataCheckQuery
                    = "SELECT * " +
                    "FROM group1fa212330.Gradebook " +
                    "WHERE Course_ID = " + courseID +
                    " AND Assignment_ID = " + assignmentID + ";";

                SqlDataAdapter dataCheckAdapter =
                    new SqlDataAdapter(dataCheckQuery, _cntPrimarySchoolDatabase);

                DataTable dataCheckTable = new DataTable();

                dataCheckAdapter.Fill(dataCheckTable);

                if (dataCheckTable.Rows.Count > 0)
                {
                    SqlCommand delete = new SqlCommand("DELETE " +
                    "FROM group1fa212330.Gradebook " +
                    "WHERE Course_ID = @CourseID " +
                    "AND Assignment_ID = @AssignmentID;", _cntPrimarySchoolDatabase);

                    delete.Parameters.AddWithValue("@CourseID", courseID);

                    delete.Parameters.AddWithValue("@AssignmentID", assignmentID);

                    delete.ExecuteNonQuery();
                }
                else
                {
                    FormOps.ErrorBox("This assignment is not part of the current course " +
                        "and therefore cannot be deleted");
                }

                dataCheckTable.Clear();
                dataCheckTable.Dispose();
                dataCheckTable = null;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        //public static int GetCategoryIDForAssignment(int assignmentID)
        //{
        //    try
        //    {
        //        string categoryIDQuery =
        //            "SELECT Category_ID " +
        //            "FROM group1fa212330.Grade_Assignments " +
        //            "WHERE Assignment_ID = " + assignmentID + ";";

        //        SqlDataAdapter categoryIDAdapter =
        //            new SqlDataAdapter(categoryIDQuery, _cntPrimarySchoolDatabase);

        //        DataTable categoryIDTable = new DataTable();

        //        categoryIDAdapter.Fill(categoryIDTable);

        //        int categoryID = Convert.ToInt32(categoryIDTable.Rows[0][0]);

        //        categoryIDAdapter.Dispose();
        //        categoryIDAdapter = null;

        //        categoryIDTable.Clear();
        //        categoryIDTable.Dispose();
        //        categoryIDTable = null;

        //        return categoryID;
        //    }
        //    catch (Exception ex)
        //    {
        //        FormOps.ErrorBox(ex.Message);
        //        return 0;
        //    }
        //}
    }
}
