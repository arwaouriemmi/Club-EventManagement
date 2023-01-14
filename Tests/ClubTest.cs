using FrameworksProject.Controllers;
using FrameworksProject.Models;
using FrameworksProject.Data.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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

        [TestCase("Test One", "2005", "2023")]
        public void Test_Search_Result(string name, string from, string to)
        {
            int.TryParse(from, out int year1);
            int.TryParse(to, out int year2);

            if (year1 != 0 && year2 != 0)
                mockUnit.Setup(unit => unit.Clubs.SearchByNameOrDate(name, year1, year2)).Returns(Clubs().GetRange(1, 1).AsQueryable());

            var controller = new ClubsController(mockUnit.Object);

            var result = controller.Search(name, from, to);

             Assert.AreEqual("Index", result.ViewName);
             Assert.AreEqual(Clubs().GetRange(1, 1).ToString(), result.Model.ToString());
        }
        /*
        [TestCase(1)]
        [TestCase(10)]
        public void Test_Delete(int id)
        {
            Club c = Clubs().ElementAtOrDefault(id-1);
            mockUnit.Setup(unit => unit.Clubs.Find(id)).Returns(c);
            mockUnit.Setup(unit => unit.Complete()).Returns(true);

            if (id < 4)
            {
                mockUnit.Setup(unit => unit.Clubs.Delete(c)).Verifiable();
            }
            else
            {
                mockUnit.Setup(unit => unit.Clubs.Delete(c)).Throws<Exception>();
            }

            var controller = new ClubsController(mockUnit.Object);
            var result = controller.Delete(id);

            Assert.AreEqual("Index", result.ActionName);

        
        }
        
        [TestCase(1)]
        public void Test_SelectClub(int id)
        {
            var controller = new ClubsController(mockUnit.Object);
            var result = controller.Club(id);
            Assert.AreEqual("Club", result.ViewName);

        }

        
        [TestCase(100000, "junior", "", "", "2022","","","")]
        public void Test_ClubUpdate1(int id, string name, string description, string website, int creationYear, string logo,string president,string hr)
        { 
            var controller = new ClubsController(mockUnit.Object);

            var result = controller.Update(id, name,description,website,creationYear,logo,"","") as ViewResult;
            Assert.AreEqual("UpdateClub", result.ViewName);
          

        }
        [TestCase(1, "junior", "", "", "2022", "","","")]
        public void Test_ClubUpdate2(int id, string name, string description, string website, int creationYear, string logo,string president,string hr)
        {
            var controller = new ClubsController(mockUnit.Object);
            var result = controller.Update(id, name, description, website, creationYear, logo,president,hr) as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
            Assert.AreEqual("Club has been updated", result.TempData["success"]);
        }
    */
    }

}
