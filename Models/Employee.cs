using System.ComponentModel.DataAnnotations;

namespace TestAPI.Models
{
    public class Employee
    {
        public int employee_id { get; set; }
        public string first_Name { get; set; }
        public string last_Name { get; set; }
        public DateTime start_Date { get; set; }
        public DateTime birthday { get; set; }
        public int department_id { get; set; }

        public Employee()
        {
            first_Name = string.Empty;
            last_Name = string.Empty;
        }
    }
}
