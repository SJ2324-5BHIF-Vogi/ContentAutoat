using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vogi.ContentAutoat.Domain.Model;

namespace Vogi.ContentAutoat.Domain.Dtos.Mediator.Base
{
    public abstract class ContentDto
    {
        public string Titel { get; set; } = string.Empty;
        public string Data { get; set; } = string.Empty;

      
    }
}
