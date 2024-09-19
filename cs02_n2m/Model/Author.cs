using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs02_n2m.Model
{
    internal class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public ICollection<Book>? Books { get; set; }
        //public ICollection<BookAuthor>? BookAuthors { get; set; }
    }
}
