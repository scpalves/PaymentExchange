using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentExchange.Business.Models
{
   public class InvoiceLine : Entity
    {

        public Guid InvoiceLineId { get; set; }

        public decimal ClientDeduction { get; set; }
        public int QuantityDeduction { get; set; }
    }
}
