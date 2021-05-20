using PaymentExchange.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentExchange.Business.Interfaces
{
   public interface IinvoiceLineService : IDisposable
    {

        Task Create(InvoiceLine invoiceLine);

    }
}
