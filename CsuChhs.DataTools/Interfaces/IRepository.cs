using CsuChhs.DataTools.Models;

namespace CsuChhs.DataTools.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        IQueryable<T> AllQueryable();
        void Update(T entity);
        void Delete(T entity);
        T Add(T entity);
        T AddBulk(T entity);
        void SaveChanges();
    }
}