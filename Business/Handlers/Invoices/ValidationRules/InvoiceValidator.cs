
using Business.Handlers.Invoices.Commands;
using FluentValidation;

namespace Business.Handlers.Invoices.ValidationRules
{

    public class CreateInvoiceValidator : AbstractValidator<CreateInvoiceCommand>
    {
        public CreateInvoiceValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.Location).NotEmpty();
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.Category).NotEmpty();
            RuleFor(x => x.Color).NotEmpty();
            RuleFor(x => x.Size).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty();
            RuleFor(x => x.Price).NotEmpty();

        }
    }
    public class UpdateInvoiceValidator : AbstractValidator<UpdateInvoiceCommand>
    {
        public UpdateInvoiceValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.Location).NotEmpty();
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.Category).NotEmpty();
            RuleFor(x => x.Color).NotEmpty();
            RuleFor(x => x.Size).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty();
            RuleFor(x => x.Price).NotEmpty();

        }
    }
}