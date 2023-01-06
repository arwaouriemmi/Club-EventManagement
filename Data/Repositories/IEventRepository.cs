using FrameworksProject.Data.Infrastructure;
using FrameworksProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworksProject.Data.Repositories
{
    public interface IEventRepository: IRepository<Event>
    {
        List<string> FindAllClubs();
        List<string> FindAllCategories();
        Event FindEventWithDetails(int id);

        IQueryable<Event> Search(string name, string category, string club, DateTime from, DateTime to);
    }
}
