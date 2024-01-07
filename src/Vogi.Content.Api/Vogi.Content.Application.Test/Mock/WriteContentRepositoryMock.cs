using Moq;
using Moq.Language.Flow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vogi.ContentAutoat.Application.Test.Mock;
using Vogi.ContentAutoat.Domain.Interfaces.Repository;
using Vogi.ContentAutoat.Domain.Model;

namespace Vogi.ContentAutoat.Application.Test.Mock
{
    public class WriteContentRepositoryMock
    {


        public Mock<IContentWriteRepository> Mock { get; init; }
     

        public WriteContentRepositoryMock()
        {
            Mock = new Mock<IContentWriteRepository>();


            Mock.Setup(repo => repo.Add(It.IsAny<ContentData>()));

            Mock.Setup(repo => repo.Update(Guid.Parse("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"),It.IsAny<ContentData>()))
                    .Returns((Guid guid, ContentData contentData) =>1);
            Mock.Setup(repo => repo.Update(Guid.Parse("AAAAAAAA-AAAA-ADAA-AAAA-AAAAAAAAAAAA"), It.IsAny<ContentData>()))
                .Returns((Guid guid, ContentData contentData) => 0);

            Mock.Setup(repo => repo.Delete(Guid.Parse("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA")))
                .Returns((Guid guid) => true);

            Mock.Setup(repo => repo.Delete(Guid.Parse("AAAAAABA-AAAA-AAAA-AAAA-AAAAAAAAAAAA")))
                .Returns((Guid guid) => true);
        }

    }

}

