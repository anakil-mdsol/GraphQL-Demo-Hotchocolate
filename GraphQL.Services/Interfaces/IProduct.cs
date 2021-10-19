using GraphQL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQL.Interfaces
{
    public interface IProduct
    {
        /// <summary>
        /// This will return All Product
        /// </summary>
        /// <returns>
        ///  This will return list of <see cref="Product"/> data
        /// </returns>
        List<Product> GetAllProducts();

        /// <summary>
        /// This will add new Product
        /// </summary>
        /// <param name="product"> Required : Product </param>
        /// <returns>
        ///  This will return newly created <see cref="Product"/>
        /// </returns>
        Task<Product> AddProduct(Product product);

        /// <summary>
        /// This will update existing Product
        /// </summary>
        /// <param name="product"> Required : Product </param>
        /// <param name="id">Required : id</param> 
        /// <returns>
        ///  This will update <see cref="Product"/> data
        /// </returns>
        Product UpdateProduct(int id, Product product);

        /// <summary>
        /// This will delete existing Product
        /// </summary>
        /// <param name="id">Required : id</param> 
        /// <returns>
        ///  This will delete <see cref="Product"/> data
        /// </returns>
        void DeleteProduct(int id);

        /// <summary>
        /// This will return products specific to product id supplied
        /// </summary>
        /// <param name="id">Required : product id</param> 
        /// <returns>
        ///  This will return the specified of <see cref="Product"/> data
        /// </returns>
        Product GetProductById(int id);

        /// <summary>
        /// This will return products specific to order id supplied
        /// </summary>
        /// <param name="id">Required : Order id</param> 
        /// <returns>
        ///  This will return the list of  <see cref="Product"/> data
        /// </returns>
        List<Product> GetProductByOderId(int id);
    }
}
