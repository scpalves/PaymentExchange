using PaymentExchange.Business.BusinessRules;
using PaymentExchange.Business.Interfaces;
using PaymentExchange.Business.Models;
using PaymentExchange.Business.Models.Enums;
using PaymentExchange.Business.Models.Validations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task Create(Invoice invoice)
        {
            if (!ExecuteValidation(new InvoiceValidation(), invoice)) return;
            InvoiceBusiness.InvoiceBusinessRule(invoice);

            await _invoiceRepository.CreateEntity(invoice);

        }



        public void Dispose()
        {
            _invoiceRepository?.Dispose();

        }
    }
}