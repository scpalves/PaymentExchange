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

            RuleFor(c => c.ClientDeduction)
            .Equal(0).WithMessage("The field {PropertyName} must be between equal then {ComparisonValue}");

            RuleFor(c => c.QuantityDeduction)
                .Equal(0).WithMessage("The field {PropertyName} must be between equal then {ComparisonValue}");


        }


    }
}
