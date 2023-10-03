using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vogi.ContentAutoat.Domain.Interfaces.Infrastructure;
using Vogi.ContentAutoat.Domain.Model;

namespace Vogi.ContentAutoat.Repository.Test.Mock
{
    internal class FindFluentMock
    {
        public Mock<IFindFluent<Content, Content>> Mock { get; init; }

        public FindFluentMock()
        {
            Mock = new Mock<IFindFluent<Content, Content>>();
            Mock.SetupSequence(m => m.Skip(It.IsAny<int>()))
                          .Returns(Mock.Object);
            Mock.SetupSequence(m => m.Limit(It.IsAny<int>()))
                          .Returns(Mock.Object);

        }

        public List<Content> TestData => new List<Content>(new Content[]
            {
                new Content
            {
                Titel = "Erster Tweet",
                Data = "Das ist mein erster Tweet!",
                Posted = DateTime.Now.AddMinutes(-120),
                Guid = new Guid("11111111-1111-1111-1111-111111111111"),
                User = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa")
            },
            new Content
            {
                Titel = "Zweiter Tweet",
                Data = "Jetzt verstehe ich, wie das funktioniert.",
                Posted = DateTime.Now.AddMinutes(-90),
                Guid = new Guid("22222222-2222-2222-2222-222222222222"),
                User = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb")
            },
            new Content
            {
                Titel = "Dritter Tweet",
                Data = "Ich liebe diese Plattform!",
                Posted = DateTime.Now.AddMinutes(-60),
                Guid = new Guid("33333333-3333-3333-3333-333333333333"),
                User = new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc")
            },
            new Content
            {
                Titel = "Vierter Tweet",
                Data = "Schaut euch das an! #cool",
                Posted = DateTime.Now.AddMinutes(-30),
                Guid = new Guid("44444444-4444-4444-4444-444444444444"),
                User = new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd")
            },
            new Content
            {
                Titel = "Fünfter Tweet",
                Data = "Ich kann nicht glauben, dass es schon so spät ist.",
                Posted = DateTime.Now,
                Guid = new Guid("55555555-5555-5555-5555-555555555555"),
                User = new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee")
            }
            });
    }
}
