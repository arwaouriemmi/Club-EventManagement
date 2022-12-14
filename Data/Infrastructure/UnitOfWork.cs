using FrameworksProject.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworksProject.Data.Infrastructure
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly ApplicationContext _context = ApplicationContext.Context;

        public IClubRepository clubs;
        public IEventRepository events;

        public IClubRepository Clubs
        {
            get
            {

                if (this.clubs == null)
                {
                    this.clubs = new ClubRepository(_context);
                }
                return clubs;
            }
        }

        public IEventRepository Events
        {
            get
            {

                if (this.events == null)
                {
                    this.events = new EventRepository(_context);
                }
                return events;
            }
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

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
