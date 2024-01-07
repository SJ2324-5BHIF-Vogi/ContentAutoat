using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vogi.ContentAutoat.Application.ContentHandler;
using Vogi.ContentAutoat.Application.Test.Mock;
using Vogi.ContentAutoat.Domain.Dtos.Mediator;
using Vogi.ContentAutoat.Domain.Model;

namespace Vogi.ContentAutoat.Application.Test.Test
{
    public class TestUpdateContentHandler
    {

        [Fact]
        public void test_successfullyUpdate()
        {
            WriteContentRepositoryMock repoMock = new WriteContentRepositoryMock();
            UpdateContentHandler handler = new UpdateContentHandler(repoMock.Mock.Object);

            var now = DateTime.Now;
            var guid = Guid.Parse("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");
            var data = handler.Handle(new ContentUpdateDto()
            {
                Data = "TestData",
                Titel = "TestTitel",
                Guid = guid,
            }, CancellationToken.None);

            repoMock.Mock.Verify(mock => mock.Update(It.IsAny<Guid>(),It.IsAny<ContentData>()), Times.Once);
            repoMock.Mock.Verify(mock => mock.Update(guid,It.IsAny<ContentData>()), Times.Once);
        }

        [Fact]
        public void test_notexistingGuidUpdate()
        {
            WriteContentRepositoryMock repoMock = new WriteContentRepositoryMock();
            UpdateContentHandler handler = new UpdateContentHandler(repoMock.Mock.Object);

            var now = DateTime.Now;
            var guid = Guid.Parse("AAAAAAAA-AAAA-ADAA-AAAA-AAAAAAAAAAAA");
            var data = handler.Handle(new ContentUpdateDto()
            {
                Data = "TestData",
                Titel = "TestTitel",
                Guid = guid,
            }, CancellationToken.None);

            repoMock.Mock.Verify(mock => mock.Update(guid, It.IsAny<ContentData>()), Times.Once);
        }


    }
}
