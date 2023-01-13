using FrameworksProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FrameworksProject.Data.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public static ApplicationContext _context;
        public DbSet<Event> Event { get; set; }
        public DbSet<Club> Club { get; set; }
        public DbSet<Member> Member { get; set; }

        private ApplicationContext(DbContextOptions o) : base(o) { }

        private static ApplicationContext Instantiate_ApplicationContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\onsou\Desktop\FrameworksProject\database.db");
            


            return new ApplicationContext(optionsBuilder.Options);

        }

        public static ApplicationContext Context
        {
            get
            {
                if (_context == null)
                    _context = Instantiate_ApplicationContext();
                return _context;
            }
        }

    }
}
