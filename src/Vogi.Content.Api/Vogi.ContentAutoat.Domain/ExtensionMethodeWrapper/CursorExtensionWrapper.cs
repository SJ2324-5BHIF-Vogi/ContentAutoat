using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vogi.ContentAutoat.Domain.Interfaces.ExtensionMethodeWrapper;

namespace Vogi.ContentAutoat.Domain.ExtensionMethodeWrapper
{
    public class CursorExtensionWrapper : IToEnumerable, ISingleOrDefault
    {
        public TProjection SingleOrDefault<TDocument, TProjection>(IFindFluent<TDocument, TProjection> find, CancellationToken cancellationToken = default)
        {
            return find.SingleOrDefault(cancellationToken);
        }

        IEnumerable<T> IToEnumerable.ToEnumerable<T>(IAsyncCursorSource<T> List)
        {
            return List.ToEnumerable();
        }
    }
}
