using GraphQL.Interfaces;
using GraphQL.Models;
using HotChocolate;
using HotChocolate.Types;
using System.Collections.Generic;

namespace GraphQlApi.GraphQl.Types
{
    public class OrderType : ObjectType<Order>
    {
        protected override void Configure(IObjectTypeDescriptor<Order> descriptor)
        {

            descriptor.Description("Graphql : Order Type");

            descriptor
                .Field(o => o.Products)
                .ResolveWith<Resolvers>(o => o.GetProductByOderId(default!, default!))
                .Description("This is the list of all ordered products");
        }

        private class Resolvers
        {
            public IEnumerable<Product> GetProductByOderId([Parent] Order order, [Service] IProduct prouctService)
            {
                return prouctService.GetProductByOderId(order.Id);
            }
        }
    }
}