using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly SampleDBContext _context;

        public SalaryController(SampleDBContext context)
        {
            _context = context;
        }

        // GET: api/Salary (Done)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salary>>> GetSalaries()
        {
            return await _context.Salaries.ToListAsync();
        }

        // GET: api/Salary/1 (Done)
        [HttpGet("{id}")]
        public ActionResult<Salary> GetSalary(int id)
        {
            var salary = _context.Salaries.Find(id);
            if (salary == null)
            {
                return NotFound();
            }
            return salary;
        }

        // POST: api/Salary (Done)
        [HttpPost]
        public ActionResult<Salary> CreateSalary(Salary salary)
        {
            if (salary == null)
            {
                return BadRequest();
            }
            _context.Salaries.Add(salary);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSalary), new { id = salary.salary_id }, salary);
        }

        // PUT: api/Salary/1 (Done)
        [HttpPut("{id}")]
        public IActionResult UpdateSalary(int id, Salary salary)
        {
            if (id <= 0 || salary == null)
            {
                return BadRequest();
            }

            var existingSalary = _context.Salaries.Find(id);
            if (existingSalary == null)
            {
                return NotFound();
            }

            existingSalary.monthly_salary = salary.monthly_salary;
            existingSalary.payment_method_id = salary.payment_method_id;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Salary/1 (Done)
        [HttpDelete("{id}")]
        public IActionResult DeleteSalary(int id)
        {
            var salary = _context.Salaries.Find(id);
            if (salary == null)
            {
                return NotFound();
            }

            _context.Salaries.Remove(salary);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
