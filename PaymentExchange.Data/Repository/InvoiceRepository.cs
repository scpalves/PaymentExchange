using Dapper;
using Microsoft.EntityFrameworkCore;
using PaymentExchange.Business.Interfaces;
using PaymentExchange.Business.Models;
using PaymentExchange.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentExchange.Data.Repository
{
    public class InvoiceRepository : Repository<Invoice>, IinvoiceRepository
    {
        
        public InvoiceRepository(MyDbContext context)
            : base(context)
        {
            
        }

        //public override IEnumerable<Invoice> GetAll()
        //{
        //    const string sql = @"select * from Invoices";

        //    return _dbConnection.Query<Invoice>(sql);
        //}

        public async Task<Invoice> GetInvoiceById(Guid id)
        {
            return await Db.Invoices.AsNoTracking()
                .Include(c => c.InvoiceLines)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        //public async Task<Invoice> GetInvoiceById(Guid id)
        //{

        //    var sql = @"SELECT * FROM Clientes c " +
        //               "LEFT JOIN Enderecos e " +
        //               "ON c.ClienteId = e.ClienteId " +
        //               "WHERE c.ClienteId = @sid";

        //    //throw new Exception("THE BOMB HAS BEEN PLANTED!!!!!");

        //    var cliente = _dbConnection.Query<Invoice, InvoiceLine, Invoice>(sql,
        //        (c, e) =>
        //        {
        //            c.InvoiceLines.Add(e);
        //            return c;
        //        }, new { sid = id }, splitOn: "InvoiceId, InvoiceLineId");

        //    return cliente.FirstOrDefault();
        //}
    }
}
