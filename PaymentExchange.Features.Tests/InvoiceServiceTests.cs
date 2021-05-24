using Moq;
using PaymentExchange.Business.Interfaces;
using PaymentExchange.Features.Tests.DataTests;
using System;
using MediatR;
using Xunit;
using PaymentExchange.Business.Services;
using System.Threading;
using PaymentExchange.Data.Repository;
using PaymentExchange.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace PaymentExchange.Features.Tests
{

    public class InvoiceServiceTests
    {
      

        InvoiceTestsFixture invoiceTestsFixture = new InvoiceTestsFixture();

        [Fact(DisplayName = "InvoiceService_Add_ExecuteWithSucess")]
        [Trait("Category", "Invoice Service Tests")]
        public async void InvoiceService_Add_ExecuteWithSucess()
        {
 
            var invoice = invoiceTestsFixture.GenerateBusinessInvoice();
            var invoiceRepo = new Mock<IinvoiceRepository>();
            var notificator = new Mock<INotificator>();


            var invoiceService = new InvoiceService(invoiceRepo.Object, notificator.Object);

            await invoiceService.Create(invoice);

            invoiceRepo.Verify(r => r.Create(invoice), Times.Once);
        }

        [Fact(DisplayName = "Get All Invoices")]
        [Trait("Category", "Invoice Service Tests")]
        public void InvoicesService_GetAllInvoices()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<MyDbContext>()
           .UseInMemoryDatabase(databaseName: "Bill")
            .Options;

            using (var context = new MyDbContext(options))
            {
                var invoiceRepository = new InvoiceRepository(context);


                var invoice = invoiceRepository.GetAllInvoice();

            }

            // Assert 
            // Assert.True(invoice);
            //Assert.False(invoice.Count(c => !c.Ativo) > 0);
        }

        [Fact(DisplayName = "Get Invoices By Id")]
        [Trait("Category", "Invoice Service Tests")]
        public void InvoicesService_GetInvoicesById()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<MyDbContext>()
           .UseInMemoryDatabase(databaseName: "Bill")
            .Options;

            using (var context = new MyDbContext(options))
            {
                var invoiceRepository = new InvoiceRepository(context);


                var invoice = invoiceRepository.GetInvoiceById(23);

            }

            // Assert 
            // Assert.True(invoice);
            //Assert.False(invoice.Count(c => !c.Ativo) > 0);
        }
    }

}




