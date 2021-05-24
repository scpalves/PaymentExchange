using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PaymentExchange.Business.Interfaces;
using PaymentExchange.Business.Notifications;
using PaymentExchange.Business.Services;
using PaymentExchange.Data.Context;
using PaymentExchange.Data.Repository;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentExchange.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MyDbContext>();
            services.AddScoped<IinvoiceRepository, InvoiceRepository>();
            services.AddScoped<IinvoiceService, InvoiceService>();
            services.AddScoped<IinvoiceLineRepository, InvoiceLineRepository>();
            services.AddScoped<IinvoiceLineService, InvoiceLineService>();
            services.AddScoped<INotificator, Notificator>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}