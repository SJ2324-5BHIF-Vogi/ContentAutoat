using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vogi.ContentAutoat.Application.ContentHandler;
using Vogi.ContentAutoat.Application.Test.Mock;
using Vogi.ContentAutoat.Domain.Dtos.Mediator;
using Vogi.ContentAutoat.Domain.Dtos.Mediator.Base;

namespace Vogi.ContentAutoat.Application.Test.Test
{
    public class TestGetContentHandler
    {
        [Fact]

        public void test_successfullyGetContent()
        {
            ReadContentRepositoryMock repoMock = new ReadContentRepositoryMock();
            GetContentHandler handler = new GetContentHandler(repoMock.Mock.Object);

            var data = handler.Handle(new ContentGetDto()
            {
                guid = Guid.Parse("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA")
            },
            CancellationToken.None
            );
            Assert.NotNull(data);

            repoMock.Mock.Verify(mock => mock.FindByGuid(Guid.Parse("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA")));


        }

    }
}
