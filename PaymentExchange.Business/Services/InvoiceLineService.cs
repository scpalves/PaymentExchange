using PaymentExchange.Business.Interfaces;
using PaymentExchange.Business.Models;
using PaymentExchange.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentExchange.Business.Services
{

    public class InvoiceLineService : BaseService, IinvoiceLineService
    {
        private readonly IinvoiceLineRepository _invoiceLineRepository;

        public InvoiceLineService(IinvoiceLineRepository invoiceLineRepository,
                              INotificator notificator) : base(notificator)
        {
            _invoiceLineRepository = invoiceLineRepository;
        }

        public async Task Create(InvoiceLine invoiceLine)
        {
            if (!ExecuteValidation(new InvoiceLineValidation(), invoiceLine)) return;

            await _invoiceLineRepository.Create(invoiceLine);
        }

        public void Dispose()
        {
            _invoiceLineRepository?.Dispose();

        }
    }
}