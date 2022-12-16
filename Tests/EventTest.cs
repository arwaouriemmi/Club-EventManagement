using FrameworksProject.Controllers;
using FrameworksProject.Data.Infrastructure;
using FrameworksProject.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        [TestCase("11-12-2020", "23-06-2023", "Test One")]
        public void Test_Search_Result(string from, string to, string name)
        {
            DateTime date1 = DateTime.ParseExact(from, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime date2 = DateTime.ParseExact(to, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            mockUnit.Setup(unit => unit.Events.Search(name, "All", "All", date1, date2)).Returns(Events().GetRange(0,1).AsQueryable());

            var controller = new EventsController(mockUnit.Object);

            var result = controller.Search(name, "All", "All", from, to) as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
            Assert.AreEqual(Events().GetRange(0, 1).ToString(), result.Model.ToString());
        }

        [TestCase(1)]
        [TestCase(10)]
        public void Test_Delete(int id)
        {
            Event c = id < 4 ? Events().ElementAt(id - 1) : null;
            mockUnit.Setup(unit => unit.Events.Find(id)).Returns(c);
            mockUnit.Setup(unit => unit.Complete()).Returns(true);

            if (id < 4)
            {
                mockUnit.Setup(unit => unit.Events.Delete(c)).Verifiable();
            }
            else
            {
                mockUnit.Setup(unit => unit.Events.Delete(c)).Throws<Exception>();
            }

            var controller = new EventsController(mockUnit.Object);
            var result = controller.Delete(id);

            Assert.AreEqual("Index", result.ActionName);

        }
        [TestCase(1)]
        public void Test_SelectEvent(int id)
        {
            var controller = new EventsController(mockUnit.Object);
            var result = controller.SelectEvent(id);
            Assert.AreEqual("SelectEvent", result.ViewName);

        }
        [TestCase("forum", "", "", "11-12-2020","waw","","","")]
        public void Test_EventCreation(string name, string category, string club, string date, string description, string staffForm, string participationForm, string image)
        {
            DateTime d = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var controller = new EventsController(mockUnit.Object);

            var result = controller.CreateEvent(name,category,club,date,description,staffForm,participationForm,image) as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
            Assert.AreEqual("Event has been created", result.TempData["success"]);
        }
        [TestCase(100000,"forum", "", "", "11-12-2020", "waw", "", "", "")]
        public void Test_EventUpdate(int id,string name, string category, string club, string date, string description, string staffForm, string participationForm, string image)
        {
            DateTime d = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var controller = new EventsController(mockUnit.Object);

            var result = controller.UpdateEvent(id,name, category, club, date, description, staffForm, participationForm, image) as ViewResult;
            Assert.AreEqual("UpdateEvent", result.ViewName);
        
        }

    }
}
