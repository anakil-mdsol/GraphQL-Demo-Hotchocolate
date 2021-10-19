using GraphQL;
using GraphQL.Data;
using GraphQL.Interfaces;
using GraphQL.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Services
{
    /// <summary>
    /// Product Service Class
    /// </summary>
    public class ProductService : IProduct
    {

        private AppDbContext appDbContext;
        private IHttpContextAccessor accessor;
        //private IDocumentExecuter executer;

        public ProductService(AppDbContext appDbContext,
            IHttpContextAccessor accessor/*, IDocumentExecuter executer*/)
        {
            this.appDbContext = appDbContext;
            this.accessor = accessor;
            //this.executer = executer;
        }


        /// <inheritdoc cref="IProduct.AddProduct(Product)"/>
        public async Task<Product> AddProduct(Product product)
        {
            appDbContext.Products.Add(product);
            await appDbContext.SaveChangesAsync();
            return product;
        }

        /// <inheritdoc cref="IProduct.DeleteProduct(int)" />
        public void DeleteProduct(int id)
        {
            Product product = appDbContext.Products.Find(id);
            appDbContext.Products.Remove(product);

            appDbContext.SaveChanges();
        }

        /// <inheritdoc cref="IProduct.DeleteProduct(int)" />
        public List<Product> GetAllProducts()
        {
            return appDbContext.Products.ToList();
        }

        /// <inheritdoc cref="IProduct.GetProductById(int)" />
        public Product GetProductById(int id)
        {
            return appDbContext.Products.Find(id);
        }

        /// <inheritdoc cref="IProduct.UpdateProduct(int, Product)" />
        public Product UpdateProduct(int id, Product newproduct)
        {
             Product product = appDbContext.Products.Find(id);

            product.Name = newproduct.Name;
            product.Price = newproduct.Price;
            appDbContext.SaveChanges();

            return product;
        }
        /// <inheritdoc cref="IProduct.GetProductByOderId(int)" />
        public List<Product> GetProductByOderId(int id)
        {
            return appDbContext.Products.Where(o => o.OrderId ==id).ToList();
        }
    }
}
