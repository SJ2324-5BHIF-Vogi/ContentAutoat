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
    public class AddContentHandler : IRequestHandler<ContentAddDto, Guid>
    {
        private readonly IContentWriteRepository _writeRepo;
        private readonly IMediator _mediator;
        public AddContentHandler(IContentWriteRepository writeRepo, IMediator mediator)
        {
            _writeRepo = writeRepo;
            _mediator = mediator;
        }

        public Task<Guid> Handle(ContentAddDto request, CancellationToken cancellationToken)
        {
            var guid = _writeRepo.Add(request);
            _mediator.Send(new LoggingDto() { data = $"created content {guid} at {DateTime.Now}" });
            return Task.FromResult(guid);
        }
    }
}
