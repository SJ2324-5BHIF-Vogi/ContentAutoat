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
    internal class EnumerableMock
    {
        public Mock<IToEnumerable> Mock { get; init; }
        
        public EnumerableMock(IEnumerable<Content> list)
        {
            Mock = new Mock<IToEnumerable>();
            Mock.Setup(m => m.ToEnumerable(It.IsAny<IAsyncCursorSource<Content>>()))
                .Returns(list);
        }
    }
}
