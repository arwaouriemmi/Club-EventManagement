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
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> FindRange(int beg, int number);

        int getCount();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
