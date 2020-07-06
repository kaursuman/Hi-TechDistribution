using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Hi_TechDistribution.Business;


namespace Hi_TechDistribution.DataAccess
{
    public class UserDB
    {
    
        public static void SaveRecord(User user1)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            //create and customize the object
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "INSERT INTO Users(UserId,Password) VALUES(@UserId,@Password)";
            cmd.Parameters.AddWithValue("@UserId", user1.UserId);
            cmd.Parameters.AddWithValue("@Password", user1.Password);           
            cmd.ExecuteNonQuery();
            //close connection
            connDB.Close();
        }

        public static List<User> GetRecordList()
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            List<User> listUser = new List<User>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "SELECT * FROM Users";
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    User u1 = new User();// create the object here, not outside
                    u1.UserId = Convert.ToInt32(reader["UserId"]);
                    u1.Password = reader["Password"].ToString();
                    
                    listUser.Add(u1);
                }
            }
            else
            {
                listUser = null;
            }

            return listUser;
        }

        public static void DeleteRecord(int userId)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            User u1 = new User();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "DELETE FROM Users WHERE UserId = @UserId ";
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.ExecuteNonQuery();

            connDB.Close();
        }

        public static void UpdateRecord(User u1)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;

            cmd.CommandText = "UPDATE Users SET Password = @Password WHERE UserId =@UserId";
            cmd.Parameters.AddWithValue("@UserId", u1.UserId);
            cmd.Parameters.AddWithValue("@Password", u1.Password);            
            cmd.ExecuteNonQuery();

            connDB.Close();

        }

        public static User SearchRecord(int userId)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            User u1 = new User();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "Select * from Users where UserId = @UserId ";
            cmd.Parameters.AddWithValue("@UserId", userId);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                u1.UserId = Convert.ToInt32(reader["UserId"]);
                u1.Password = reader["Password"].ToString();               
            }
            else
            {
                u1 = null;
            }

            return u1;
        }

    }
}
