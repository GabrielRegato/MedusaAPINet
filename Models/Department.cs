using System.ComponentModel.DataAnnotations;

namespace TestAPI.Models
{
    public class Department
    {
        public int department_id { get; set; }
        public string department_description { get; set; }

        public Department()
        {
            department_description = string.Empty;
        }
    }
}
