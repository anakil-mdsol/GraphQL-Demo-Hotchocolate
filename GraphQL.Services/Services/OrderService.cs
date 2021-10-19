using GraphQL.Data;
using GraphQL.Interfaces;
using GraphQL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Services
{
    /// <summary>
    /// Order Service Class
    /// </summary>
    public class OrderService : IOrder
    {
        private AppDbContext appDbContext;

        public OrderService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        /// <inheritdoc cref="IOrder.AddOrder(Order)"/>
        public async Task<Order> AddOrder(Order order)
        {
            appDbContext.Orders.Add(order);

            await appDbContext.SaveChangesAsync();

            return order;
        }

        /// <inheritdoc cref="IOrder.DeleteOrder(int)" />
        public void DeleteOrder(int id)
        {
            Order product = appDbContext.Orders.Find(id);

            appDbContext.Orders.Remove(product);

            appDbContext.SaveChanges();
        }

        /// <inheritdoc cref="IOrder.DeleteOrder(int)" />
        public List<Order> GetAllOrders()
        {
            return appDbContext.Orders.ToList();
        }

        /// <inheritdoc cref="IOrder.GetOrderById(int)" />
        public Order GetOrderById(int id)
        {
            return appDbContext.Orders.Find(id);
        }

        /// <inheritdoc cref="IOrder.UpdateOrder(int, Order)" />
        public Order UpdateOrder(int id, Order newproduct)
        {
            Order product = appDbContext.Orders.Find(id);

            product.OrderDate = newproduct.OrderDate;
            product.CustomerName = newproduct.CustomerName;
            product.TotalAmount = newproduct.TotalAmount;

            appDbContext.SaveChanges();
            
            return product;
        }
    }
}
