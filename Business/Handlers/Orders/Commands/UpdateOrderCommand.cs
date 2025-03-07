
using Business.Constants;
using Business.BusinessAspects;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Core.Aspects.Autofac.Validation;
using Business.Handlers.Orders.ValidationRules;


namespace Business.Handlers.Orders.Commands
{


    public class UpdateOrderCommand : IRequest<IResult>
    {
        public int CreatedUserId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int LastUpdatedUserId { get; set; }
        public System.DateTime LastUpdatedDate { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string ProductName { get; set; }
        public string Color { get; set; }
        public Core.Enums.SizeEnum Size { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, IResult>
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IMediator _mediator;

            public UpdateOrderCommandHandler(IOrderRepository orderRepository, IMediator mediator)
            {
                _orderRepository = orderRepository;
                _mediator = mediator;
            }

            [ValidationAspect(typeof(UpdateOrderValidator), Priority = 1)]
            [CacheRemoveAspect("Get")]
            [LogAspect(typeof(PostgreSqlLogger))]
            [SecuredOperation(Priority = 1)]
            public async Task<IResult> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
            {
                var isThereOrderRecord = await _orderRepository.GetAsync(u => u.Id == request.Id);


                isThereOrderRecord.CreatedDate = request.CreatedDate;
                isThereOrderRecord.LastUpdatedUserId = request.LastUpdatedUserId;
                isThereOrderRecord.LastUpdatedDate = request.LastUpdatedDate;
                isThereOrderRecord.Status = request.Status;
                isThereOrderRecord.IsDeleted = request.IsDeleted;
                isThereOrderRecord.Id = request.Id;
                isThereOrderRecord.CustomerName = request.CustomerName;
                isThereOrderRecord.Location = request.Location;
                isThereOrderRecord.Category = request.Category;
                isThereOrderRecord.ProductName = request.ProductName;
                isThereOrderRecord.Color = request.Color;
                isThereOrderRecord.Size = request.Size;
                isThereOrderRecord.Quantity = request.Quantity;
                isThereOrderRecord.Price = request.Price;


                _orderRepository.Update(isThereOrderRecord);
                await _orderRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Updated);
            }
        }
    }
}

