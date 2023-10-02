using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vogi.ContentAutoat.Domain.Dtos.Mediator.Base
{
    public abstract class GuidDto 
    {
        public Guid guid { get; set; } = Guid.Empty;
    }
}
