using PaymentExchange.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Bogus.DataSets;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PaymentExchange.Features.Tests.DataTests
{
   

    public class InvoiceTestsFixture 
    {
      

     
        public Invoice GenerateBusinessInvoice()
        {

            var invoice = new Invoice()
            {
                ClientName = "Teste",
                InvoiceTotalEarnings = 25,
                ClientPayment = 100,
                InvoiceLines = new List<InvoiceLine>()
            };

  
            return invoice;
        }


        public Invoice GenerateDataInvoice()
        {

            var invoice = new Invoice()
            {
                ClientName = "Teste",
                InvoiceTotalEarnings = 25,
                ClientPayment = 100,
                TotalMoneyDeduction = 30,
                TotalQuantityDeduction = 2,
                InvoiceLines = new List<InvoiceLine>()
            };

            var line1 = new InvoiceLine()
            {
                ClientDeduction = 20,
                QuantityDeduction = 1,
            };

            var line2 = new InvoiceLine()
            {
                ClientDeduction = 10,
                QuantityDeduction = 1,
            };

       
            invoice.InvoiceLines.Add(line1);
            invoice.InvoiceLines.Add(line2);

            return invoice;
        }

        public void Dispose()
        {
        }
    }
}
