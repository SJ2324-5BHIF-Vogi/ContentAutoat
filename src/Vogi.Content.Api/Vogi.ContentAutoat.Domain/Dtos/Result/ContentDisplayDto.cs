using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vogi.ContentAutoat.Domain.Model;

namespace Vogi.ContentAutoat.Domain.Dtos.Result
{
    public class ContentDisplayDto
    {
        public string Titel { get; set; } = string.Empty;
        public string Data { get; set; } = string.Empty;
        public DateTime Posted { get; set; }
        public Guid Guid { get; set; } = Guid.Empty;
        public Guid User { get; set; } = Guid.Empty;

        public static implicit operator ContentDisplayDto(Content content)
        {
            return new ContentDisplayDto() { Titel = content.Titel, Data = content.Data, Posted = content.Posted, Guid = content.Guid };
        }
    }
}
