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
            int indexToRemove = -1; // -1 means no product found
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].Id == productId)
                {
                    indexToRemove = i;
                    break;
                }
            }

            if (indexToRemove != -1)
            {
                Product[] newProducts = new Product[products.Length - 1];
                for (int i = 0, j = 0; i < products.Length; i++)
                {
                    if (i != indexToRemove)
                    {
                        newProducts[j++] = products[i];
                    }
                }
                products = newProducts; // put the updated array to the main product array
            }
        }

        public Product FindProductById(int productId)
        {
            foreach (Product product in products)
            {
                if (product.Id == productId)
                {
                    return product;
                }
            }
            return null; // return null if no product with the given id is found
        }

        public Product[] GetAllProducts()
        {
            return products;
        }
    }
}
