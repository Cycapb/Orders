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
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IRepository<Product> _productRepository;


        public OrderManager(IRepository<Order> orderRepository, IRepository<OrderDetail> orderDetailRepository, IRepository<Product> productRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<OrderToUnload>> GetOrders()
        {
            var orders = (await _orderRepository.GetItemsAsync()).ToList();
            var orderDetails = await _orderDetailRepository.GetItemsAsync();
            var outOrders = (from o in orders
                         join od in orderDetails on o.ID equals od.OrderID
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
            throw new System.NotImplementedException();
        }
    }
}