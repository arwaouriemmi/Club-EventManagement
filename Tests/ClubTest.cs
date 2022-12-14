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
    public class ClubTest
    {
        private readonly Mock<IUnitOfWork> mockUnit = new Mock<IUnitOfWork>();


        private static List<Club> Clubs()
        {
            var r = new List<Club>
            {
                new Club("Club ", "desc", "website", 2010, "logo"),
                new Club("Club 2", "desc", "website", 2015, "logo"),
                new Club("Club 3", "desc", "website", 2005, "logo"),
            };
            return r;

        }

        [Test]
        public void Test_Get_Page([Values(1)] int page)
        {
            mockUnit.Setup(unit => unit.Clubs.FindRange((page-1)*6, 6)).Returns(Clubs().AsQueryable());
            var controller = new ClubsController(mockUnit.Object);

            var result = controller.Index(1);
            Assert.AreEqual("Index", result.ViewName);
            Assert.AreEqual(Clubs().ToString(), result.ViewData.Model.ToString());
        }

        [Test]
        public void Test_Search()
        {
            var controller = new ClubsController(mockUnit.Object);

            var result = controller.Search();
            Assert.AreEqual("Search", result.ViewName);
        }

        [Test]
        public void Test_Search_Result([Values("Test Two", "2015", "2020")] string name, string from, string to)
        {
            mockUnit.Setup(unit => unit.Clubs.SearchByNameOrDate(name, 2015, 2020)).Returns(Clubs().GetRange(1,1).AsQueryable());

            var controller = new ClubsController(mockUnit.Object);

            var result = controller.Search(name, from, to);
            Assert.AreEqual("Index", result.ViewName);
            Assert.AreEqual(Clubs().GetRange(1, 1).ToString(), result.Model.ToString());
        }

        [Test]
        public void Test_Search_Invalid([Values("Test Two", "5", "2020")] string name, string from, string to)
        {
            var controller = new ClubsController(mockUnit.Object);

            var result = controller.Search(name, from, to);
            Assert.AreEqual("Search", result.ViewName);
            Assert.AreEqual("Invalid Year", result.ViewData["error"]);
        }
    }
}
