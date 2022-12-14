using FrameworksProject.Data.Infrastructure;
using FrameworksProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FrameworksProject.Data.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {

        public EventRepository(ApplicationContext context) : base(context)
        {
        }

        public List<string> FindAllCategories()
        {
            return _context.Event.Select(e => e.category).Distinct().ToList();
        }

        public List<string> FindAllClubs()
        {
            return _context.Event.Include( e=> e.club).Select(e => e.club.name).Distinct().ToList();
        }

        public IQueryable<Event> Search(string name, string category, string club, DateTime from, DateTime to) 
        {
            IQueryable<Event> query = _context.Event.Include(e => e.club);
            Debug.WriteLine(name != null);
            Debug.WriteLine(category != "All");
            Debug.WriteLine(club != "All");
            Debug.WriteLine(from.Year != 0001);
            Debug.WriteLine(to.Year != 0001);

            if (category!="All")
                query = query.Where(e => e.category == category);
            
            if (name!=null)
                query = query.Where(e => e.name.ToLower() == name.ToLower());

            if (club != "All")
                query = query.Where(e => e.club.name == club);

            if (from.Year!=0001)
                query = query.Where(e => DateTime.Compare(e.date, from)>=0);

            if (to.Year != 0001)
                query = query.Where(e => DateTime.Compare(e.date, to) <= 0);

            return query;
        }
    }
}