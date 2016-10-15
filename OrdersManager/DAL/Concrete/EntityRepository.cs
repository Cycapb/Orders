using System.Data.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using DAL.Abstract;
using DAL.Models;

namespace DAL.Concrete
{
    public class EntityRepository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        private readonly OrdersContext _context;

        public EntityRepository()
        {
            _context = new OrdersContext();
            _dbSet = _context.Set<T>();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _dbSet.FindAsync();
            if (item != null)
            {
                await Task.Run(() => _dbSet.Remove(item));
            }
        }

        public async Task<T> GetItemAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IEnumerable<T> GetItems()
        {
            return _dbSet.AsEnumerable();
        }

        public async Task<IEnumerable<T>> GetItemsAsync()
        {
            return await Task.Run(() => _dbSet.AsEnumerable());
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T item)
        {
            await Task.Run(() =>_context.Entry(item).State = EntityState.Modified);
           
        }
    }
}