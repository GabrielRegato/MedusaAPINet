using TestAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly SampleDBContext _context;
        public EmployeeController(SampleDBContext context)
        {
            _context = context;
        }

        // GET: api/Employee (Done)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        // GET: api/Employee/1 (Done)
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }

        // POST: api/Employee (Done)
        [HttpPost]
        public ActionResult<Employee> CreateEmployee(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.employee_id }, employee);
        }

        // PUT: api/Employee/1 (Done)
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee employee)
        {

            if (id <= 0 || employee == null)
            {
                return BadRequest();
            }

            var existingEmployee = _context.Employees.Find(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }

            existingEmployee.first_Name = employee.first_Name;
            existingEmployee.last_Name = employee.last_Name;
            existingEmployee.start_Date = employee.start_Date;
            existingEmployee.birthday = employee.birthday;
            existingEmployee.department_id = employee.department_id;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Employee/1 (Done)
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return NoContent();
        }
    }
}