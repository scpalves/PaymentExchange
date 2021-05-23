using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentExchange.Business.Models
{
   public class InvoiceLine : Entity
    {

        public decimal ClientDeduction { get; set; }
        public int QuantityDeduction { get; set; }

        [ForeignKey("InvoiceId")]
        public int InvoiceId { get; set; }

        public virtual Invoice Invoice { get; set; }


    }
}
