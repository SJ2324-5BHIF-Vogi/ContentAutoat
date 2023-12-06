using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

         //   Mock.Setup(repo => repo.Add(It.IsAny<ContentData>()));


        }
    }
}
