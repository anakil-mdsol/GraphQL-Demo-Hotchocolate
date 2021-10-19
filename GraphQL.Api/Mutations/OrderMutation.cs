using GraphQL.Interfaces;
using GraphQL.Models;
using GraphQlApi.GraphQl.Types.InputTypes;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlApi.GraphQl.Mutations
{
    [ExtendObjectType("Mutation")]
    public class OrderMutation
    {
        public async Task<Order> AddOrderAsync(AddOrderInput input, [Service] IOrder orderService)
        {
            var order = new Order
            {
                CustomerName = input.CustomerName,
                OrderDate = input.OrderDate,
                TotalAmount = input.TotalAmount,
                Products = input.Products.Select(p => new Product
                {
                    Name = p.Name,
                    Price = p.Price
                }).ToList()
            };

            order = await orderService.AddOrder(order);

            return order;
        }
    }
}