using GraphQL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQL.Interfaces
{
    public interface IOrder
    {
        /// <summary>
        /// This will return All Order
        /// </summary>
        /// <returns>
        ///  This will return list of <see cref="Order"/> data
        /// </returns>
        List<Order> GetAllOrders();
        
        /// <summary>
        /// This will return the Order details of specified OrderId
        /// </summary>
        /// <param name="id">Required : Order id</param> 
        /// <returns>
        ///  This will return the specified of <see cref="Order"/> data
        /// </returns>
        Order GetOrderById(int id);

        /// <summary>
        /// This will add new Order
        /// </summary>
        /// <param name="order"> Required : Order </param>
        /// <returns>
        ///  This will return newly created <see cref="Order"/>
        /// </returns>
        Task<Order> AddOrder(Order order);

        /// <summary>
        /// This will update existing Order
        /// </summary>
        /// <param name="order"> Required : Order </param>
        /// <param name="id">Required : id</param> 
        /// <returns>
        ///  This will update <see cref="Order"/> data
        /// </returns>
        Order UpdateOrder(int id, Order order);

        /// <summary>
        /// This will delete existing Order
        /// </summary>
        /// <param name="id">Required : id</param> 
        /// <returns>
        ///  This will delete <see cref="Order"/> data
        /// </returns>
        void DeleteOrder(int id);
    }
}
