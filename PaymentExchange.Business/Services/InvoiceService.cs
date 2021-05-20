using PaymentExchange.Business.Interfaces;
using PaymentExchange.Business.Notifications;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentExchange.Business.Models;
using PaymentExchange.Business.Models.Validations;

namespace PaymentExchange.Business.Services
{
    public class InvoiceService : BaseService, IinvoiceService
    {
        private readonly IinvoiceRepository _invoiceRepository;

        public InvoiceService(IinvoiceRepository invoiceRepository,
                                 INotificator notificator) : base(notificator)
        {
            _invoiceRepository = invoiceRepository;

        }

        public async Task<bool> Create(Invoice invoice)
        {
            if (!ExecuteValidation(new InvoiceValidation(), invoice)
               ) return false;

            if (_invoiceRepository.Get(f => f.Id == invoice.Id).Result.Any())
            {
                Notificate("There is already a invoice in our database.");
                return false;
            }

            var inputBillValue = invoice.InvoiceTotalEarnings;

            var inputPayment = invoice.ClientPayment;

            var exchange = inputBillValue - inputPayment;


            var bills = new double[] { 0.01, 0.02, 0.05, 0.1, 0.2, 0.5, 1, 5, 10, 20, 50, 100, };
            var value = (double)exchange;
            var breakdown =
                bills
                    .OrderByDescending(x => x)
                    .Aggregate(new { value, bills = new List<double>() },
                        (a, b) =>
                        {
                            var v = a.value;
                            while (v >= b)
                            {
                                a.bills.Add(b);
                                v -= b;
                            }
                            return new { value = v, a.bills };
                        })
                    .bills
                    .GroupBy(x => x)
                    .Select(x => new { Bill = x.Key, Count = x.Count() });


            foreach (var item in breakdown)
            {
                foreach (var invoiceLines in invoice.InvoiceLines)
                {
                     invoiceLines.ClientDeduction = (decimal)item.Bill;
                    invoiceLines.QuantityDeduction = item.Count;

                }
                
            }

            await _invoiceRepository.Create(invoice);
            return true;
        }

 

        public void Dispose()
        {
        _invoiceRepository?.Dispose();

        }
    }
}