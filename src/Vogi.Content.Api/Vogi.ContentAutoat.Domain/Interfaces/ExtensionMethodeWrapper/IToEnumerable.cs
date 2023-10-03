using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vogi.ContentAutoat.Domain.Interfaces.ExtensionMethodeWrapper
{
    public interface IToEnumerable
    {
        IEnumerable<T> ToEnumerable<T>(IAsyncCursorSource<T> List);
    }
}
