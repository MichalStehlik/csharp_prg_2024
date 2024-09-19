using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs03_sqlite.Models
{
    internal class Human
    {
        public int HumanId { get; set; }
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public ICollection<ToDo>? CreatedTasks { get; set; }
        public ICollection<ToDo>? AssignedTasks { get; set; }
    }
}
