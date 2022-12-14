using FrameworksProject.Data.Infrastructure;
using FrameworksProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FrameworksProject.Controllers
{
    public class ClubsController : Controller
    {
        private readonly IUnitOfWork unit = new UnitOfWork();

        public ClubsController(IUnitOfWork @object) => unit = @object;

        public ViewResult Index([FromQuery] int? page)
        {
            if (!page.HasValue)
                page = 1;

            int pageCount = (int)Math.Ceiling((double)unit.Clubs.getCount() / 6);

            List<Club> clubs = unit.Clubs.FindRange((page.Value - 1) * 6, 6).ToList();
            ViewBag.page = page;
            ViewBag.pageCount = pageCount;
            return View("Index", clubs);

        }
        [Route("clubs/{id}")]
        public ViewResult Club(int id)
        {
            return View("Club");
        }
        

        [HttpGet]
        public ViewResult Search()
        {
            return View("Search");
        }

        [HttpPost]
        public ViewResult Search(string name, string createdFrom, string createdTo)
        {
            int from;
            int to;
            if (createdFrom == "") from = 0;
            else int.TryParse(createdFrom, out from);
            if (createdTo == "") to = 0;
            else int.TryParse(createdTo, out to);


            if ( from!=0 && (from < 1900 || from > 2022))
            {
                ViewBag.error = "Invalid Year";
                return View("Search");
            }
            if ( to !=0 && to < 1900)
            {
                ViewBag.error = "Invalid Year";
                return View("Search");
            }

            ViewBag.name = name ?? "";
            ViewBag.from = createdFrom;
            ViewBag.to = createdTo;

            List<Club> clubs = unit.Clubs.SearchByNameOrDate(name, from, to).ToList();
            ViewBag.pageCount = 0;
            ViewBag.page = 0;
            return View("Index", clubs);
        }
    }
}
