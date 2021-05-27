using System;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentExchange.Business.Models.Validations
{
    public class InvoiceValidation : AbstractValidator<Invoice>
    {
        public InvoiceValidation()
        {
            RuleFor(f => f.ClientName)
               .NotEmpty().WithMessage("The field {PropertyName} must be provided")
               .Length(3, 100)
               .WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters");

            RuleFor(c => c.ClientPayment)
                .GreaterThan(c => c.InvoiceTotalEarnings).WithMessage("The field  {PropertyName} must be between greater than {ComparisonValue}");

            RuleFor(c => c.InvoiceTotalEarnings)
                .GreaterThan(0).WithMessage("The field {PropertyName} must be between bigger then {ComparisonValue}");

            RuleFor(c => c.ClientPayment)
                .GreaterThan(0).WithMessage("The field {PropertyName} must be between bigger then {ComparisonValue}");

            RuleFor(c => c.TotalQuantityDeduction)
                .Equal(0).WithMessage("The field {PropertyName} must be between equal then {ComparisonValue}");

            RuleFor(c => c.TotalMoneyDeduction)
                .Equal(0).WithMessage("The field {PropertyName} must be between equal then {ComparisonValue}");


        }

    }
}
