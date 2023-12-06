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
        public AddContentHandler(IContentWriteRepository writeRepo)
        {
            _writeRepo = writeRepo;
        }

        public Task<Guid> Handle(ContentAddDto request, CancellationToken cancellationToken)
        {
            ContentData content = request;
            _writeRepo.Add(content);

            return Task.FromResult(content.Guid);
        }
    }
}
