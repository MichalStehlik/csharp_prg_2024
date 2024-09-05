using System.ComponentModel.DataAnnotations;

namespace asp01_efc.Models
{
    public class Student
    {
        public int StudentId { get; set; } // primární klíč
        // public int Id { get; set; }
        /*
        [Key]
        public int Klic { get; set; }
        */
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string? Middlename { get; set; }
        public int? ShoeSize { get; set; }
    }
}
