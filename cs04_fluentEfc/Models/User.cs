using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs04_fluentEfc.Models
{
    internal class User
    {
        public Guid UserId { get; set; }
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public List<Record> CreatedRecords { get; set; } = new List<Record>();
        public List<Record> AssignedRecords { get; set; } = new List<Record>();
    }
}
