﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using PaymentExchange.Business.Interfaces;
using PaymentExchange.Business.Models;
using PaymentExchange.Business.Notifications;

namespace PaymentExchange.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotificator _notificator;

        protected BaseService(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected void Notificate(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificate(error.ErrorMessage);
            }
        }

        protected void Notificate(string message)
        {
            _notificator.Handle(new Notification(message));
        }

    }
}
