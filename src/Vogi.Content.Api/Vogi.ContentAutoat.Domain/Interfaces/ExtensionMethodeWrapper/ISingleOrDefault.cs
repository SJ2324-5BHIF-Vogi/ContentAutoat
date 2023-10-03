using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vogi.ContentAutoat.Domain.Interfaces.ExtensionMethodeWrapper
{
    public interface ISingleOrDefault
    {
        public TProjection SingleOrDefault<TDocument, TProjection>(IFindFluent<TDocument, TProjection> find, CancellationToken cancellationToken = default(CancellationToken));
    }
}
