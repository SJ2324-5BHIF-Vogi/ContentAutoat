using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vogi.ContentAutoat.Domain.Interfaces.ExtensionMethodeWrapper;
using Vogi.ContentAutoat.Domain.Model;

namespace Vogi.ContentAutoat.Repository.Test.Mock
{
    internal class SingleOrDefaultMock
    {
        public Mock<ISingleOrDefault> Mock { get; init; }

        public SingleOrDefaultMock(Content Single)
        {
            Mock = new Mock<ISingleOrDefault>();

            Mock.Setup(m => m.SingleOrDefault(It.IsAny<IFindFluent<Content, Content>>(), default))
                .Returns(Single);
            
        }
    }
}
