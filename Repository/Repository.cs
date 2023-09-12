using Microsoft.EntityFrameworkCore;
using Repository_pattern.context;

namespace Repository_pattern.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbClass dbcontext;
        public Repository(DbClass dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public Task<bool> Addasync(T entity)
        {
            try
            {
                dbcontext.Set<T>().AddAsync(entity);
                dbcontext.SaveChanges();
                return Task.FromResult(true);
            
            }
            catch
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> DeleteAsync(int id)
        {
            try
            {
                T entity =dbcontext.Set<T>().Find(id);
                dbcontext.Set<T>().Remove(entity);
                dbcontext.SaveChanges();
                return Task.FromResult(true);
            }
            catch
            {
                return Task<bool>.FromResult(false);
            }
        }

        public  Task<T> Find(int id)
        {
           T entity =dbcontext.Set<T>().Find(id);
          return Task.FromResult(entity);
        } 

        public Task<List<T>> GetAllasync()
        {
            return dbcontext.Set<T>().ToListAsync();
        }

        public Task<bool> updateasync(T entity)
        {
            try
            {
                dbcontext.Set<T>().Attach(entity);
                dbcontext.SaveChanges();
                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }
    }
}
