using FrameworksProject.Controllers;
using FrameworksProject.Data.Infrastructure;
using FrameworksProject.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace FrameworksProject.Test
{
    [TestFixture]
    public class EventTest
    {

        private readonly Mock<IUnitOfWork> mockUnit = new Mock<IUnitOfWork>();

        private static List<Event> Events()
        {
            Club club = new Club("Club ", "desc", "website", 2010, "logo");
            var r = new List<Event>
            {
                new Event("Test One", "CP", DateTime.Today, "desc", "link", "link", "more links", club),
                new Event("Test Two", "CP", DateTime.Today, "desc", "link", "link", "more links", club),
                new Event("Test Two", "CP", DateTime.Today, "desc", "link", "link", "more links", club),
            };
            return r;

        }

        [Test]
        public void Test_Get_Page([Values(1)] int page)
        {
            var controller = new EventsController(mockUnit.Object);
            mockUnit.Setup(unit => unit.Events.FindRange((page-1)*6, 6)).Returns(Events().AsQueryable());
            // Act
            var result = controller.Index(1);

            // Assert
            Assert.AreEqual("Index", result.ViewName);
            Assert.AreEqual(Events().ToString(), result.Model.ToString());
        }

        [Test]
        public void Test_Search()
        {
            var controller = new ClubsController(mockUnit.Object);

            var result = controller.Search();
            Assert.AreEqual("Search", result.ViewName);
        }

        [Test]
        public void Test_Search_Result([Values("11-12-2020")] string from, string to, string name)
        {
            mockUnit.Setup(unit => unit.Events.Search(name, "All", "All", new DateTime(2020, 12,11), new DateTime(0001, 10,10))).Returns(Events().AsQueryable());

            var controller = new EventsController(mockUnit.Object);

            var result = controller.Search(name, "All", "All", from, to) as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
            Assert.AreEqual(Events(), result.Model.ToString());
        }

        [Test]
        public void Test_Search_Invalid([Values("22/06/120")] string from, string to, string name)
        {
            var controller = new EventsController(mockUnit.Object);

            var result = controller.Search(name, "All", "All", from, to) as RedirectToActionResult;

            Assert.AreEqual("Search", result.ActionName);
            Assert.AreEqual("Events", result.ControllerName);
        }

    }
}
