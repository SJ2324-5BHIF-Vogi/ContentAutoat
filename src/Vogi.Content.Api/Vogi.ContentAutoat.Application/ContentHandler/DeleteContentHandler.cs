using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vogi.ContentAutoat.Domain.Dtos;
using Vogi.ContentAutoat.Domain.Dtos.Mediator;
using Vogi.ContentAutoat.Domain.Interfaces.Repository;
using Vogi.ContentAutoat.Domain.Model;

namespace Vogi.ContentAutoat.Application.ContentHandler
{
    public class DeleteContentHandler : IRequestHandler<ContentDeleteDto>
    {
        private readonly IContentWriteRepository _writeRepo;
        private readonly IMediator _mediator;

        public DeleteContentHandler(IContentWriteRepository writeRepo, IMediator mediator)
        {
            _writeRepo = writeRepo;
            _mediator = mediator;

        }
        public Task Handle(ContentDeleteDto request, CancellationToken cancellationToken)
        {
            _writeRepo.Delete(request.guid);
            _mediator.Send(new LoggingDto() { data = $"delteded content {request.guid} at {DateTime.Now}" });
            return Task.CompletedTask;
        }
    }
}
