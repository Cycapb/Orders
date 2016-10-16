using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Abstract;
using DAL.Models;
using Domain;

namespace Businesslogic
{
    public class OrderManager:IOrderManager
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IUnloader<OrderToUnload> _excelUnloader;

        public OrderManager(IRepository<Order> orderRepository, IUnloader<OrderToUnload> excelUnloader)
        {
            _orderRepository = orderRepository;
            _excelUnloader = excelUnloader;
        }

        public async Task<IEnumerable<OrderToUnload>> GetOrders()
        {
            var orders =  await _orderRepository.GetItemsAsync();
            var outOrders = (from o in orders
                         from od in o.OrderDetail
                         select new OrderToUnload()
                         {
                             OrderId = o.ID,
                             OrderDate = o.OrderDate,
                             ProductId = od.ProductID,
                             ProductName = od.Product.Name,
                             ProductQuantity = od.Quantity,
                             UnitPrice = od.UnitPrice
                         })
                         .ToList();

            return outOrders;
        }

        public Task UnloadToExcel(IEnumerable<OrderToUnload> ordersToUnload)
        {
            return Task.Run(() => _excelUnloader.Unload(ordersToUnload));
        }
    }
}