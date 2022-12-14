using FrameworksProject.Data.Infrastructure;
using FrameworksProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace FrameworksProject.Data.Repositories
{
    public class ClubRepository : Repository<Club>, IClubRepository
    {
        public ClubRepository(ApplicationContext context): base(context)
        {

        }

        public IQueryable<Club> findCompleteClubs()
        {
            return _context.Club.Include(c => c.events).Include(c => c.members);
        }

        public IQueryable<Club> SearchByNameOrDate(string name, int from, int to)
        {

            if (to == 0) to = 3000;
            
            return _context.Club.Where(c=> c.name == name || (c.creationYear>=from && c.creationYear <=to));


        }
    }
}
