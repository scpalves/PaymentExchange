using PaymentExchange.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentExchange.Business.Interfaces
{
   public interface IinvoiceLineRepository : IRepository<InvoiceLine>
    {
        Task<IEnumerable<InvoiceLine>> GetInvoiceLineByInvoiceId(Guid invoiceLine);

        Task<IEnumerable<InvoiceLine>> GetInvoiceLines();

        Task<InvoiceLine> GetInvoiceLineById(Guid id);
  
    }
}
