using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;

namespace Businesslogic
{
    public interface IOrderManager
    {
        Task<IEnumerable<OrderToUnload>> GetOrders();
        Task UnloadToExcel(IEnumerable<OrderToUnload> ordersToUnload);
    }
}