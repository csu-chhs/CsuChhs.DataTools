using CsuChhs.DataTools.Interfaces;
using CsuChhs.DataTools.Models;
using Microsoft.EntityFrameworkCore;

namespace CsuChhs.DataTools.DAL
{
    public class EntityRepository<T> : IRepository<T> where T : BaseModel
    {
        private readonly DbContext _dbContext;

        public EntityRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public IQueryable<T> AllQueryable()
        {
            return _dbContext.Set<T>();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}