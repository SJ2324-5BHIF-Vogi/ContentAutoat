using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vogi.ContentAutoat.Domain.Dtos
{
    public class ContentDto : IReq
    {
        public string Titel { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;




    }
}
