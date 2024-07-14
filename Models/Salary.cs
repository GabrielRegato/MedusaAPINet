using System.ComponentModel.DataAnnotations;

namespace TestAPI.Models
{
    public class Salary
    {
        public int salary_id { get; set; }
        public int employee_id { get; set; }
        public decimal monthly_salary { get; set; }
        public int payment_method_id { get; set; }
    }
}
