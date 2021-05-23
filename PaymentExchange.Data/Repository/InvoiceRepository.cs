using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

        //public async Task <Invoice> GetByName(string name)
        //{
        //    using (var conn = Db.Database.GetDbConnection())
        //    {
        //        if (conn.State != ConnectionState.Open)
        //        {
        //            await conn.OpenAsync();
        //        }

        //        var sql = @"SELECT i.ClientName, i.TotalMoneyDeduction,i.TotalQuantityDeduction,l.ClientDeduction,l.QuantityDeduction,i.PayDate"+
        //                    "FROM Invoices i "+
        //                    "INNER JOIN InvoiceLines l " +
        //                    "on i.Id = l.InvoiceId" +
        //                    "where i.ClientName = @name" +
        //                    "order by i.PayDate";

        //        var result = await conn.QueryAsync<Invoice, InvoiceLine, Invoice>(sql,
        //           (c, e) =>
        //           {
        //               c.InvoiceLines = new List<InvoiceLine>();
        //               c.InvoiceLines.Add(e);
        //               return c;
        //           },  splitOn: "Id, Id");
        //    //}, new { sid = name }, splitOn: "Id, Id");

        //    return   result.FirstOrDefault();
        //    }
        //}


        public async Task<Invoice> GetByName(string name)
        {
            using (var conn = Db.Database.GetDbConnection())
            {
                if (conn.State != ConnectionState.Open)
                {
                    await conn.OpenAsync();
                }

                var sql = @"SELECT i.ClientName, i.TotalMoneyDeduction,i.TotalQuantityDeduction,l.ClientDeduction,l.QuantityDeduction,i.PayDate" +
                            "FROM Invoices i " +
                            "INNER JOIN InvoiceLines l " +
                            "on i.Id = l.InvoiceId" +
                            "where i.ClientName = @name" +
                            "order by i.PayDate";

                var result = await conn.QueryAsync<Invoice, InvoiceLine, Invoice>(sql,
                   (c, e) =>
                   {
                       c.InvoiceLines = new List<InvoiceLine>();
                       c.InvoiceLines.Add(e);
                       return c;
                   }, splitOn: "Id, Id");
                //}, new { sid = name }, splitOn: "Id, Id");

                return result.FirstOrDefault();
            }
        }

        public async Task<Invoice> CreateEntity(Invoice invoice)
        {
            {
                using (var invoiceRepository = new InvoiceRepository(Db))
                {
                    await invoiceRepository.Create(invoice);

                }
            }

            return invoice;

        }

        //public async Task<Invoice> GetInvoiceId(int id)
        //{
        //    return await Db.Invoices.AsNoTracking()
        //        .Include(c => c.InvoiceLines)
        //        .FirstOrDefaultAsync(c => c.Id == id);
        //}


        public async Task<Invoice> GetInvoiceId(int id)
        {
            using (var conn = Db.Database.GetDbConnection())
            {
                if (conn.State != ConnectionState.Open)
                {
                    await conn.OpenAsync();
                }
                string query = "SELECT * FROM Invoices WHERE Id = @id";
                var result = await conn.QueryAsync<Invoice>(
                query, new { Id = id });
                return result.FirstOrDefault();

            }
        }

    }
}
