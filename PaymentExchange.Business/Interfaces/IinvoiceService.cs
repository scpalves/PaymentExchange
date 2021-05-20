using PaymentExchange.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentExchange.Business.Interfaces
{
    interface IinvoiceService : IDisposable
    {
        Task<bool> Create(Invoice Invoice);



    }
}