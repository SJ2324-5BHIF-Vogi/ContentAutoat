using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vogi.ContentAutoat.Domain.Interfaces.ExtensionMethodeWrapper
{
    public interface IFindFluentFind
    {
        IFindFluent<T, T> Find<T>(IMongoCollection<T> collection, FilterDefinition<T> filter, FindOptions options = null!);
    }
}


// public static IFindFluent<TDocument, TDocument> Find<TDocument>(this IMongoCollection<TDocument> collection, FilterDefinition<TDocument> filter, FindOptions options = null)
       