using FrameworksProject.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworksProject.Data.Infrastructure
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApplicationContext _context;

        public IClubRepository Clubs { get; }
        public IEventRepository Events { get; }

        public UnitOfWork(ApplicationContext context)
        {
            this._context = context;
            Clubs = new ClubRepository(context);
            Events = new EventRepository(context);

        }

        public bool Complete()
        {
            try
            {
                int res = _context.SaveChanges();
                if (res > 0)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
