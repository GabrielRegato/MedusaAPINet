using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly SampleDBContext _context;

        public DepartmentController(SampleDBContext context)
        {
            _context = context;
        }

        // GET: api/Department (Done)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        // GET: api/Department/1 (Done)
        [HttpGet("{id}")]
        public ActionResult<Department> GetDepartment(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            return department;
        }

        // POST: api/Department (Done)
        [HttpPost]
        public ActionResult<Department> CreateDepartment(Department department)
        {
            if (department == null)
            {
                return BadRequest();
            }
            _context.Departments.Add(department);
            _context.SaveChanges();
            return CreatedAtAction(
                nameof(GetDepartment),
                new { id = department.department_id },
                department
            );
        }

        // PUT: api/Department/1 (Done)
        [HttpPut("{id}")]
        public IActionResult UpdateDepartment(int id, Department department)
        {
            if (id <= 0 || department == null)
            {
                return BadRequest();
            }

            var existingDepartment = _context.Departments.Find(id);
            if (existingDepartment == null)
            {
                return NotFound();
            }

            existingDepartment.department_description = department.department_description;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Department/1 (Done)
        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
