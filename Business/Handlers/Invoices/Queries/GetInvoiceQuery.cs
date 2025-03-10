﻿
using Business.BusinessAspects;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;


namespace Business.Handlers.Invoices.Queries
{
    public class GetInvoiceQuery : IRequest<IDataResult<Invoice>>
    {
        public int Id { get; set; }

        public class GetInvoiceQueryHandler : IRequestHandler<GetInvoiceQuery, IDataResult<Invoice>>
        {
            private readonly IInvoiceRepository _invoiceRepository;
            private readonly IMediator _mediator;

            public GetInvoiceQueryHandler(IInvoiceRepository invoiceRepository, IMediator mediator)
            {
                _invoiceRepository = invoiceRepository;
                _mediator = mediator;
            }
            [LogAspect(typeof(PostgreSqlLogger))]
            [SecuredOperation(Priority = 1)]
            public async Task<IDataResult<Invoice>> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
            {
                var invoice = await _invoiceRepository.GetAsync(p => p.Id == request.Id);
                return new SuccessDataResult<Invoice>(invoice);
            }
        }
    }
}
