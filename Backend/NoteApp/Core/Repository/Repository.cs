using Core.Database;
using Microsoft.EntityFrameworkCore;

namespace NoteApp.Core.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<T>> AllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }
        public async Task<T> GetAsync(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public T Get(Guid id)
        {
            return context.Set<T>().Find(id);
        }

        public bool Add(T entity)
        {
            try
            {
                if (entity != null)
                {
                    context.Set<T>().Add(entity);

                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }

        public bool Update(T entity)
        {
            try
            {
                if (entity != null)
                {
                    context.Set<T>().Update(entity);

                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }

        public virtual bool Delete(T entity)
        {
            try
            {
                if (entity != null)
                {
                    context.Set<T>().Remove(entity);

                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }
    }
}
