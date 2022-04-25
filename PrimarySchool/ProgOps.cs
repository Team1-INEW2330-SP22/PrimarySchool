using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Configuration;

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

        // Get database connection from outside ProgOps
        static public SqlConnection dbConnection
        {
            get
            {
                return _cntPrimarySchoolDatabase;
            }
        }

        // Command objects - MMC
        private static SqlCommand _sqlTeachersCommand;

        // Data adapters - MMC
        private static SqlDataAdapter _daTeachers = new SqlDataAdapter();

        // Data tables - MMC
        private static DataTable _dtTeachersTable = new DataTable();

        // String builders - MMC
        private static StringBuilder _errorMessages = new StringBuilder();

        public static DataTable DTTeachersTable
        {
            get { return _dtTeachersTable; }
        }

        // Command objects - TKA
        private static SqlCommand assignmentsCommand;
        private static SqlCommand studentsCommand;
        private static SqlCommand coursesCommand;

        // Data adapters - TKA
        private static SqlDataAdapter assignmentsAdapter;
        private static SqlDataAdapter studentsAdapter;
        private static SqlDataAdapter coursesAdapter;

        // Data tables - TKA
        private static DataTable assignmentsTable;
        private static DataTable studentsTable;
        private static DataTable coursesTable;

        // Public getter for assignments DataTable
        public static DataTable AssignmentsTable
        {
            get
            {
                return assignmentsTable;
            }
        }

        // Public getter for students DataTable
        public static DataTable StudentsTable
        {
            get
            {
                return studentsTable;
            }
        }

        // Public getter for courses DataTable
        public static DataTable CoursesTable
        {
            get
            {
                return coursesTable;
            }
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
                string logInQuery = "EXEC group1fa212330.spCheckUserLogIn @User_LoginName = '" +
                    tbxUsername.Text.Trim() + "', @User_LoginPwd = '" + tbxPassword.Text + "';";

                SqlDataAdapter logInAdapter = new SqlDataAdapter(logInQuery, _cntPrimarySchoolDatabase);

                DataTable logInTable = new DataTable();

                logInAdapter.Fill(logInTable);

                if (logInTable.Rows.Count == 1)
                {
                    logInAdapter.Dispose();

                    logInTable.Clear();
                    logInTable.Dispose();

                    string getInfoQuery = "EXEC group1fa212330.spGetUserInfo @User_LoginName = '" + tbxUsername.Text.Trim() + "';";

                    SqlDataAdapter getInfoAdapter = new SqlDataAdapter(getInfoQuery, _cntPrimarySchoolDatabase);

                    DataTable getInfoTable = new DataTable();

                    getInfoAdapter.Fill(getInfoTable);

                    userID = Convert.ToInt32(getInfoTable.Rows[0][0]);
                    userFullName = Convert.ToString(getInfoTable.Rows[0][1]);
                    userRole = Convert.ToString(getInfoTable.Rows[0][2]);

                    getInfoAdapter.Dispose();

                    getInfoTable.Clear();
                    getInfoTable.Dispose();

                    return true;
                }
                else
                {
                    logInAdapter.Dispose();

                    logInTable.Clear();
                    logInTable.Dispose();

                    FormOps.ErrorBox("Check username and password.");

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

        // Returns DataTable for course name ComboBox
        // Runs different queries based on User Role
        public static DataTable GetCourseNames()
        {

            DataTable courseNamesTable = new DataTable();

            try
            {
                string courseNamesQuery;

                if (userRole.Equals("Teacher"))
                {
                    courseNamesQuery = "EXEC group1fa212330.spGetRegisteredCoursesForTeacher " +
                        "@User_ID = " + userID + ";";
                }
                else
                {
                    courseNamesQuery =
                        "SELECT Course_Name " +
                        "FROM group1fa212330.Courses " +
                        "ORDER BY Course_Name";
                }

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

        // Get Course ID using Course Name
        // Works for both Teachers and non-Teachers because--
        // Course Name field now has a Unique constraint
        public static int GetCourseID(string courseName)
        {
            try
            {
                string courseIDQuery =
                    "SELECT Course_ID " +
                    "FROM group1fa212330.Courses " +
                    "WHERE Course_Name = '" + courseName + "';";

                SqlDataAdapter courseIDAdapter = new SqlDataAdapter(courseIDQuery, _cntPrimarySchoolDatabase);

                DataTable courseIDTable = new DataTable();

                courseIDAdapter.Fill(courseIDTable);

                int courseID = Convert.ToInt32(courseIDTable.Rows[0][0]);

                courseIDAdapter.Dispose();

                courseIDTable.Clear();
                courseIDTable.Dispose();

                return courseID;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return 0;
            }
        }

        // Get instructor name as string using Course ID
        public static string GetInstructorName(int courseID)
        {
            try
            {
                string instructorNameQuery = "EXEC group1fa212330.spGetCourseInstructorName @Course_ID = " + courseID + ";";

                SqlDataAdapter instructorNameAdapter = new SqlDataAdapter(instructorNameQuery, _cntPrimarySchoolDatabase);

                DataTable instructorNameTable = new DataTable();

                instructorNameAdapter.Fill(instructorNameTable);

                string instructorName = Convert.ToString(instructorNameTable.Rows[0][0]);

                instructorNameAdapter.Dispose();

                instructorNameTable.Clear();
                instructorNameTable.Dispose();

                return instructorName;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return "[Instructor Name]";
            }
        }

        // Get Room ID as integer using Course ID
        public static int GetRoomID(int courseID)
        {
            try
            {
                string roomQuery =
                    "SELECT DISTINCT Room_ID " +
                    "FROM group1fa212330.Seating_Chart " +
                    "WHERE Course_ID = " + courseID + ";";

                SqlDataAdapter roomAdapter = new SqlDataAdapter(roomQuery, _cntPrimarySchoolDatabase);

                DataTable roomTable = new DataTable();

                roomAdapter.Fill(roomTable);

                int roomID = 0;

                if (roomTable.Rows.Count == 1)
                {
                    roomID = Convert.ToInt32(roomTable.Rows[0][0]);
                }

                roomAdapter.Dispose();

                roomTable.Clear();
                roomTable.Dispose();

                return roomID;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return 0;
            }
        }

        // Gets total seats as integer using Course ID
        public static int GetTotalSeats(int courseID)
        {
            try
            {
                string totalSeatsQuery = "EXEC group1fa212330.spGetTotalSeats @Course_ID = " + courseID + ";";

                SqlDataAdapter totalSeatsAdapter = new SqlDataAdapter(totalSeatsQuery, _cntPrimarySchoolDatabase);

                DataTable totalSeatsTable = new DataTable();

                totalSeatsAdapter.Fill(totalSeatsTable);

                int totalSeatsID = 0;

                if (totalSeatsTable.Rows.Count == 1)
                {
                    totalSeatsID = Convert.ToInt32(totalSeatsTable.Rows[0][0]);
                }

                totalSeatsAdapter.Dispose();

                totalSeatsTable.Clear();
                totalSeatsTable.Dispose();

                return totalSeatsID;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return 0;
            }
        }

        //Get Teacher information for Academic Officers - Teacher Tab
        public static void TeachersCommand(TextBox txUserID, TextBox txLName, TextBox txFName,
            TextBox txMName, TextBox txDOB, TextBox txEmail, TextBox txAddress, TextBox txCity,
            TextBox txState, TextBox txZip, TextBox txPhone)
        {
            try
            {
                //statement for the command string
                string sqlStatement = "EXEC group1fa212330.spTeachersForm;";
                //establish command object
                _sqlTeachersCommand = new SqlCommand(sqlStatement, _cntPrimarySchoolDatabase);
                //establish data adapter
                _daTeachers.SelectCommand = _sqlTeachersCommand;
                //fill DataTable
                _daTeachers.Fill(_dtTeachersTable);
                //bind controls to DataTable
                txUserID.DataBindings.Add("Text", _dtTeachersTable, "User_ID");
                txLName.DataBindings.Add("Text", _dtTeachersTable, "User_LName");
                txFName.DataBindings.Add("Text", _dtTeachersTable, "User_FName");
                txMName.DataBindings.Add("Text", _dtTeachersTable, "User_MName");
                txDOB.DataBindings.Add("Text", _dtTeachersTable, "User_DOB", true);
                txEmail.DataBindings.Add("Text", _dtTeachersTable, "User_Email");
                txAddress.DataBindings.Add("Text", _dtTeachersTable, "User_MailingAddress");
                txCity.DataBindings.Add("Text", _dtTeachersTable, "User_City");
                txState.DataBindings.Add("Text", _dtTeachersTable, "User_State");
                txZip.DataBindings.Add("Text", _dtTeachersTable, "User_Zip");
                txPhone.DataBindings.Add("Text", _dtTeachersTable, "User_Phone_Number");
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

        // Returns DataTable for Gradebook using Course ID
        public static DataTable GetGradebookTable(int courseID)
        {

            DataTable gradebookTable = new DataTable();

            try
            {
                string gradebookQuery = "EXEC group1fa212330.spGetGradebookTable @Course_ID = " + courseID + ";";

                SqlDataAdapter gradebookAdapter = new SqlDataAdapter(gradebookQuery, _cntPrimarySchoolDatabase);

                gradebookAdapter.Fill(gradebookTable);

                gradebookAdapter.Dispose();

                return gradebookTable;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return gradebookTable;
            }
        }

        // Returns a DataTable parallel to the Gradebook table that contains...
        // ...Assignment ID, Category ID, and Category Weight to be used in code
        public static DataTable GetHiddenGradebookTable(int courseID)
        {

            DataTable hiddenGradebookTable = new DataTable();

            try
            {
                string hiddenGradebookQuery = "EXEC group1fa212330.spGetHiddenGradebookTable @Course_ID = " + courseID + ";";

                SqlDataAdapter hiddenGradebookAdapter = new SqlDataAdapter(hiddenGradebookQuery, _cntPrimarySchoolDatabase);

                hiddenGradebookAdapter.Fill(hiddenGradebookTable);

                hiddenGradebookAdapter.Dispose();

                return hiddenGradebookTable;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return hiddenGradebookTable;
            }
        }

        // Updates the Gradebook table in a for loop
        // Uses the list of changed rows to be conditional
        // In other words, only updates rows that contain unsaved changes
        // Some cases, this will mean every row-- but not every case
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

                update.Dispose();

                MessageBox.Show("Database successfully updated.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Returns DataTable for Attendance using Course ID and Date (in string format)
        public static DataTable GetAttendanceTable(int courseID, string date)
        {

            DataTable attendTable = new DataTable();

            try
            {
                string attendQuery = "EXEC group1fa212330.spGetAttendanceTable @Course_ID = " + 
                    courseID + ", @Date = '" + date + "';";

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

        // Inserts into the Attendance table in a for loop
        // Uses the list of changed rows to be conditional
        // In other words, only inserts rows that contain unsaved changes
        // Some cases, this will mean every row-- but not every case
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

                    insert.Parameters.AddWithValue("@StudentID", attendanceTable.Rows[row][0]);

                    insert.Parameters.AddWithValue("@isPresent", attendanceTable.Rows[row][3]);

                    insert.Parameters.AddWithValue("@absenceReason", attendanceTable.Rows[row][5]);

                    insert.Parameters.AddWithValue("@isExcused", attendanceTable.Rows[row][4]);

                    DateTime date = Convert.ToDateTime(attendanceTable.Rows[row][6].ToString());

                    insert.Parameters.AddWithValue("@Date", date.ToString("yyyy-MM-dd"));

                    insert.ExecuteNonQuery();

                    insert.Parameters.Clear();
                }

                insert.Dispose();

                MessageBox.Show("Database successfully updated.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Updates the Attendance table in a for loop
        // Uses the list of changed rows to be conditional
        // In other words, only updates rows that contain unsaved changes
        // Some cases, this will mean every row-- but not every case
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

                    update.Parameters.AddWithValue("@isPresent", attendanceTable.Rows[row][3]);

                    update.Parameters.AddWithValue("@absenceReason", attendanceTable.Rows[row][5]);

                    update.Parameters.AddWithValue("@isExcused", attendanceTable.Rows[row][4]);

                    update.Parameters.AddWithValue("@CourseID", courseID);

                    update.Parameters.AddWithValue("@StudentID", attendanceTable.Rows[row][0]);

                    DateTime date = Convert.ToDateTime(attendanceTable.Rows[row][6].ToString());

                    update.Parameters.AddWithValue("@Date", date.ToString("yyyy-MM-dd"));

                    update.ExecuteNonQuery();

                    update.Parameters.Clear();
                }

                update.Dispose();

                MessageBox.Show("Database successfully updated.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Returns DataTable for Seating Chart using Course ID
        public static DataTable GetSeatingChartTable(int courseID)
        {

            DataTable seatsTable = new DataTable();

            try
            {
                string seatsQuery = "EXEC group1fa212330.spGetSeatingChartTable @Course_ID = " + courseID + ";";

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

        // Returns DataTable for Seats using Course ID
        public static DataTable GetSeatsList(int courseID)
        {

            DataTable seatsListTable = new DataTable();

            try
            {
                int roomID = GetRoomID(courseID);

                string seatsListQuery = "EXEC group1fa212330.spGetSeatsList @Room_ID = " + roomID + ";";

                SqlDataAdapter seatsListAdapter = new SqlDataAdapter(seatsListQuery, _cntPrimarySchoolDatabase);

                seatsListAdapter.Fill(seatsListTable);

                seatsListAdapter.Dispose();

                return seatsListTable;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return seatsListTable;
            }
        }

        // Updates the Seating Chart table in a for loop
        // Uses the list of changed rows to be conditional
        // In other words, only updates rows that contain unsaved changes
        // Some cases, this will mean every row-- but not every case
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

                update.Dispose();

                MessageBox.Show("Database successfully updated.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Returns DataTable for full names of students in the specified course using Course ID
        public static DataTable GetStudentsInCourse(int courseID)
        {

            DataTable studentsTable = new DataTable();

            try
            {
                string studentsQuery = "EXEC group1fa212330.spGetStudentsInCourse @Course_ID = " + courseID + ";";

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

        // Returns DataTable for courses that a student is registered for using Student ID
        public static DataTable GetRegisteredCoursesForStudent(int studentID)
        {

            DataTable coursesTable = new DataTable();

            try
            {
                string coursesQuery = "EXEC group1fa212330.spGetRegisteredCoursesForStudent @Student_ID = " + studentID + ";";

                SqlDataAdapter coursesAdapter = new SqlDataAdapter(coursesQuery, _cntPrimarySchoolDatabase);

                coursesAdapter.Fill(coursesTable);

                coursesAdapter.Dispose();

                return coursesTable;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return coursesTable;
            }
        }

        // Returns DataTable for courses that a teacher is registered for using User ID
        public static DataTable GetRegisteredCoursesForTeacher(int userID)
        {

            DataTable coursesTable = new DataTable();

            try
            {
                string coursesQuery = "EXEC group1fa212330.spGetRegisteredCoursesForTeacher " +
                        "@User_ID = " + userID + ";";

                SqlDataAdapter coursesAdapter = new SqlDataAdapter(coursesQuery, _cntPrimarySchoolDatabase);

                coursesAdapter.Fill(coursesTable);

                coursesAdapter.Dispose();

                return coursesTable;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return coursesTable;
            }
        }

        // Returns DataTable for courses that a student is NOT registered for using Student ID
        public static DataTable GetAvailableCoursesForStudent(int studentID)
        {

            DataTable coursesTable = new DataTable();

            try
            {
                string coursesQuery = "EXEC group1fa212330.spGetAvailableCoursesForStudent @Student_ID = " + studentID + ";";

                SqlDataAdapter coursesAdapter = new SqlDataAdapter(coursesQuery, _cntPrimarySchoolDatabase);

                coursesAdapter.Fill(coursesTable);

                coursesAdapter.Dispose();

                return coursesTable;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return coursesTable;
            }
        }

        // Returns DataTable for courses with no registered teacher
        public static DataTable GetAvailableCoursesForTeacher()
        {

            DataTable coursesTable = new DataTable();

            try
            {
                string coursesQuery = "EXEC group1fa212330.spGetAvailableCoursesForTeacher;";

                SqlDataAdapter coursesAdapter = new SqlDataAdapter(coursesQuery, _cntPrimarySchoolDatabase);

                coursesAdapter.Fill(coursesTable);

                coursesAdapter.Dispose();

                return coursesTable;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return coursesTable;
            }
        }

        // Returns assignment Weight as a double using Assignment Name
        public static double GetAssignmentWeight(string assignmentName)
        {
            try
            {
                string weightQuery = "EXEC group1fa212330.spGetAssignmentWeight @Assignment_Name = " + assignmentName + ";";

                SqlDataAdapter weightAdapter =
                    new SqlDataAdapter(weightQuery, _cntPrimarySchoolDatabase);

                DataTable weightTable = new DataTable();

                weightAdapter.Fill(weightTable);

                double weight = Convert.ToDouble(weightTable.Rows[0][0]);

                weightAdapter.Dispose();

                weightTable.Clear();
                weightTable.Dispose();

                return weight;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return 0;
            }
        }

        // Establishes objects for Assignments form
        // Fills DataTable
        // Binds TextBoxes to DataTable
        public static void DatabaseCommandAssignments(TextBox tbxAssignmentID,
            TextBox tbxCategory, TextBox tbxAssignmentName, TextBox tbxDescription)
        {
            try
            {
                assignmentsTable = new DataTable();

                string query = "EXEC group1fa212330.spDatabaseCommandAssignments;";

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

        // Establishes objects for Students form
        // Fills DataTable
        // Binds TextBoxes to DataTable
        public static void DatabaseCommandStudents(TextBox tbxStudentID,
            TextBox tbxLastName, TextBox tbxFirstName, TextBox tbxMiddleName,
            TextBox tbxDateOfBirth, TextBox tbxAddress, TextBox tbxCity,
            TextBox tbxState, TextBox tbxZip, TextBox tbxG1Name,
            TextBox tbxG1CellPhone, TextBox tbxG1WorkPhone, TextBox tbxG1PlaceOfWork,
            TextBox tbxG2Name, TextBox tbxG2CellPhone, TextBox tbxG2WorkPhone,
            TextBox tbxG2PlaceOfWork, TextBox tbxEC, TextBox tbxEcCellPhone)
        {
            try
            {
                studentsTable = new DataTable();

                string query = "EXEC group1fa212330.spDatabaseCommandStudents;";

                studentsCommand = new SqlCommand(query, _cntPrimarySchoolDatabase);

                studentsAdapter = new SqlDataAdapter();

                studentsAdapter.SelectCommand = studentsCommand;

                studentsAdapter.Fill(studentsTable);

                tbxStudentID.DataBindings.Add("Text", studentsTable, "Student_ID");
                tbxLastName.DataBindings.Add("Text", studentsTable, "Last_Name");
                tbxFirstName.DataBindings.Add("Text", studentsTable, "First_Name");
                tbxMiddleName.DataBindings.Add("Text", studentsTable, "Middle_Name");
                tbxDateOfBirth.DataBindings.Add("Text", studentsTable, "Date_Of_Birth", true);
                tbxAddress.DataBindings.Add("Text", studentsTable, "Mailing_Address");
                tbxCity.DataBindings.Add("Text", studentsTable, "City");
                tbxState.DataBindings.Add("Text", studentsTable, "State");
                tbxZip.DataBindings.Add("Text", studentsTable, "Zip");
                tbxG1Name.DataBindings.Add("Text", studentsTable, "Guardian_1_Name");
                tbxG1CellPhone.DataBindings.Add("Text", studentsTable, "Guardian_1_Phone_Number");
                tbxG1WorkPhone.DataBindings.Add("Text", studentsTable, "Guardian_1_Work_Number");
                tbxG1PlaceOfWork.DataBindings.Add("Text", studentsTable, "Guardian_1_Place_of_Work");
                tbxG2Name.DataBindings.Add("Text", studentsTable, "Guardian_2_Name");
                tbxG2CellPhone.DataBindings.Add("Text", studentsTable, "Guardian_2_Phone_Number");
                tbxG2WorkPhone.DataBindings.Add("Text", studentsTable, "Guardian_2_Work_Number");
                tbxG2PlaceOfWork.DataBindings.Add("Text", studentsTable, "Guardian_2_Place_of_Work");
                tbxEC.DataBindings.Add("Text", studentsTable, "Emergency_Contact");
                tbxEcCellPhone.DataBindings.Add("Text", studentsTable, "Emergency_Contact_Phone_Number");
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Establishes objects for Courses form
        // Fills DataTable
        // Binds TextBoxes to DataTable
        public static void DatabaseCommandCourses(TextBox tbxCourseID,
            TextBox tbxCourseName, TextBox tbxDescription, TextBox tbxUserID)
        {
            try
            {
                coursesTable = new DataTable();

                string query = "EXEC group1fa212330.spDatabaseCommandCourses;";

                coursesCommand = new SqlCommand(query, _cntPrimarySchoolDatabase);

                coursesAdapter = new SqlDataAdapter();

                coursesAdapter.SelectCommand = coursesCommand;

                coursesAdapter.Fill(coursesTable);

                tbxCourseID.DataBindings.Add("Text", coursesTable, "Course_ID");
                tbxCourseName.DataBindings.Add("Text", coursesTable, "Course_Name");
                tbxDescription.DataBindings.Add("Text", coursesTable, "Course_Description");
                tbxUserID.DataBindings.Add("Text", coursesTable, "User_ID");
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Updates database for Assignments form
        public static void UpdateAssignments()
        {

            StringBuilder errorMessages = new StringBuilder();

            try
            {
                SqlCommandBuilder assignmentAdapterCommands =new SqlCommandBuilder(assignmentsAdapter);

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

        // Updates database for Students form
        public static void UpdateStudents()
        {

            StringBuilder errorMessages = new StringBuilder();

            try
            {
                SqlCommandBuilder studentsAdapterCommands = new SqlCommandBuilder(studentsAdapter);

                studentsAdapter.Update(studentsTable);
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

        // Updates database for Courses form
        public static void UpdateCourses()
        {

            StringBuilder errorMessages = new StringBuilder();

            try
            {
                SqlCommandBuilder coursesAdapterCommands = new SqlCommandBuilder(coursesAdapter);

                coursesAdapter.Update(coursesTable);
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

        // Clears and disposes objects used for Assignments forms
        public static void DisposeAssignments()
        {
            try
            {
                if (assignmentsTable != null)
                {
                    assignmentsTable.Clear();
                    assignmentsTable.Dispose();
                }

                if (assignmentsCommand != null)
                {
                    assignmentsCommand.Dispose();
                }

                if (assignmentsAdapter != null)
                {
                    assignmentsAdapter.Dispose();
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Clears and disposes objects used for Students forms
        public static void DisposeStudents()
        {
            try
            {
                if (studentsTable != null)
                {
                    studentsTable.Clear();
                    studentsTable.Dispose();
                }

                if (studentsCommand != null)
                {
                    studentsCommand.Dispose();
                }

                if (studentsAdapter != null)
                {
                    studentsAdapter.Dispose();
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Clears and disposes objects used for Courses forms
        public static void DisposeCourses()
        {
            try
            {
                if (coursesTable != null)
                {
                    coursesTable.Clear();
                    coursesTable.Dispose();
                }

                if (coursesCommand != null)
                {
                    coursesCommand.Dispose();
                }

                if (coursesAdapter != null)
                {
                    coursesAdapter.Dispose();
                }
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Returns DataTable for Categories
        public static DataTable GetCategoriesTable()
        {

            DataTable categoriesTable = new DataTable();

            try
            {
                string categoriesQuery = "EXEC group1fa212330.spGetCategoriesTable;";

                SqlDataAdapter categoriesAdapter = new SqlDataAdapter(categoriesQuery, _cntPrimarySchoolDatabase);

                categoriesAdapter.Fill(categoriesTable);

                categoriesAdapter.Dispose();

                return categoriesTable;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return categoriesTable;
            }
        }

        // Returns DataTable for Teachers
        public static DataTable GetTeachersTable()
        {

            DataTable teachersTable = new DataTable();

            try
            {
                string teachersQuery = "EXEC group1fa212330.spGetTeachersTable;";

                SqlDataAdapter teachersAdapter = new SqlDataAdapter(teachersQuery, _cntPrimarySchoolDatabase);

                teachersAdapter.Fill(teachersTable);

                teachersAdapter.Dispose();

                return teachersTable;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return teachersTable;
            }
        }

        // Returns DataTable for Available Students
        public static DataTable GetStudentsNotInCourse(int courseID)
        {

            DataTable availableStudentsTable = new DataTable();

            try
            {
                string availableStudentsQuery = "EXEC group1fa212330.spGetAvailableStudents @Course_ID = " + courseID + ";";

                SqlDataAdapter availableStudentsAdapter = new SqlDataAdapter(availableStudentsQuery, _cntPrimarySchoolDatabase);

                availableStudentsAdapter.Fill(availableStudentsTable);

                availableStudentsAdapter.Dispose();

                return availableStudentsTable;
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
                return availableStudentsTable;
            }
        }

        // Takes Course ID and Assignment ID as arguments
        // Checks to see if the assignment is in the course
        // If no, adds the assignment to the course in a for loop
        // If yes, displays an error message
        public static void AddAssignmentToCourse(int courseID, int assignmentID)
        {
            try
            {
                string dataCheckQuery = "EXEC group1fa212330.spCheckAssignmentsInCourse @Course_ID = " +
                    courseID + ", @Assignment_ID = " + assignmentID + ";";

                SqlDataAdapter dataCheckAdapter = new SqlDataAdapter(dataCheckQuery, _cntPrimarySchoolDatabase);

                DataTable dataCheckTable = new DataTable();

                dataCheckAdapter.Fill(dataCheckTable);

                if (dataCheckTable.Rows.Count == 0)
                {
                    string studentIDsQuery
                    = "SELECT Student_ID " +
                    "FROM group1fa212330.Student_Registration " +
                    "WHERE Course_ID = " + courseID + ";";

                    SqlDataAdapter studentIDsAdapter = new SqlDataAdapter(studentIDsQuery, _cntPrimarySchoolDatabase);

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

                    studentIDsTable.Clear();
                    studentIDsTable.Dispose();

                    insert.Dispose();

                    MessageBox.Show("Assignment successfully added to course.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    FormOps.ErrorBox("Cannot add an assignment that is already in the course.");
                }

                dataCheckAdapter.Dispose();

                dataCheckTable.Clear();
                dataCheckTable.Dispose();
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Add Student:
        // INSERT INTO Student Registration
        // INSERT INTO Gradebook
        // INSERT INTO Seating Chart
        public static void AddStudentToCourse(int studentID, int courseID)
        {
            try
            {
                int roomID = GetRoomID(courseID);

                string availableSeatsQuery = "EXEC group1fa212330.spGetAvailableSeatsForRoom @Room_ID = " + roomID + ";";

                SqlDataAdapter availableSeatsAdapter = new SqlDataAdapter(availableSeatsQuery, _cntPrimarySchoolDatabase);

                DataTable availableSeatsTable = new DataTable();

                availableSeatsAdapter.Fill(availableSeatsTable);


                if (availableSeatsTable.Rows.Count > 0)
                {
                    SqlCommand registerStudentCommand = new SqlCommand("EXEC group1fa212330.spAddStudentToCourse @Student_ID = " +
                    studentID + ", @Course_ID = " + courseID + ";", _cntPrimarySchoolDatabase);

                    registerStudentCommand.ExecuteNonQuery();

                    registerStudentCommand.Dispose();


                    string assignmentsQuery = "EXEC group1fa212330.spGetAssignmentsInCourse @Course_ID = " + courseID + ";";

                    SqlDataAdapter assignmentsAdapter = new SqlDataAdapter(assignmentsQuery, _cntPrimarySchoolDatabase);

                    DataTable assignmentsTable = new DataTable();

                    assignmentsAdapter.Fill(assignmentsTable);

                    SqlCommand addStudentToGradebookCommand = new SqlCommand("EXEC group1fa212330.spAddStudentToGradebook @Course_ID = " + 
                        courseID + ", @Student_ID = " + studentID + ", @Assignment_ID = @AssignmentID;", _cntPrimarySchoolDatabase);

                    for (int x = 0; x < assignmentsTable.Rows.Count; x++)
                    {
                        addStudentToGradebookCommand.Parameters.AddWithValue("@AssignmentID", Convert.ToInt32(assignmentsTable.Rows[x][0]));

                        addStudentToGradebookCommand.ExecuteNonQuery();

                        addStudentToGradebookCommand.Parameters.Clear();
                    }

                    addStudentToGradebookCommand.Dispose();

                    assignmentsAdapter.Dispose();

                    assignmentsTable.Clear();
                    assignmentsTable.Dispose();


                    int seatID = Convert.ToInt32(availableSeatsTable.Rows[0][0]);

                    SqlCommand seatStudentCommand = new SqlCommand("EXEC group1fa212330.spAddStudentToSeatingChart @Student_ID = " + 
                        studentID + ", @Course_ID = " + courseID + ", @Room_ID = " + roomID + ", @Seat_ID = " + seatID + ";", _cntPrimarySchoolDatabase);

                    seatStudentCommand.ExecuteNonQuery();

                    seatStudentCommand.Dispose();

                    MessageBox.Show("Student successfully added to course.", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    FormOps.ErrorBox("No available seats in course.");
                }

                availableSeatsAdapter.Dispose();

                availableSeatsTable.Clear();
                availableSeatsTable.Dispose();
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Adds a placeholder student to a course (call when course is first created)
        public static void AddPlaceholderStudentToNewCourse(int courseID)
        {
            try
            {
                SqlCommand addCommand = new SqlCommand("EXEC group1fa212330.spAddPlaceholderStudentToNewCourse @Course_ID = " + 
                    courseID + ";", _cntPrimarySchoolDatabase);

                addCommand.ExecuteNonQuery();

                addCommand.Dispose();
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Remove Student:
        // DELETE from Gradebook WHERE Course ID
        // DELETE from Attendance WHERE Course ID
        // DELETE from Seating Chart WHERE Course ID
        // DELETE from Student Registration WHERE Course ID
        public static void RemoveStudentFromCourse(int studentID, int courseID)
        {
            try
            {
                SqlCommand removalCommand = new SqlCommand("EXEC group1fa212330.spRemoveStudentFromCourse @Student_ID = " +
                    studentID + ", @Course_ID = " + courseID + ";", _cntPrimarySchoolDatabase);

                removalCommand.ExecuteNonQuery();

                removalCommand.Dispose();

                MessageBox.Show("Student successfully removed from course.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        public static void AddTeacherToCourse(int userID, string courseName)
        {
            try
            {
                int courseID = GetCourseID(courseName);

                SqlCommand addCommand = new SqlCommand("EXEC group1fa212330.spAddTeacherToCourse " +
                    "@User_ID = " + userID + ", @Course_ID = " + courseID + ";", _cntPrimarySchoolDatabase);

                addCommand.ExecuteNonQuery();

                addCommand.Dispose();

                MessageBox.Show("Teacher successfully added to course.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox("AddTeacherToCourse" + ex.Message);
            }
        }

        public static void RemoveTeacherFromCourse(string courseName)
        {
            try
            {
                int courseID = GetCourseID(courseName);

                SqlCommand removalCommand = new SqlCommand("EXEC group1fa212330.spRemoveTeacherFromCourse " +
                    "@Course_ID = " + courseID + ";", _cntPrimarySchoolDatabase);

                removalCommand.ExecuteNonQuery();

                removalCommand.Dispose();

                MessageBox.Show("Teacher successfully removed from course.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox("RemoveTeacherFromCourse: " + ex.Message);
            }
        }

        // Delete Student:
        // DELETE from Gradebook
        // DELETE from Attendance
        // DELETE from Seating Chart
        // DELETE from Student Registration
        public static void DeleteStudentFromAncillaryTables(int studentID)
        {
            try
            {
                SqlCommand deletionCommand = new SqlCommand("EXEC group1fa212330.spDeleteStudentFromAncillaryTables @Student_ID = " + 
                    studentID + ";", _cntPrimarySchoolDatabase);

                deletionCommand.ExecuteNonQuery();

                deletionCommand.Dispose();
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Delete Course:
        // DELETE from Gradebook
        // DELETE from Attendance
        // DELETE from Seating Chart
        // DELETE from Student Registration
        public static void DeleteCourseFromAncillaryTables(int courseID)
        {
            try
            {
                SqlCommand deletionCommand = new SqlCommand("EXEC group1fa212330.spDeleteCourseFromAncillaryTables @Course_ID = " +
                    courseID + ";", _cntPrimarySchoolDatabase);

                deletionCommand.ExecuteNonQuery();

                deletionCommand.Dispose();
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        // Takes Course ID and Assignment ID as arguments
        // Checks to see if the assignment is in the course
        // If yes, removes the assignment from the course in a for loop
        // If no, displays an error message
        public static void RemoveAssignmentFromCourse(int courseID, int assignmentID)
        {
            try
            {
                string dataCheckQuery = "EXEC group1fa212330.spCheckAssignmentsInCourse @Course_ID = " + 
                    courseID + ", @Assignment_ID = " + assignmentID + ";";

                SqlDataAdapter dataCheckAdapter = new SqlDataAdapter(dataCheckQuery, _cntPrimarySchoolDatabase);

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

                    delete.Dispose();

                    MessageBox.Show("Assignment successfully removed from course.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    FormOps.ErrorBox("Cannot remove an assignment that is not in the course.");
                }

                dataCheckAdapter.Dispose();

                dataCheckTable.Clear();
                dataCheckTable.Dispose();
            }
            catch (Exception ex)
            {
                FormOps.ErrorBox(ex.Message);
            }
        }

        //Establishing Add Command Objects - rth040322
        private static SqlCommand _sqlUsersCommand;                                  //Cmd Object for Users Table

        //Establishing Data Adapter - rth040322
        private static SqlDataAdapter _daUsers = new SqlDataAdapter();               //SqlDataAdapter Object for Users Table

        //Establishing Data Tables - rth040322
        private static DataTable _dtUsersTable = new DataTable();                    //DataTable Object for Users Table

        public static DataTable DTUsersTable
        {
            get { return _dtUsersTable; }
        }

        public static void UserLoginObjectDisposal()
        {
            //Dispose of UserLogin command adapter and objects
            _sqlUsersCommand.Dispose();
            _daUsers.Dispose();
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



        //Get Users information for Users - 
        public static void GetUserRecords(TextBox txUserID, TextBox txLName, TextBox txFname,
            TextBox txMName, TextBox txDOB, TextBox txStreet, TextBox txCity,
            TextBox txState, TextBox txZip, TextBox txPhone, TextBox txRole, TextBox txUserName, TextBox txPassword, TextBox txEmail)
        {
            try
            {
                //statement for the command string
                string sqlStatement = "SELECT * FROM group1fa212330.Users ORDER BY User_LName, User_FName;";
                //establish command object
                _sqlUsersCommand = new SqlCommand(sqlStatement, _cntPrimarySchoolDatabase);
                //establish data adapter
                _daUsers.SelectCommand = _sqlUsersCommand;
                //fill DataTable
                _daUsers.Fill(_dtUsersTable);
                //bind controls to DataTable
                txUserID.DataBindings.Add("Text", _dtUsersTable, "User_ID");
                txLName.DataBindings.Add("Text", _dtUsersTable, "User_LName");
                txFname.DataBindings.Add("Text", _dtUsersTable, "User_FName");
                txMName.DataBindings.Add("Text", _dtUsersTable, "User_MName");
                txDOB.DataBindings.Add("Text", _dtUsersTable, "User_DOB", true);
                txStreet.DataBindings.Add("Text", _dtUsersTable, "User_MailingAddress");
                txCity.DataBindings.Add("Text", _dtUsersTable, "User_City");
                txState.DataBindings.Add("Text", _dtUsersTable, "User_State");
                txZip.DataBindings.Add("Text", _dtUsersTable, "User_Zip");
                txPhone.DataBindings.Add("Text", _dtUsersTable, "User_Phone_Number");
                txRole.DataBindings.Add("Text", _dtUsersTable, "Role_ID");
                txUserName.DataBindings.Add("Text", _dtUsersTable, "User_LoginName");
                txPassword.DataBindings.Add("Text", _dtUsersTable, "User_LoginPwd");
                txEmail.DataBindings.Add("Text", _dtUsersTable, "User_Email");

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

        // Updates the User Information
        public static void UpdateUserRecordsOnClose()
        {
            try
            {
                //save the updated phone table
                SqlCommandBuilder UsersAdapterCommands = new SqlCommandBuilder(_daUsers);
                _daUsers.Update(_dtUsersTable);

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
                    MessageBox.Show(_errorMessages.ToString(), "Error Update Users", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {//handles generic ones here
                    MessageBox.Show(ex.Message + "Error (PO4)", "Error Update Users", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void UpdateTeacherRecordsOnClose()
        {
            try
            {
                //save the updated phone table
                SqlCommandBuilder TeachersAdapterCommands = new SqlCommandBuilder(_daTeachers);
                _daTeachers.Update(_dtTeachersTable);

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
                    MessageBox.Show(_errorMessages.ToString(), "Error Update Users", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {//handles generic ones here
                    MessageBox.Show(ex.Message + "Error (PO4)", "Error Update Users", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
