using System;

namespace online_marketplace
{
    // I made this an abstract because it is not made to be instantiated on its own. Will only serve as base class for cart and order.
    public abstract class Transaction
    {
        public Product[] Products { get; protected set; }
        public User Owner { get; protected set; }

        protected Transaction(User owner)
        {
            Owner = owner;
            Products = new Product[0];
        }

        public void AddProduct(Product product)
        {
            var tempList = new Product[Products.Length + 1]; // create a new array with a bigger size to contain the new product    
            for (int i = 0; i < Products.Length; i++) // loop through the products array
            {
                tempList[i] = Products[i];
            }
            tempList[Products.Length] = product; // add the new product to the end of the new array
            Products = tempList; // set the new array as the transaction's product array
        }

        public void RemoveProduct(Product product)
        {
            int indexToRemove = Array.IndexOf(Products, product);
            if (indexToRemove < 0) return; // Product not found

            var tempList = new Product[Products.Length - 1];
            for (int i = 0, j = 0; i < Products.Length; i++)
            {
                if (i == indexToRemove) continue;
                tempList[j++] = Products[i];
            }
            Products = tempList; // set the new array as the transaction's product array
        }

        public decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0;
            foreach (var product in Products)
            {
                totalPrice += product.Price;
            }
            return totalPrice;
        }

        public void Clear()
        {
            Products = new Product[0];
        }
    }
}
