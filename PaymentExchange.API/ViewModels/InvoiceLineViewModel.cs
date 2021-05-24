using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentExchange.API.ViewModels
{
    public class InvoiceLineViewModel
    {
        [Key]
  
        public int Id { get; set; }

        public decimal ClientDeduction { get; set; }

        public int QuantityDeduction { get; set; }

        public int InvoiceId { get; set; }
    }
}
