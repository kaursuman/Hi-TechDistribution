using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hi_TechDistribution.Business
{
    public class Author
    {
        private int authorId;
        private string firstName;
        private string lastName;
        private string email;

        public int AuthorId { get => authorId; set => authorId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
    }
}
