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
    public class FindFluentExtensionWrapper : IFindFluentFind
    {
        public IFindFluent<T, T> Find<T>(IMongoCollection<T> collection, FilterDefinition<T> filter, FindOptions options = null)
        {
            return collection.Find(filter, options);
        }
    }
}
