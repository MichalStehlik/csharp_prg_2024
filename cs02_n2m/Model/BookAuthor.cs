using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs02_n2m.Model
{
    internal class BookAuthor
    {
        //[Key]
        public int BookId { get; set; }
        //[Key]
        public int AuthorId { get; set; }
        public Book? Book { get; set; }
        public Author? Author { get; set; }
    }
}
