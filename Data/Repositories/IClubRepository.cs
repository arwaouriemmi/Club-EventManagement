using FrameworksProject.Data.Infrastructure;
using FrameworksProject.Models;
using System.Collections.Generic;
using System.Linq;


namespace FrameworksProject.Data.Repositories
{
    public interface IClubRepository: IRepository<Club>
    {
        IQueryable<Club> findCompleteClubs();
        IQueryable<Club> SearchByNameOrDate(string name,int from, int to);
    }
}
