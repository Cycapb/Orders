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

        public OrderManager(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<OrderToUnload>> GetOrders()
        {
            var items = (await _orderRepository.GetItemsAsync());
            var outOrders = new List<OrderToUnload>();
            foreach (var item in items)
            {
                outOrders.AddRange(item.OrderDetail.Select(s => new OrderToUnload()
                {
                    OrderId = s.ID,
                OrderDate = s.Order.OrderDate,
                ProductId = s.ProductID,
                ProductName = s.Product.Name,
                ProductQuantity = s.Quantity,
                UnitPrice = s.UnitPrice
            }));
            }
            return outOrders;
        }

        public Task UnloadToExcel(IEnumerable<OrderToUnload> ordersToUnload)
        {
            throw new System.NotImplementedException();
        }
    }
}