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
    public class ContentAddDto : ContentDto, IRequest<Guid>{ 
    
        public Guid User { get; set; }

        public static implicit operator ContentData(ContentAddDto content)
        {
            return new ContentData()
            {
                Titel = content.Titel,
                Data = content.Data,
                Posted = DateTime.Now,
                Guid = Guid.NewGuid(),
                User = content.User,
            };
        }
    }
}
