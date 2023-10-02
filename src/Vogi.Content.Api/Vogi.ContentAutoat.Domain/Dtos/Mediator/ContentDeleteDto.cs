using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Vogi.ContentAutoat.Domain.Dtos.Mediator.Base;
using Vogi.ContentAutoat.Domain.Model;

namespace Vogi.ContentAutoat.Domain.Dtos.Mediator
{
    public class ContentDeleteDto : GuidDto, IRequest {  }
}
