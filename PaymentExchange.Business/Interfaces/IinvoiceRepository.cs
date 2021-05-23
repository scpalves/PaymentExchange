﻿using PaymentExchange.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentExchange.Business.Interfaces
{
   public interface IinvoiceRepository : IRepository<Invoice>
    {
        Task<Invoice> GetByName(string name);
        Task<Invoice> CreateEntity(Invoice Invoice);
        Task<Invoice> GetInvoiceId(int id);


    }
}
