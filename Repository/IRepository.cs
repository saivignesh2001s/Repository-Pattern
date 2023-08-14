using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace Repository_pattern.Repository
{
    public interface IRepository<T> where T : class
    {
       public Task<List<T>> GetAllasync();
       public T Find(int id);
       public Task<bool> Addasync(T entity);
       public Task<bool > updateasync(T entity);
        public Task<bool> DeleteAsync(T entity);
    }
}
