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
        public Mock<IMongoCollection<Content>> Mock { get; init; }


        public MongoCollectionMock(FindFluentMock findFluentMock)
        {
            FindFluentMock = findFluentMock;

            Mock = new Mock<IMongoCollection<Content>>();
            Mock.Setup(m => m.InsertOne(It.IsAny<Content>(), null, default))
                .Verifiable();
            Mock.Setup(m => m.ReplaceOne(It.IsAny<FilterDefinition<Content>>(), It.IsAny<Content>(), It.IsAny<ReplaceOptions>(), CancellationToken.None));
            Mock.Setup(m => m.DeleteOne(It.IsAny<FilterDefinition<Content>>(), CancellationToken.None))
                .Returns(new DeleteResult.Acknowledged(1));
        }

        public MongoCollectionMock() : this(new FindFluentMock()) { }
    }
}
