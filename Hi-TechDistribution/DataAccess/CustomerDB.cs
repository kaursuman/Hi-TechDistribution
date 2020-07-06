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
    public class CustomerDB
    {
        public static List<Customer> ListRecord()
        {
            List<Customer> listCust = new List<Customer>();
            Customer cust;
            SqlConnection connDb = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", connDb);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cust = new Customer();
                    cust.CustomerId = Convert.ToInt32(reader["CustomerId"]);
                    cust.Name = reader["Name"].ToString();
                    cust.Street = reader["Street"].ToString();
                    cust.City = reader["City"].ToString();
                    cust.PostalCode = reader["PostalCode"].ToString();
                    cust.PhoneNumber = reader["PhoneNumber"].ToString();
                    cust.FaxNumber = reader["FaxNumber"].ToString();
                    cust.CreditLimit = Convert.ToInt32(reader["CreditLimit"]);

                    listCust.Add(cust);
                }

            }
            else
            {
                listCust = null;
            }
            connDb.Close();
            return listCust;
        }
        
    }

}

