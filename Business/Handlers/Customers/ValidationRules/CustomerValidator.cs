
using Business.Handlers.Customers.Commands;
using FluentValidation;

namespace Business.Handlers.Customers.ValidationRules
{

    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.ImagePath).NotEmpty();
            RuleFor(x => x.CustomerName).NotEmpty();
            RuleFor(x => x.Location).NotEmpty();
            RuleFor(x => x.Gender).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();

        }
    }
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(x => x.ImagePath).NotEmpty();
            RuleFor(x => x.CustomerName).NotEmpty();
            RuleFor(x => x.Location).NotEmpty();
            RuleFor(x => x.Gender).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();

        }
    }
}