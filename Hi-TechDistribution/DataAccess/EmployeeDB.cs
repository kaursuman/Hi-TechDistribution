using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Hi_TechDistribution.Business;

namespace Hi_TechDistribution.DataAccess
{
    public class EmployeeDB
    {
        public static void SaveRecord(Employee emp)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            //create and customize the object
            SqlCommand cmd = new SqlCommand("INSERT INTO EMPLOYEES(FirstName,LastName,JobTitle) VALUES(@FirstName,@LastName,@JobTitle)",connDB);
            //cmd.Parameters.AddWithValue("@EmployeeID", emp.EmployeeId);
            cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmd.Parameters.AddWithValue("@LastName", emp.LastName);
            cmd.Parameters.AddWithValue("@JobTitle", emp.JobTitle);
            cmd.ExecuteNonQuery();
            //close connection
            connDB.Close();
        }

        //public static bool IsUniqueId(int tempId)
        //{
        //    SqlConnection connDB = UtilityDB.ConnectDB();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = connDB;
        //    cmd.CommandText = "SELECT * FROM Employees WHERE EmployeeId = " + tempId;

        //    int id = Convert.ToInt32(cmd.ExecuteScalar());
        //    if (id != 0)
        //    {
        //        connDB.Close();
        //        return false;
        //    }

        //    connDB.Close();
        //    return true;
        //}


        public static List<Employee> GetRecordList()
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            List<Employee> listEmp = new List<Employee>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM EMPLOYEES",connDB);            
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Employee emp = new Employee();// create the object here, not outside
                    emp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                    emp.FirstName = reader["FirstName"].ToString();
                    emp.LastName = reader["LastName"].ToString();
                    emp.JobTitle = reader["JobTitle"].ToString();
                    listEmp.Add(emp);
                }
            }
            else
            {
                listEmp = null;
            }

            return listEmp;
        }

        public static void DeleteRecord(int empId)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand("DELETE FROM Employees WHERE EmployeeId = @EmployeeId ",connDB);           
            cmd.Parameters.AddWithValue("@EmployeeId", empId);
            cmd.ExecuteNonQuery();

            connDB.Close();
        }

        public static void UpdateRecord(Employee emp)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;

            cmd.CommandText = "UPDATE Employees SET FirstName = @FirstName,LastName = @LastName, JobTitle = @JobTitle WHERE EmployeeId =@EmployeeId";
            cmd.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
            cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmd.Parameters.AddWithValue("@LastName", emp.LastName);
            cmd.Parameters.AddWithValue("@JobTitle", emp.JobTitle);
            cmd.ExecuteNonQuery();

            //close connection
            connDB.Close();

        }

        public static Employee SearchRecord(int empId)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            Employee emp = new Employee();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "Select * from Employees where EmployeeID = @EmployeeID ";
            cmd.Parameters.AddWithValue("@EmployeeID", empId);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                emp.FirstName = reader["FirstName"].ToString();
                emp.LastName = reader["LastName"].ToString();
                emp.JobTitle = reader["JobTitle"].ToString();
            }
            else
            {
                emp = null;
            }

            return emp;
        }

        public static List<Employee> SearchRecord(string name)
        {
            List<Employee> listEmp = new List<Employee>();
            SqlConnection connDB = UtilityDB.ConnectDB();

            SqlCommand cmd = new SqlCommand("SELECT * FROM EMPLOYEES where FirstName = @FirstName OR LastName = @LastName");
            cmd.Connection = connDB;
            cmd.Parameters.AddWithValue("@FirstName", name);
            cmd.Parameters.AddWithValue("@LastName", name);
            SqlDataReader reader = cmd.ExecuteReader();
            Employee emp;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    emp = new Employee();// create the object here, not outside
                    emp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                    emp.FirstName = reader["FirstName"].ToString();
                    emp.LastName = reader["LastName"].ToString();
                    emp.JobTitle = reader["JobTitle"].ToString();
                    listEmp.Add(emp);
                }
            }
            else
            {
                listEmp = null;
            }

            return listEmp;
        }

    }
}
