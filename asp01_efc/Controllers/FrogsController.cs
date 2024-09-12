using asp01_efc.Data;
using asp01_efc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace asp01_efc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrogsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public FrogsController(ApplicationDbContext context) 
        { 
            _context = context;
        }

        [HttpGet]
        public IActionResult GetFrogs(string? firstname)
        {
            IQueryable<Student> query = _context.Students;
            if (!string.IsNullOrWhiteSpace(firstname))
            {
                query = query.Where(x => x.Firstname.Contains(firstname));
            }
            var students = query.ToList();
            /*var students = _context.Students
                .Where(x => x.Firstname == "Tonda")
                .OrderBy(x => x.Lastname)
                .ToList();
            */
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetFrog(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public IActionResult CreateFrog([FromBody] Student student)
        {
            if (student.ShoeSize > 50) return BadRequest("incorrect shoe size");
            _context.Students.Add(student);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetFrog), new { id = student.StudentId }, student);
        }
    }
}
