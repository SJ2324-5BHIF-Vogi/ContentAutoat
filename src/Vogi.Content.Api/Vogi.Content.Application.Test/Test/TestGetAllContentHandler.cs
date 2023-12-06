using Moq;
using Vogi.ContentAutoat.Application.ContentHandler;
using Vogi.ContentAutoat.Application.Test.Mock;
using Vogi.ContentAutoat.Domain.Dtos.Mediator;
using Vogi.ContentAutoat.Domain.Dtos.Result;

namespace Vogi.ContentAutoat.Application.Test.Test
{

    public class TestGetAllContentHandler
    {
        [Fact]
        public void test_successfullyGetAll()
        {
            ReadContentRepositoryMock repoMock = new ReadContentRepositoryMock();
            GetAllContentHandler handler = new GetAllContentHandler(repoMock.Mock.Object);

            var now = DateTime.Now;

            Task<IEnumerable<ContentDisplayDto>> data = handler.Handle(new ContentGetAllDto()
            {
                NachGrenze = now,
                Page = 1,
                PageSize = 10,
                User = Guid.Parse("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"),
                VorGrenze = now

            }, CancellationToken.None);
            Assert.Equal(4, data.Result.Count());

            repoMock.Mock.Verify(mock => mock.GetAll(1, 10, Guid.Parse("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"), now, now), Times.Once);
        }
    }
}