
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
using Business.Handlers.Addresses.ValidationRules;


namespace Business.Handlers.Addresses.Commands
{


    public class UpdateAddressCommand : IRequest<IResult>
    {
        public int CreatedUserId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int LastUpdatedUserId { get; set; }
        public System.DateTime LastUpdatedDate { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public int CustomerId { get; set; }

        public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, IResult>
        {
            private readonly IAddressRepository _addressRepository;
            private readonly IMediator _mediator;

            public UpdateAddressCommandHandler(IAddressRepository addressRepository, IMediator mediator)
            {
                _addressRepository = addressRepository;
                _mediator = mediator;
            }

            [ValidationAspect(typeof(UpdateAddressValidator), Priority = 1)]
            [CacheRemoveAspect("Get")]
            [LogAspect(typeof(PostgreSqlLogger))]
            [SecuredOperation(Priority = 1)]
            public async Task<IResult> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
            {
                var isThereAddressRecord = await _addressRepository.GetAsync(u => u.Id == request.Id);


                isThereAddressRecord.CreatedDate = request.CreatedDate;
                isThereAddressRecord.LastUpdatedUserId = request.LastUpdatedUserId;
                isThereAddressRecord.LastUpdatedDate = request.LastUpdatedDate;
                isThereAddressRecord.Status = request.Status;
                isThereAddressRecord.IsDeleted = request.IsDeleted;
                isThereAddressRecord.Id = request.Id;
                isThereAddressRecord.Type = request.Type;
                isThereAddressRecord.Location = request.Location;
                isThereAddressRecord.CustomerId = request.CustomerId;


                _addressRepository.Update(isThereAddressRecord);
                await _addressRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Updated);
            }
        }
    }
}

