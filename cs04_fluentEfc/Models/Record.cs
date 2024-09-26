using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs04_fluentEfc.Models
{
    internal class Record
    {

        public int RecordId { get; set; }
        public required string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public required Guid CreatorId { get; set; }
        public User? Creator { get; set; }
        public required Guid UserId { get; set; }
        public User? User { get; set; }
    }
}
