using System.Collections.Generic;
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
            var items = await _orderRepository.GetItemsAsync();
            var outOrders = new List<OrderToUnload>();
            foreach (var item in items)
            {
                var outOrder = new OrderToUnload();
                foreach (var orderDetail in item.OrderDetail)
                {
                    outOrder.OrderId = item.ID;
                    outOrder.OrderDate = item.OrderDate;
                    outOrder.ProductId = orderDetail.ProductID;
                    outOrder.ProductName = orderDetail.Product.Name;
                    outOrder.ProductQuantity = orderDetail.Quantity;
                    outOrder.UnitPrice = outOrder.UnitPrice;
                    outOrders.Add(outOrder);
                }
            }
            return outOrders;
        }

        public Task UnloadToExcel(IEnumerable<OrderToUnload> ordersToUnload)
        {
            throw new System.NotImplementedException();
        }
    }
}