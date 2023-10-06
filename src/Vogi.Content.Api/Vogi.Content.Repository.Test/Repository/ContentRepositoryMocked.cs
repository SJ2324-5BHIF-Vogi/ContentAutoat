using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vogi.ContentAutoat.Domain.Interfaces.ExtensionMethodeWrapper;
using Vogi.ContentAutoat.Repository.Test.Mock;

namespace Vogi.ContentAutoat.Repository.Test.Repository
{
    internal class ContentRepositoryMocked
    {
        public ContentRepository Repo { get; init; }

        public FindFluentMock FindFluentMock { get; init; }
        public MongoCollectionMock MongoCollectionM { get; init; }
        public MongoContextMock MongoContextM { get; init; }
        public EnumerableMock ToEnumerableMock { get; init; }
        public SingleOrDefaultMock SingleOrDefaultMock { get; init; }
        public FluentFIndMock FluentFIndInterfaceMock { get; init; }

        public ContentRepositoryMocked()
        {
            FindFluentMock = new FindFluentMock();
            MongoCollectionM = new MongoCollectionMock(FindFluentMock);
            MongoContextM = new MongoContextMock(MongoCollectionM);
            ToEnumerableMock = new EnumerableMock(FindFluentMock.TestData);
            SingleOrDefaultMock = new SingleOrDefaultMock(FindFluentMock.TestData[0]);
            FluentFIndInterfaceMock = new FluentFIndMock(FindFluentMock);

            Repo = new ContentRepository(MongoContextM.Mock.Object, ToEnumerableMock.Mock.Object, FluentFIndInterfaceMock.Mock.Object, SingleOrDefaultMock.Mock.Object);
        }
    }
}
