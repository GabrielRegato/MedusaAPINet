using System.ComponentModel.DataAnnotations;

namespace TestAPI.Models
{
    public class PaymentMethod
    {
        public int payment_method_id { get; set; }
        public string payment_method_name { get; set; }

        public PaymentMethod()
        {
            payment_method_name = string.Empty;
        }
    }
}
