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
using PaymentExchange.Business.Models.Enums;

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

            var inputBillValue = invoice.InvoiceTotalEarnings;

            var inputPayment = invoice.ClientPayment;

            var exchange = inputPayment - inputBillValue;


            var bill = new double[] { InvoiceLineType.UmCentimo, InvoiceLineType.CincoCentimos,
                InvoiceLineType.DezCentimos, InvoiceLineType.CiquentaCentimos,
                InvoiceLineType.DezEuros, InvoiceLineType.VinteEuros,
                InvoiceLineType.CiquentaEuros, InvoiceLineType.CemEuros};

            var exchangevalue = (double)exchange;

            invoice.TotalMoneyDeduction = (int) exchangevalue;

            int soma = 0;



            var filledVals =
                bill
                    .OrderByDescending(x => x)
                    .Aggregate(new { exchangevalue, bills = new List<double>() },
                        (a, b) =>
                        {
                            var v = a.exchangevalue;
                            while (v >= b)
                            {
                                a.bills.Add(b);
                                v -= b;
                            }
                            return new { exchangevalue = v, a.bills };
                        })
                    .bills
                    .GroupBy(x => x)
                    .Select(x => new { Value = x.Key, Count = x.Count() });

            foreach (var item in filledVals)
            {
                invoice.InvoiceLines.Add(new InvoiceLine()
                {
                    ClientDeduction = (decimal)item.Value,
                    QuantityDeduction = item.Count,

                });

                var count = item.Count;

                soma += count;
            }
            invoice.TotalQuantityDeduction = soma;

            await _invoiceRepository.Create(invoice);
            return true;
        }



        public void Dispose()
        {
            _invoiceRepository?.Dispose();

        }
    }
}