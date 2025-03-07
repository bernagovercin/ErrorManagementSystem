
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
using Business.Handlers.Invoices.ValidationRules;


namespace Business.Handlers.Invoices.Commands
{


    public class UpdateInvoiceCommand : IRequest<IResult>
    {
        public int CreatedUserId { get; set; }
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

        public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, IResult>
        {
            private readonly IInvoiceRepository _invoiceRepository;
            private readonly IMediator _mediator;

            public UpdateInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IMediator mediator)
            {
                _invoiceRepository = invoiceRepository;
                _mediator = mediator;
            }

            [ValidationAspect(typeof(UpdateInvoiceValidator), Priority = 1)]
            [CacheRemoveAspect("Get")]
            [LogAspect(typeof(PostgreSqlLogger))]
            [SecuredOperation(Priority = 1)]
            public async Task<IResult> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
            {
                var isThereInvoiceRecord = await _invoiceRepository.GetAsync(u => u.Id == request.Id);


                isThereInvoiceRecord.CreatedDate = request.CreatedDate;
                isThereInvoiceRecord.LastUpdatedUserId = request.LastUpdatedUserId;
                isThereInvoiceRecord.LastUpdatedDate = request.LastUpdatedDate;
                isThereInvoiceRecord.Status = request.Status;
                isThereInvoiceRecord.IsDeleted = request.IsDeleted;
                isThereInvoiceRecord.Id = request.Id;
                isThereInvoiceRecord.CustomerName = request.CustomerName;
                isThereInvoiceRecord.Email = request.Email;
                isThereInvoiceRecord.PhoneNumber = request.PhoneNumber;
                isThereInvoiceRecord.Location = request.Location;
                isThereInvoiceRecord.ProductName = request.ProductName;
                isThereInvoiceRecord.Category = request.Category;
                isThereInvoiceRecord.Color = request.Color;
                isThereInvoiceRecord.Size = request.Size;
                isThereInvoiceRecord.Quantity = request.Quantity;
                isThereInvoiceRecord.Price = request.Price;


                _invoiceRepository.Update(isThereInvoiceRecord);
                await _invoiceRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Updated);
            }
        }
    }
}

