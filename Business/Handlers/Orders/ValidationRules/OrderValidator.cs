
using Business.Handlers.Orders.Commands;
using FluentValidation;

namespace Business.Handlers.Orders.ValidationRules
{

    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty();
            RuleFor(x => x.Location).NotEmpty();
            RuleFor(x => x.Category).NotEmpty();
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.Color).NotEmpty();
            RuleFor(x => x.Size).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty();
            RuleFor(x => x.Price).NotEmpty();

        }
    }
    public class UpdateOrderValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty();
            RuleFor(x => x.Location).NotEmpty();
            RuleFor(x => x.Category).NotEmpty();
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.Color).NotEmpty();
            RuleFor(x => x.Size).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty();
            RuleFor(x => x.Price).NotEmpty();

        }
    }
}