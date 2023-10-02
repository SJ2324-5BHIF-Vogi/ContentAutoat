using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Vogi.ContentAutoat.Domain.Dtos.Result;
using Vogi.ContentAutoat.Domain.Model;

namespace Vogi.ContentAutoat.Domain.Dtos.Mediator
{
    public class ContentGetAllDto : IRequest<IEnumerable<ContentDisplayDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public Guid? User { get; set; }
        public DateTime? VorGrenze { get; set; }
        public DateTime? NachGrenze { get; set; }
    }
}
