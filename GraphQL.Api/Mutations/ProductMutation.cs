using GraphQL.Interfaces;
using GraphQL.Models;
using GraphQlApi.GraphQl.Types.InputTypes;
using HotChocolate;
using HotChocolate.Types;
using System.Threading.Tasks;

namespace GraphQlApi.GraphQl.Mutations
{
    [ExtendObjectType("Mutation")]
    public class ProductMutation
    {
        public async Task<Product> AddProductAsync(AddProductInput input, [Service] IProduct productService)
        {
            var product = new Product
            {
               Name = input.Name,
               Price = input.Price,
               OrderId = (int)input.OrderId,
            };

            await productService.AddProduct(product);

            return product;
        }
    }
}
