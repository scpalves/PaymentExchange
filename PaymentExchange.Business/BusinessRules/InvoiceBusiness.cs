using PaymentExchange.Business.Models;
using PaymentExchange.Business.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentExchange.Business.BusinessRules
{
     public static class InvoiceBusiness
    {
        public static void InvoiceBusinessRule(Invoice invoice)
        {
            int total = 0;

            var inputBillValue = invoice.InvoiceTotalEarnings;

            var inputPayment = invoice.ClientPayment;

            var exchange = inputPayment - inputBillValue;

            var exchangevalue = (double)exchange;

            invoice.TotalMoneyDeduction = (decimal)exchangevalue;

            var bill = new double[] {InvoiceLineType.UmCentimo,InvoiceLineType.DezEuros,
                                     InvoiceLineType.CincoCentimos,InvoiceLineType.VinteEuros,
                                     InvoiceLineType.DezCentimos,InvoiceLineType.CiquentaEuros,
                                     InvoiceLineType.CiquentaCentimos,InvoiceLineType.CemEuros};

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

                total += count;
            }

            invoice.TotalQuantityDeduction = total;
        }
            
        
        

    }
}
