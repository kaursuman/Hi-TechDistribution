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
    public static class BookDB
    {
        public static void SaveRecord(Book book1)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();            
            SqlCommand cmd = new SqlCommand("INSERT INTO BOOKS(ISBN,Title,UnitPrice,QuantityOnHand,CategoryId,PublisherId) VALUES(@ISBN,@Title,@UnitPrice,@QuantityOnHand,@CategoryId,PublisherId)", connDB);
            
            cmd.Parameters.AddWithValue("@ISBN", book1.Isbn);
            cmd.Parameters.AddWithValue("@Title", book1.Title);
            cmd.Parameters.AddWithValue("@UnitPrice", book1.UnitPrice);
            cmd.Parameters.AddWithValue("@QuantityOnHand", book1.QuantityOnHand);
            cmd.Parameters.AddWithValue("@CategoryId", book1.CategoryId);
            cmd.Parameters.AddWithValue("@PublisherId", book1.PublisherId);

            cmd.ExecuteNonQuery();
            connDB.Close();
        }
    }
}
