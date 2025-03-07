
using Business.BusinessAspects;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Business.Handlers.Invoices.ValidationRules;

namespace Business.Handlers.Invoices.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateInvoiceCommand : IRequest<IResult>
    {

        public System.DateTime CreatedDate { get; set; }
        public int LastUpdatedUserId { get; set; }
        public System.DateTime LastUpdatedDate { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
        public Core.Enums.SizeEnum Size { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }


        public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, IResult>
        {
            private readonly IInvoiceRepository _invoiceRepository;
            private readonly IMediator _mediator;
            public CreateInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IMediator mediator)
            {
                _invoiceRepository = invoiceRepository;
                _mediator = mediator;
            }

            [ValidationAspect(typeof(CreateInvoiceValidator), Priority = 1)]
            [CacheRemoveAspect("Get")]
            [LogAspect(typeof(PostgreSqlLogger))]
            [SecuredOperation(Priority = 1)]
            public async Task<IResult> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
            {
                var isThereInvoiceRecord = _invoiceRepository.Query().Any(u => u.Id == request.Id);

                if (isThereInvoiceRecord == true)
                    return new ErrorResult(Messages.NameAlreadyExist);

                var addedInvoice = new Invoice
                {
                    CreatedDate = request.CreatedDate,
                    LastUpdatedUserId = request.LastUpdatedUserId,
                    LastUpdatedDate = request.LastUpdatedDate,
                    Status = request.Status,
                    IsDeleted = request.IsDeleted,
                    Id = request.Id,
                    CustomerName = request.CustomerName,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    Location = request.Location,
                    ProductName = request.ProductName,
                    Category = request.Category,
                    Color = request.Color,
                    Size = request.Size,
                    Quantity = request.Quantity,
                    Price = request.Price,

                };

                _invoiceRepository.Add(addedInvoice);
                await _invoiceRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Added);
            }
        }
    }
}