using Amazon.Runtime.Internal.Util;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vogi.ContentAutoat.Application.ContentHandler;
using Vogi.ContentAutoat.Application.Test.Mock;
using Vogi.ContentAutoat.Domain.Dtos.Mediator;
using Vogi.ContentAutoat.Domain.Dtos.Result;
using Vogi.ContentAutoat.Domain.Model;

namespace Vogi.ContentAutoat.Application.Test.Test
{
    public class TestAddContentHandler
    {
        [Fact]
        public void test_successfullyAdd()
        {
            WriteContentRepositoryMock repoMock = new WriteContentRepositoryMock();
            AddContentHandler handler = new AddContentHandler(repoMock.Mock.Object);

            var now = DateTime.Now;

            Task<Guid> data = handler.Handle(new ContentAddDto()
            {
                Data = "TestData",
                Titel = "TestTitel"
            }, CancellationToken.None);
           
            repoMock.Mock.Verify(mock => mock.Add(It.IsAny<ContentData>()), Times.Once);
        }


    }
}