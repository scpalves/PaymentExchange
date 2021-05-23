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


    }
}
