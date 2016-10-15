using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IRepository<T> where T:class
    {
        IQueryable<T> GetItems();
        Task<IQueryable<T>> GetItemsAsync();
        Task<T> GetItemAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(T item);
        Task SaveAsync();
    }
}