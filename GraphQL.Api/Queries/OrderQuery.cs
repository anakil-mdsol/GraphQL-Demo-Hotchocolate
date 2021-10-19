using GraphQL.Interfaces;
using GraphQL.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using System.Collections.Generic; 

namespace GraphQlApi.GraphQl.Queries
{
    [ExtendObjectType("Query")]
    public class OrderQuery
    {
        public IEnumerable<Order> GetAllOrders([Service] IOrder orderService)
        {
            return orderService.GetAllOrders();
        }
        public Order GetOrder([Service] IOrder orderService, int id)
        {
            return orderService.GetOrderById(id);
        }

    }
}
