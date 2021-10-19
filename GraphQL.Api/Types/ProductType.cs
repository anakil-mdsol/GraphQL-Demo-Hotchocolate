using GraphQL.Interfaces;
using GraphQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQlApi.GraphQl.Types
{
    public class ProductType : ObjectType<Product>
    {
        protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
        {
            descriptor.Description("Graphql : Product Type");

            descriptor
                .Field(o => o.Order)
                .ResolveWith<Resolvers>(o => o.GetOrderById(default!, default!))
                .Description("Order details associated with Product");
        }

        private class Resolvers
        {
            public Order GetOrderById([Parent] Product product, [Service] IOrder orderService)
            {
                return orderService.GetOrderById(product.OrderId);
            }
        }
    }
}