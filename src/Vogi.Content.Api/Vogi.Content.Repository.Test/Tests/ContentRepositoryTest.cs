using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Moq;
using Vogi.ContentAutoat.Domain.Interfaces.ExtensionMethodeWrapper;
using Vogi.ContentAutoat.Domain.Model;
using Vogi.ContentAutoat.Repository.Test.Mock;
using Xunit;

namespace Vogi.ContentAutoat.Repository.Test.Tests
{
    public class ContentRepositoryTest
    {
        [Fact]
        public void Test_Delete_Work()
        {
            var mongo = new FindFluentMock();
          
         //   _singleOrDefaultMock.Setup(f => f.SingleOrDefault(null,It.IsAny<IAsyncCursorSource<Content>>())).Returns(mongo.TestData()[0]);

            var contentRepo = new ContentRepository(_mContextM.Object, _toEnumerableMock.Object, _findFluentFindMock.Object, _singleOrDefaultMock.Object);

            var guid = mongo.TestData()[0].Guid;

            contentRepo.Delete(Guid.Empty);

         

        }
    }
}