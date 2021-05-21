using AutoMapper;
using PaymentExchange.API.ViewModels;
using PaymentExchange.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentExchange.API.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Invoice, InvoiceViewModel>().ReverseMap();

            CreateMap<InvoiceLineViewModel, InvoiceLine>().ReverseMap();

            CreateMap<InvoiceLine, InvoiceLineViewModel>();
        }
    }
}