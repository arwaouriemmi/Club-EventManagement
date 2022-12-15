using System;
using System.Linq;
using System.Linq.Expressions;

namespace FrameworksProject.Data.Infrastructure
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationContext _context;
        public Repository(ApplicationContext context)
        {
           _context = context;
        }

        public IQueryable<T> FindAll()
        {
            return _context.Set<T>();
        }

        public T Find(int id)
        {
            T t= _context.Set<T>().Find(id);
            return t;
            
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
        public void Create(T entity) {
            try
            {
                _context.Set<T>().Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        public void Update(T entity) {
            try
            {
                _context.Set<T>().Update(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        public void Delete(T entity) {
            try
            {
                _context.Set<T>().Remove(entity);
            }
            catch (Exception ex) { throw ex; }
        }

        public IQueryable<T> FindRange(int beg, int number)
        {
            return _context.Set<T>().Skip(beg).Take(number);
        }

        int IRepository<T>.getCount()
        {
            return _context.Set<T>().Count();
        }
    }
}