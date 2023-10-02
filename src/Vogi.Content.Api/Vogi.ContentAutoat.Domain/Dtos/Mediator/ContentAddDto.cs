﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Vogi.ContentAutoat.Domain.Model;

namespace Vogi.ContentAutoat.Domain.Dtos.Mediator
{
    public class ContentAddDto : IRequest<Guid>
    {
        public string Titel { get; set; } = string.Empty;
        public string Data { get; set; } = string.Empty;

        public static implicit operator Content(ContentAddDto content)
        {
            return new Content()
            {
                Titel = content.Titel,
                Data = content.Data,
                Posted = DateTime.Now,
                Guid = Guid.NewGuid(),
            };
        }
    }
}
