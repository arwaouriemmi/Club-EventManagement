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

        public List<Member> AddMembers(Club c, ICollection<string> role, ICollection<string> name)
        {
            List<Member> members = new List<Member>();

            for (var i = 0; i < role.Count(); i++)
            {
                string nam = name.ElementAt(i);
                string rol = role.ElementAt(i);
                members.Add(new Member(nam, rol, c));
            }
            return members;
        }

        public void DeleteAllEvents(Club e)
        {
            foreach (var entity in e.Events)
            {
                try
                {
                    _context.Event.Remove(entity);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void DeleteAllMembers(Club e)
        {
            foreach (var entity in e.Members)
            {
                try
                {
                    _context.Member.Remove(entity);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Club FindCompleteClub(int id)
        {
            return _context.Club.Where(c => c.Id == id).Include(c => c.Events).Include(c => c.Members).FirstOrDefault();
        }

        public IQueryable<Club> FindCompleteClubs()
        {
            return _context.Club.Include(c => c.Events).Include(c => c.Members);
        }

        public Club GetClubWithMembers(int id)
        {
            return _context.Club.Include(c => c.Members).Where(c => c.Id==id).FirstOrDefault();
        }

        public IQueryable<Club> SearchByNameOrDate(string name, int from, int to)
        {

            if (to == 0) to = 3000;
            
            return _context.Club.Where(c=> c.Name == name || (c.CreationYear>=from && c.CreationYear <=to));


        }

        public Club UpdateMembers(Club c, ICollection<string> id, ICollection<string> role, ICollection<string> name)
        {
            foreach(var m in c.Members)
            {
                if (!id.Contains(m.Id.ToString())) _context.Member.Remove(m);
            }

            for(var i= 0; i<id.Count(); i++)
            {
                int memId = int.Parse(id.ElementAt(i));
                string nam = name.ElementAt(i);
                string rol = role.ElementAt(i);
                if (memId==-1)
                    c.Members.Add(new Member(nam, rol, c));
                else
                {
                    Member m = c.Members.Find(el => el.Id == memId);
                    m.Name = nam;
                    m.Role = rol;
                }
            }
            return c;
        }
    }
}
