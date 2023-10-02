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
    public class GetAllContentHandler : IRequestHandler<ContentGetAllDto, IEnumerable<ContentDisplayDto>>
    {
        private readonly IContentReadRepository _readRepo;
        public GetAllContentHandler(IContentReadRepository readRepo)
        {
            _readRepo = readRepo;
        }
        public Task<IEnumerable<ContentDisplayDto>> Handle(ContentGetAllDto request, CancellationToken cancellationToken)
        {
            var data = _readRepo.GetAll(request.Page, request.PageSize, request.User, request.VorGrenze, request.NachGrenze).Select(x => (ContentDisplayDto)x);
            return Task.FromResult(data);
        }
    }
}
