
using Business.Handlers.Addresses.Commands;
using FluentValidation;

namespace Business.Handlers.Addresses.ValidationRules
{

    public class CreateAddressValidator : AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressValidator()
        {
            RuleFor(x => x.Type).NotEmpty();
            RuleFor(x => x.Location).NotEmpty();
            RuleFor(x => x.CustomerId).NotEmpty();

        }
    }
    public class UpdateAddressValidator : AbstractValidator<UpdateAddressCommand>
    {
        public UpdateAddressValidator()
        {
            RuleFor(x => x.Type).NotEmpty();
            RuleFor(x => x.Location).NotEmpty();
            RuleFor(x => x.CustomerId).NotEmpty();

        }
    }
}