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
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public Guid InvoiceLineId { get; set; }

   
        //[Required(ErrorMessage = "The field {0} is required")]
        public decimal ClientDeduction { get; set; }

        public int QuantityDeduction { get; set; }
    }
}
