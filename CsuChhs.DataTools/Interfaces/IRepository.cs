using CsuChhs.DataTools.Models;

namespace CsuChhs.DataTools.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        T GetSingle(int id);
        T? GetSingleOrNull(int id);
        Task<T> GetSingleAsync(int id);
        Task<T?> GetSingleOrNullAsync(int id);
        IQueryable<T> AllQueryable();
        void Update(T entity);
        void Delete(T entity);
        T Add(T entity);
    }
}