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
        public int Id { get; set; }
        [Required]
        public string ClientName { get; set; }
        [Required]
        public decimal InvoiceTotalEarnings { get; set; }
        [Required]
        public decimal ClientPayment { get; set; }

        public decimal TotalMoneyDeduction { get; set; }

        public int TotalQuantityDeduction { get; set; }

        public DateTime PayDate { get; set; }

        public IEnumerable<InvoiceLineViewModel> InvoiceLines { get; set; }

    }
}
