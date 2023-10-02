using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vogi.ContentAutoat.Domain.Dtos;
using Vogi.ContentAutoat.Domain.Dtos.Mediator;
using Vogi.ContentAutoat.Domain.Dtos.Result;
using Vogi.ContentAutoat.Domain.Interfaces.Repository;
using Vogi.ContentAutoat.Domain.Model;

namespace Vogi.ContentAutoat.Application.ContentHandler
{
    public class GetContentHandler : IRequestHandler<ContentGetDto,ContentDisplayDto>
    {
        private readonly IContentReadRepository _readRepo;
        public GetContentHandler(IContentReadRepository readRepo)
        {
            _readRepo = readRepo;
        }

        public Task<ContentDisplayDto> Handle(ContentGetDto request, CancellationToken cancellationToken)
        {
            ContentDisplayDto c = _readRepo.FindByGuid(request.guid);
            return Task.FromResult(c);
        }
    }
}
