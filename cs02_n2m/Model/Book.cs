using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs02_n2m.Model
{
    internal class Book
    {
        public int BookId { get; set; }
        public required string Title { get; set; }
        //public ICollection<Author>? Authors { get; set; }
        public ICollection<BookAuthor>? BookAuthors { get; set; }
    }
}
