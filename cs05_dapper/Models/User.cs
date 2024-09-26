using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cs05_dapper.Models
{
    internal class User
    {
        public Guid UserId { get; set; }
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
    }
}
