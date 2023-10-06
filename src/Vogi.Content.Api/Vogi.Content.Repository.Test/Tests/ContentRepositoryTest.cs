using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Moq;
using Vogi.ContentAutoat.Domain.Interfaces.ExtensionMethodeWrapper;
using Vogi.ContentAutoat.Domain.Model;
using Vogi.ContentAutoat.Repository.Test.Mock;
using Vogi.ContentAutoat.Repository.Test.Repository;
using Xunit;

namespace Vogi.ContentAutoat.Repository.Test.Tests
{
    public class ContentRepositoryTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void Test_Delete_Work(int i)
        {
            //Setup
            var RepoMocked = new ContentRepositoryMocked();

            var Repo = RepoMocked.Repo;
            var guid = RepoMocked.FindFluentMock.TestData[0].Guid;

            //Try
            Repo.Delete(guid);


            //Assert
      //      RepoMocked.MongoCollectionM.Mock.Verify(m => m.DeleteOne(It.Is<FilterDefinition<Content>>(w=>w)), Times.Once);
        }

        [Fact]
        public void Test_Delete_NoExistingGuid()
        {
            //Setup
            var RepoMocked = new ContentRepositoryMocked();

            var Repo = RepoMocked.Repo;
            var guid = Guid.NewGuid();

            //Try
            Repo.Delete(guid);


            //Assert
            RepoMocked.MongoCollectionM.Mock.Verify(m => m.DeleteOne(It.Is<FilterDefinition<Content>>(w => w.ToBson(null, null, null, default) == Builders<Content>.Filter.Eq(c => c.Guid, guid).ToBson(null, null, null, default)), default), Times.Never);
        }


        [Fact]
        public void Test_Add_Work()
        {
            //Setup
            var RepoMocked = new ContentRepositoryMocked();

            var Repo = RepoMocked.Repo;
            var guid = Guid.NewGuid();

            var Content = new Content()
            {
                Data = "JaJaJaJa",
                Guid = Guid.NewGuid(),
                Posted = DateTime.Now,
                Titel = "Title",
                User = Guid.NewGuid()
            };

            //Try
            Repo.Add(Content);


            //Assert
            RepoMocked.MongoCollectionM.Mock.Verify(m => m.InsertOne(Content ,null,default), Times.Once);
        }
    }
}