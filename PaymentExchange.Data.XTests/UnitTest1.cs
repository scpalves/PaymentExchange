using Microsoft.EntityFrameworkCore;
using PaymentExchange.Data.Context;
using PaymentExchange.Data.Repository;
using System;
using Xunit;

namespace PaymentExchange.Data.XTests
{
    public class UnitTest1
    {
     

        [Fact]
        public void GetAllInvoice()
        {
            //var builder = new DbContextOptionsBuilder<MyDbContext>()
            //              .EnableSensitiveDataLogging()
            //              .UseInMemoryDatabase(Guid.NewGuid().ToString());

            //var options = new DbContextOptionsBuilder<MyDbContext>()
            //.UseInMemoryDatabase(databaseName: "BillPayment")
            //.Options;
 
            //var ye  = new InvoiceRepository(MyDbContext)
            //using (var repo = new InvoiceRepository(options))
            //{
            //    var get = repo.GetById(1);
            //}
        }
    }
}
