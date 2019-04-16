using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooks.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public string BookGenre { get; set; }
        public string BookStatus { get; set; }
        public int BookPagesNum { get; set; }
    }
}
