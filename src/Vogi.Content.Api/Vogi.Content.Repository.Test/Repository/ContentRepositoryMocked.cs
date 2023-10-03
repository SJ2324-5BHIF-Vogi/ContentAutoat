using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vogi.ContentAutoat.Domain.Interfaces.ExtensionMethodeWrapper;
using Vogi.ContentAutoat.Repository.Test.Mock;

namespace Vogi.ContentAutoat.Repository.Test.Repository
{
    public class ContentRepositoryMocked
    {
        public ContentRepository Repo { get; init; }
        public ContentRepositoryMocked()
        {
            var _findFM = new FindFluentMock();
            var _mCollectionM = new MongoCollectionMock(_findFM);
            var _mContextM = new MongoContextMock(_mCollectionM);
            var _toEnumerableMock = new Mock<IToEnumerable>();
            var _findFluentFindMock = new Mock<IFindFluentFind>();
            var _singleOrDefaultMock = new Mock<ISingleOrDefault>();
            Repo = new ContentRepository(_mContextM.Mock.Object, _toEnumerableMock.Object, _findFluentFindMock.Object, _singleOrDefaultMock.Object);
        }
    }
}
