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
    internal class FluentFIndMock
    {
        public Mock<IFindFluentFind> Mock { get; init; }
        public FindFluentMock FindFluentMock { get; init; } 

        public FluentFIndMock(FindFluentMock findFluentMock)
        {
            FindFluentMock = findFluentMock;
            
            Mock = new Mock<IFindFluentFind>();
            Mock.Setup(m => m.Find(It.IsAny<IMongoCollection<ContentData>>(), It.IsAny<FilterDefinition<ContentData>>(), default!))
                    .Returns(FindFluentMock.Mock.Object);
        }

        public FluentFIndMock():this(new FindFluentMock()) { }
    }
}
