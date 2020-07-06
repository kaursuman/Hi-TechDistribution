using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hi_TechDistribution.Business
{
    public class BookAuthor
    {
        private int isbn;
        private int authorId;
        private int yearPublished;

        public int Isbn { get => isbn; set => isbn = value; }
        public int AuthorId { get => authorId; set => authorId = value; }
        public int YearPublished { get => yearPublished; set => yearPublished = value; }
    }
}
