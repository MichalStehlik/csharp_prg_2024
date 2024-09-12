using asp01_efc.Data;
using asp01_efc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp01_efc.Controllers
{
    [Route("api/[controller]")] // RouteProperty
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
            IQueryable<Student> query = _context.Students
                .Include(x => x.Classroom);
            if (!string.IsNullOrWhiteSpace(firstname))
            {
                query = query.Where(x => x.Firstname.Contains(firstname));
            }
            query = query.OrderBy(x => x.Lastname);
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
            //var student = _context.Students.Find(id);
            var student = _context.Students
                .Where(x => x.StudentId == id)
                .SingleOrDefault();
            if (student == null)
            {
                return NotFound();
            }
            _context.Entry(student).Reference(x => x.Classroom).Load();
            return Ok(student);
            //Single() - přesně jeden záznam, pokud není, tak výjimka
            //SingleOrDefault() - přesně jeden záznam, pokud není, tak null
            //First() - první záznam, pokud není, tak výjimka
            //FirstOrDefault() - první záznam, pokud není, tak null
            //Last() - poslední záznam, pokud není, tak výjimka
            //LastOrDefault() - poslední záznam, pokud není, tak null
            //ToList() - všechny záznamy
            //ToArray() - všechny záznamy
            //Query() - IQueryable
        }

        [HttpPost]
        public IActionResult CreateFrog([FromBody] Student student)
        {
            if (student.ShoeSize > 50) return BadRequest("incorrect shoe size");
            _context.Students.Add(student);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetFrog), new { id = student.StudentId }, student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFrog(int id, [FromBody] Student student)
        {
            if (id != student.StudentId) return BadRequest();
            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFrog(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null) return NotFound();
            _context.Students.Remove(student);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
