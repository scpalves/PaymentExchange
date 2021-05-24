using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentExchange.API.ViewModels;
using PaymentExchange.Business.Interfaces;
using PaymentExchange.Business.Models;
using PaymentExchange.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentExchange.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class InvoiceController : MainController
    {
        private readonly IinvoiceRepository _invoiceRepository;
        private readonly IinvoiceService _invoiceService;
        private readonly IMapper _mapper;

        public InvoiceController(IinvoiceRepository invoiceRepository, IinvoiceService invoiceService,
                                   IMapper mapper,
                                   INotificator notificator
                                   ) : base(notificator)
        {
            _invoiceRepository = invoiceRepository;
            _invoiceService = invoiceService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceViewModel>>> GetAll()
        {
            IEnumerable<InvoiceViewModel> invoice = _mapper.Map<IEnumerable<InvoiceViewModel>>(await _invoiceRepository.GetAllInvoice());
            return Ok(invoice);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceViewModel>> GetById(int id)
        {
            InvoiceViewModel invoiceViewModel = _mapper.Map<InvoiceViewModel>(await _invoiceRepository.GetInvoiceById(id));

            if (invoiceViewModel == null) return NotFound();

            return Ok(invoiceViewModel);
        }



        /// <summary> 
        /// Post Operation Step- Information for the tests
        /// </summary> 
        /// <remarks> 
        /// The tests should be made with example Schema as you can see in below:  
        /// Only three fields have to be insert manually with information
        /// "clientName": "string",     -Insert the name of the client
        /// "invoiceTotalEarnings": 0,  -Insert the Bill value
        /// "clientPayment": 0,         -Insert the cliente Bill value payment (This value have to be bigger than previous Bill value field
        /// To get the exchange value, calculated by application. All other fields are calculated fields by program
        /// 
        /// POST / Todo  - Example Schema for the tests
        ///       {
        ///        "clientName": "Rui",
        ///        "invoiceTotalEarnings": 10,
        ///         "clientPayment": 70,
        ///         "invoiceLines": []
        ///        }
        ///  
        ///      
        /// </remarks>
        [HttpPost]
        [Route("/post")]
        public async Task<ActionResult<InvoiceViewModel>> Add(InvoiceViewModel invoiceViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _invoiceService.Create(_mapper.Map<Invoice>(invoiceViewModel));

            return CustomResponse(invoiceViewModel);
        }



    }
}
