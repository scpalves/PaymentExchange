using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentExchange.Business.Models.Validations
{
    class InvoiceLineValidation : AbstractValidator<InvoiceLine>
    {
        public InvoiceLineValidation()
        {
            //RuleFor(f => f.ClientDeduction)
            //   .NotEmpty().WithMessage("The field {PropertyName} must be provided")
            //   .Length(2, 100)
            //   .WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters");
        }


    }
}
