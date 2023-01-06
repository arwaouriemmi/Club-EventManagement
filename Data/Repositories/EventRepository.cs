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

        public Event FindEventWithDetails(int id)
        {
            return _context.Event.Include(e => e.Club).Where(e=> e.Id == id).FirstOrDefault();
        }

        public List<string> FindAllCategories()
        {
            return _context.Event.Select(e => e.Category).Distinct().ToList();
        }

        public List<string> FindAllClubs()
        {
            return _context.Event.Include( e=> e.Club).Select(e => e.Club.Name).Distinct().ToList();
        }

        public IQueryable<Event> Search(string name, string category, string club, DateTime from, DateTime to) 
        {
            IQueryable<Event> query = _context.Event.Include(e => e.Club);
            Debug.WriteLine(name != null);
            Debug.WriteLine(category != "All");
            Debug.WriteLine(club != "All");
            Debug.WriteLine(from.Year != 0001);
            Debug.WriteLine(to.Year != 0001);

            if (category!="All")
                query = query.Where(e => e.Category == category);
            
            if (name!=null)
                query = query.Where(e => e.Name.ToLower() == name.ToLower());

            if (club != "All")
                query = query.Where(e => e.Club.Name == club);

            if (from.Year!=0001)
                query = query.Where(e => DateTime.Compare(e.Date, from)>=0);

            if (to.Year != 0001)
                query = query.Where(e => DateTime.Compare(e.Date, to) <= 0);

            return query;
        }
    }
}