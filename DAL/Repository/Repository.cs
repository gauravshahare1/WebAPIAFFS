using WebAPIAFFS.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace WebAPIAFFS.DAL.Repositories
{
    public abstract class Repository<T, Tcontext> : IRepository<T> where T : class
        where Tcontext : DbContext
    {
        protected readonly Tcontext _context;
        protected Repository(Tcontext context)
        {
            _context = context;
        }

        public bool Add(T entity)
        {
            this._context.Set<T>().Add(entity);
            return true;
        }

        public bool Delete(T entity)
        {
            this._context.Set<T>().Remove(entity);
            return true;
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> result = this._context.Set<T>();
            return result;
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            IQueryable<T> result = this._context.Set<T>();
            return await result.ToListAsync();
        }

        public IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> result = this._context.Set<T>();
            if (condition != null)
            {
                result = result.Where(condition);
            }
            return result;
        }

        public async Task<ICollection<T>> GetAllByConditionAsync(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> result = this._context.Set<T>();
            if (condition != null)
            {
                result = result.Where(condition);
            }
            return await result.ToListAsync();
        }

        public IExecutionStrategy GetExecutionStrategy()
        {
            return this._context.Database.CreateExecutionStrategy();
        }

        public T GetSingle(Expression<Func<T, bool>> condition)
        {
            return this._context.Set<T>().Where(condition).FirstOrDefault();
        }

        public async Task<T> GetSingleAysnc(Expression<Func<T, bool>> condition)
        {
            var result = await this._context.Set<T>().Where(condition).FirstOrDefaultAsync();
            return result;
        }

        public void SaveChangesManaged()
        {
            this._context.SaveChanges();
        }

        public bool Update(T entity)
        {
            this._context.Entry(entity).State = EntityState.Modified;
            return true;
        }
    }
}
