using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Vogi.ContentAutoat.Domain.Interfaces.Repository;
using Vogi.ContentAutoat.Domain.Model;

namespace Vogi.ContentAutoat.Application.Test.Mock
{
    public class ReadContentRepositoryMock
    {


        public Mock<IContentReadRepository> Mock { get; init; }


        public ReadContentRepositoryMock()
        {

            Mock = new Mock<IContentReadRepository>();

            Mock.Setup(repo => repo.GetAll(
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<Guid>(),
                It.IsAny<DateTime>(),
                It.IsAny<DateTime>())
            ).Returns(new List<ContentData>(new ContentData[] {
                new ContentData()
                {
                    Titel="Test Title",
                    Data= "Test Data",
                    Guid= Guid.Parse("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"),
                    Posted= DateTime.Parse("16.03.2005"),
                    User= Guid.Parse("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA")

                },
                new ContentData()
                {
                    Titel="Test Title1",
                    Data= "Test Data1",
                    Guid= Guid.Parse("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"),
                    Posted= DateTime.Parse("16.03.2005"),
                    User= Guid.Parse("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA")

                },
                new ContentData()
                {
                    Titel="Test Title2",
                    Data= "Test Data2",
                    Guid= Guid.Parse("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"),
                    Posted= DateTime.Parse("16.03.2005"),
                    User= Guid.Parse("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA")

                },
                new ContentData()
                {
                    Titel="Test Title3",
                    Data= "Test Data3",
                    Guid= Guid.Parse("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"),
                    Posted= DateTime.Parse("16.03.2005"),
                    User= Guid.Parse("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA")

                }
            }));


            Mock.Setup(repo => repo.FindByGuid(It.IsAny<Guid>()))
                .Returns(new ContentData()
                {
                    Titel = "Test Title3",
                    Data = "Test Data3",
                    Guid = Guid.Parse("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"),
                    Posted = DateTime.Parse("16.03.2005"),
                    User = Guid.Parse("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA")
                });


        }





    }
}
