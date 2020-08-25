using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItiWfcSelfHosted
{
    public class Service1 : IService1
    {
        private static SqlConnection con;

       
        public BranchData getBranchsData()
        {
            BranchData branch = new BranchData();

            string queryString = "SELECT * from Branchs ";
            branch.branchsTable = getTable(queryString, "Branchs");


            queryString = "SELECT BranchID,_BranchConfigurationsKeyID,BranchConfigurationsValue from BranchConfigurations ";
            branch.configTable = getTable(queryString, "Config");

            queryString = "SELECT _BranchConfigurationsKeyID,NameE,_BranchConfigurationKeyValue from _BranchConfigurationKeys ";
            branch.configKeysTable = getTable(queryString, "ConfigKeys");

            return branch;
        }

        public InstructorData getInstructorsData()
        {
            InstructorData instructors = new InstructorData();

            string queryString = "SELECT * from Employees ";
            instructors.InstructorsTable = getTable(queryString, "Instructors");

            queryString = "SELECT EmployeeID,_EmployeeConfigurationsKeyID,EmployeeConfigurationsValue from EmployeeConfigurations ";
            instructors.configTable = getTable(queryString, "Config");

            queryString = "SELECT _EmployeeConfigurationsKeyID,NameE,_EmployeeConfigurationKeyValue from _EmployeeConfigurationKeys ";
            instructors.configKeysTable = getTable(queryString, "ConfigKeys");

            return instructors;
        }

        public StudentData getStudentsData()
        {
            StudentData students = new StudentData();

            string queryString = "SELECT * from Students";
            students.studentsTable = getTable(queryString, "Students");

            queryString = "SELECT StudentID,_StudentConfigurationsKeyID,StudentConfigurationsValue from StudentConfigurations ";
            students.configTable = getTable(queryString, "Config");

            queryString = "SELECT _StudentConfigurationsKeyID,NameE,_StudentConfigurationKeyValue from _StudentConfigurationKeys ";
            students.configKeysTable = getTable(queryString, "ConfigKeys");

            return students;
        }

        private DataTable getTable(string query, string tableName)
        {
            SqlCommand sqlCommand = new SqlCommand(query, con);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable(tableName);
            dataAdapter.Fill(dataTable);
            return dataTable;

        }

        public static void sqlConnect(string connectionString)
        {
            if (con == null)
            {
                //ServerConfig.serverName = "DESKTOP-LHMVI7Q\\SQLEXPRESS";
                //ServerConfig.dbName = "master";
                //ServerConfig.userID = "sa";
                //ServerConfig.password = "121212qw";



          
                while (!IsServerConnected(connectionString))
                {
                    Console.WriteLine("-----SQL Server Connection error please Enter server data-----");
                    Console.WriteLine("server Name : ");
                    ServerConfig.serverName = Console.ReadLine();

                    Console.WriteLine("\nDatabase Name : ");
                    ServerConfig.dbName = Console.ReadLine();

                    Console.WriteLine("\nusername : ");
                    ServerConfig.userID = Console.ReadLine();

                    Console.WriteLine("\npassword : ");
                    ServerConfig.password = Utils.GetPassword();


                    connectionString = "Data Source=" + ServerConfig.serverName +
                        ";Initial Catalog=" + ServerConfig.dbName + ";Persist Security Info=True;" +
                        "User ID=" + ServerConfig.userID + ";Password=" + ServerConfig.password;
                    Console.WriteLine("\n");
                }


            }


        }

        /// <summary>
        /// Test that the server is connected
        /// </summary>
        /// <param name="connectionString">The connection string</param>
        /// <returns>true if the connection is opened</returns>
        private static bool IsServerConnected(string connectionString)
        {

            con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }

        }

    }
}
