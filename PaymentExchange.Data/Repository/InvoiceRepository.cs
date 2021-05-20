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
   public class InvoiceRepository :  Repository<Invoice>, IinvoiceRepository
    {
        public InvoiceRepository(MyDbContext context) : base(context)
        {
        }
        public async Task<Invoice> GetInvoiceById(Guid id)
        {
            return await Db.Invoices.AsNoTracking()
                .Include(c => c.InvoiceLines)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
