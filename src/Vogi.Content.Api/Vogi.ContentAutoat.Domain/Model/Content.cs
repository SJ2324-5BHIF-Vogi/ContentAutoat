using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vogi.ContentAutoat.Domain.Model
{
    public class Content
    {
        public string Titel { get; set; } = string.Empty;
        public string Data { get; set; } = string.Empty;
        public DateTime Posted { get; set; }
        public Guid Guid { get; set; } = Guid.Empty;
        public Guid User { get; set; } = Guid.Empty;
    }
}
