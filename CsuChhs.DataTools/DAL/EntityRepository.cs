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

        public T GetSingle(int id)
        {
            return _dbContext.Set<T>()
                .Single(s => s.ID == id);
        }

        public async Task<T> GetSingleAsync(int id)
        {
            return await _dbContext.Set<T>()
                .SingleAsync(s => s.ID == id);
        }

        public T? GetSingleOrNull(int id)
        {
            return _dbContext.Set<T>()
                .SingleOrDefault(s => s.ID == id);
        }

        public async Task<T?> GetSingleOrNullAsync(int id)
        {
            return await _dbContext.Set<T>()
                .SingleOrDefaultAsync(s => s.ID == id);
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}