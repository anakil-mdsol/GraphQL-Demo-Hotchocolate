using GraphQL.Interfaces;
using GraphQL.Models;
using GraphQlApi.GraphQl.Types;
using HotChocolate;
using HotChocolate.Types;
using System.Threading.Tasks;

namespace GraphQlApi.GraphQl.Mutations
{
    [ExtendObjectType("Mutation")]
    public class OrderMutation
    {
        public async Task<Order> AddOrderAsync(AddOrderInput input, [Service] IOrder orderService)
        {
            var order = new Order {
                CustomerName = input.CustomerName,
                OrderDate = input.OrderDate,
                TotalAmount = input.TotalAmount,
                Products = input.Products
            };

            await orderService.AddOrder(order);

            return order;
        }
    }
}
