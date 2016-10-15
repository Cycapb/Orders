using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetItems();
        Task<IEnumerable<T>> GetItemsAsync();
        Task<T> GetItemAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(T item);
        Task SaveAsync();
    }
}