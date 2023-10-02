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
    public class GetAllContentHandler : IRequestHandler<ContentGetAllDto, IEnumerable<ContentDto>>
    {
        private readonly IContentWriteRepository _writeRepo;
        public GetAllContentHandler(IContentWriteRepository writeRepo)
        {
            _writeRepo = writeRepo;
        }
        public Task<IEnumerable<ContentDto>> Handle(ContentGetAllDto request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
