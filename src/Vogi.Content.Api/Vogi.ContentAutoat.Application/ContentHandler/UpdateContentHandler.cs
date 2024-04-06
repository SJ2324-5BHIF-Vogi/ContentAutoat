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
    public class UpdateContentHandler : IRequestHandler<ContentUpdateDto>
    {
        private readonly IContentWriteRepository _writeRepo;
        private readonly IMediator _mediator;

        public UpdateContentHandler(IContentWriteRepository writeRepo, IMediator mediator)
        {
            _mediator = mediator;
            _writeRepo = writeRepo;
        }

        public Task Handle(ContentUpdateDto request, CancellationToken cancellationToken)
        {
            ContentData content = request;
            _writeRepo.Update(request.Guid, content);
            _mediator.Send(new LoggingDto() { data = $"update {content.Guid} at {DateTime.Now}" });
            return Task.FromResult(content.Guid);
        }
    }
}
