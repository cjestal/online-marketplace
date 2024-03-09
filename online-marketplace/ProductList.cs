using System;
using System.Linq;

namespace online_marketplace
{
    // This class is for managing the list of products.
    public class ProductList
    {
        private Product[] products;

        public ProductList()
        {
            products = new Product[0];
        }

        public void AddProduct(Product product)
        {
            Array.Resize(ref products, products.Length + 1);
            products[products.Length - 1] = product;
        }

        public void RemoveProduct(int productId)
        {
            products = products.Where(p => p.Id != productId).ToArray();
        }

        public Product FindProductById(int productId)
        {
            return products.FirstOrDefault(p => p.Id == productId);
        }

        public Product[] GetAllProducts()
        {
            return products;
        }
    }
}
