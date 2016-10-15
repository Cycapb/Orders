using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Businesslogic
{
    public interface IOrderManager
    {
        Task<IEnumerable<Order>> GetOrders();
        Task UnloadToExcel();
    }
}