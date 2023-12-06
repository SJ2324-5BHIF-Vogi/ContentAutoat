using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vogi.ContentAutoat.Domain.Interfaces.Infrastructure;
using Vogi.ContentAutoat.Domain.Model;

namespace Vogi.ContentAutoat.Repository.Test.Mock
{
    internal class MongoContextMock
    {
        public Mock<IMongoContext> Mock { get; init; }


        public MongoCollectionMock MongoCollectionMock { get; init; }
        public MongoContextMock(MongoCollectionMock mongoCollectionMock)
        {
            MongoCollectionMock = mongoCollectionMock;

            Mock = new Mock<IMongoContext>();
            Mock.Setup(m => m.GetCollection<ContentData>())
                .Returns(() => MongoCollectionMock.Mock.Object);
        }
        public MongoContextMock():this(new MongoCollectionMock()) { }

    }
}
