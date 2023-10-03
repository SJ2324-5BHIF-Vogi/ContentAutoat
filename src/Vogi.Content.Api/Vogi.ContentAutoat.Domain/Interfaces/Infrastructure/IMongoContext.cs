using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vogi.ContentAutoat.Domain.Interfaces.Infrastructure
{
    public interface IMongoContext
    {
        public IMongoCollection<T> GetCollection<T>();
    }
}
