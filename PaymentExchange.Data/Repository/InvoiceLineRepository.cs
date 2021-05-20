using Microsoft.EntityFrameworkCore;
using PaymentExchange.Business.Interfaces;
using PaymentExchange.Business.Models;
using PaymentExchange.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentExchange.Data.Repository
{
   public class InvoiceLineRepository : Repository <InvoiceLine>, IinvoiceLineRepository
    {
        public InvoiceLineRepository(MyDbContext context) : base(context)
        {
        }

        public async Task<InvoiceLine> GetInvoiceLineById(Guid id)
        {
            return await Db.InvoiceLines.AsNoTracking().Include(f => f.Invoice)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<InvoiceLine>> GetInvoiceLines()
        {
            return await Db.InvoiceLines.AsNoTracking().Include(f => f.Invoice)
                .OrderBy(p => p.Id).ToListAsync();
        }

        public async Task<IEnumerable<InvoiceLine>> GetInvoiceLineByInvoiceId(Guid invoiceId)
        {
            return await Get(p => p.InvoiceLineId == invoiceId);
        }
    }
}
