using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FrameworksProject.Data.Infrastructure
{
    public interface IRepository<T> where T:class
    {
        IQueryable<T> FindAll();
        public T Find(int id);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> FindRange(int beg, int number);

        int GetCount();
        void Create(T entity);
        void Update(T existingEntity, T entity);
        void Delete(T entity);
    }
}
