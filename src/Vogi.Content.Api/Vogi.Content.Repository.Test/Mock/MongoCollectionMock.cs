using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vogi.ContentAutoat.Domain.Interfaces.Infrastructure;
using Vogi.ContentAutoat.Domain.Model;

namespace Vogi.ContentAutoat.Repository.Test.Mock
{
    internal class MongoCollectionMock
    {
        public FindFluentMock FindFluentMock { get; init; }
        public Mock<IMongoCollection<ContentData>> Mock { get; init; }


        public MongoCollectionMock(FindFluentMock findFluentMock)
        {
            FindFluentMock = findFluentMock;

            Mock = new Mock<IMongoCollection<ContentData>>();
            Mock.Setup(m => m.InsertOne(It.IsAny<ContentData>(), null, default))
                .Verifiable();
            Mock.Setup(m => m.ReplaceOne(It.IsAny<FilterDefinition<ContentData>>(), It.IsAny<ContentData>(), It.IsAny<ReplaceOptions>(), CancellationToken.None));
            Mock.Setup(m => m.DeleteOne(It.IsAny<FilterDefinition<ContentData>>(), CancellationToken.None))
                .Returns(new DeleteResult.Acknowledged(1));
        }

        public MongoCollectionMock() : this(new FindFluentMock()) { }
    }
}
