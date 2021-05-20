using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentExchange.API.ViewModels
{
    public class InvoiceViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(10, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string ClientName { get; set; }
        public decimal InvoiceTotalEarnings { get; set; }
        public decimal ClientPayment { get; set; }

        public decimal TotalMoneyDeduction { get; set; }

        public int TotalQuantityDeduction { get; set; }

        public DateTime PayDate { get; set; }

        public IEnumerable<InvoiceLineViewModel> InvoiceLines { get; set; }

    }
}
