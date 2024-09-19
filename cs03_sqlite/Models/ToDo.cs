using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs03_sqlite.Models
{
    internal class ToDo
    {
        public int ToDoId { get; set; }
        public required string Description { get; set; }
        public bool Done { get; set; }
        public Human? From { get; set; }
        public int FromId { get; set; }
        public Human? To { get; set; }
        public int ToId { get; set; }
    }
}
