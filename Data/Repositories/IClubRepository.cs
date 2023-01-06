using FrameworksProject.Data.Infrastructure;
using FrameworksProject.Models;
using System.Collections.Generic;
using System.Linq;


namespace FrameworksProject.Data.Repositories
{
    public interface IClubRepository: IRepository<Club>
    {
        IQueryable<Club> FindCompleteClubs();
        Club GetClubWithMembers(int id);
        IQueryable<Club> SearchByNameOrDate(string name,int from, int to);

        Club UpdateMembers(Club c, ICollection<string> id, ICollection<string> role, ICollection<string> name);
        List<Member> AddMembers(Club c, ICollection<string> role, ICollection<string> name);
            }
}
