using GraphQL.Interfaces;
using GraphQL.Models;
using HotChocolate;
using HotChocolate.Types;
using System.Collections.Generic;

namespace GraphQlApi.GraphQl.Queries
{
    [ExtendObjectType("Query")]
    public class ProductQuery
    {
        public IEnumerable<Product> GetAllProducts([Service] IProduct prouctService)
        {
            return prouctService.GetAllProducts();
        }
        public Product GetProduct([Service] IProduct prouctService, int id)
        {
            return prouctService.GetProductById(id);
        }
    }
}
