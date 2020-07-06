using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hi_TechDistribution.DataAccess;


namespace Hi_TechDistribution.Business
{
    public class User
    {
        private int userId;
        private string password;
    

        public int UserId { get => userId; set => userId = value; }
        public string Password { get => password; set => password = value; }
       
        public void SaveUser(User user1)
        {
            UserDB.SaveRecord(user1);
        }

        public List<User> GetUserList()
        {
            return (UserDB.GetRecordList());
        }

        public void DeleteUser(int userId)
        {
            UserDB.DeleteRecord(userId);
        }

        public void UpdateUser(User u1)
        {
            UserDB.UpdateRecord(u1);
        }

        public User SearchUser(int userId)
        {
            return (UserDB.SearchRecord(userId));
        }

    }
}
