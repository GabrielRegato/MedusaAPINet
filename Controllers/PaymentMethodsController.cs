using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        private readonly SampleDBContext _context;

        public PaymentMethodController(SampleDBContext context)
        {
            _context = context;
        }

        // GET: api/PaymentMethod (Done)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentMethod>>> GetPaymentMethods()
        {
            return await _context.Payment_Methods.ToListAsync();
        }

        // GET: api/PaymentMethod/1 (Done)
        [HttpGet("{id}")]
        public ActionResult<PaymentMethod> GetPaymentMethod(int id)
        {
            var payment_method = _context.Payment_Methods.Find(id);
            if (payment_method == null)
            {
                return NotFound();
            }
            return payment_method;
        }

        // POST: api/PaymentMethod (Done)
        [HttpPost]
        public ActionResult<PaymentMethod> CreatePaymentMethod(PaymentMethod payment_method)
        {
            if (payment_method == null)
            {
                return BadRequest();
            }
            _context.Payment_Methods.Add(payment_method);
            _context.SaveChanges();
            return CreatedAtAction(
                nameof(GetPaymentMethod),
                new { id = payment_method.payment_method_id },
                payment_method
            );
        }

        // PUT: api/PaymentMethod/1 (Done)
        [HttpPut("{id}")]
        public IActionResult UpdatePaymentMethod(int id, PaymentMethod payment_method)
        {
            if (id <= 0 || payment_method == null)
            {
                return BadRequest();
            }

            var existingPaymentMethod = _context.Payment_Methods.Find(id);
            if (existingPaymentMethod == null)
            {
                return NotFound();
            }

            existingPaymentMethod.payment_method_name = payment_method.payment_method_name;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/PaymentMethod/1 (Done)
        [HttpDelete("{id}")]
        public IActionResult DeletePaymentMethod(int id)
        {
            var payment_method = _context.Payment_Methods.Find(id);
            if (payment_method == null)
            {
                return NotFound();
            }

            _context.Payment_Methods.Remove(payment_method);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
