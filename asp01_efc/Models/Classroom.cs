namespace asp01_efc.Models
{
    public class Classroom
    {
        public int ClassroomId { get; set; }
        //public string Name { get; set; } = string.Empty;
        public required string Name { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
