using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentExchange.Business.Models
{
    public class Invoice : Entity
    {

        public string ClientName { get; set; }
        public decimal InvoiceTotalEarnings { get; set; }
        public decimal ClientPayment { get; set; }
        public decimal TotalMoneyDeduction { get; set; }

        public int TotalQuantityDeduction { get; set; }
        public DateTime PayDate { get; set; }

        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }

    }


}
