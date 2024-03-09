using System;

namespace online_marketplace
{
    public class Cart
    {
        public Product[] Products { get; private set; }
        public User CartOwner { get; private set; }

        public Cart(User cartOwner)
        {
            CartOwner = cartOwner;
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
            Products = tempList; // set the new array as the cart's product array
        }

        // remove product from cart. use its index relative to its position in the product array
        public void RemoveProduct(Product product)
        {
            int indexToRemove = Array.IndexOf(Products, product);
            if (indexToRemove < 0) return; // Product not found

            // loop through the products array to find the index to be removed
            var tempList = new Product[Products.Length - 1];
            for (int i = 0, j = 0; i < Products.Length; i++)
            {
                if (i == indexToRemove) continue;
                tempList[j++] = Products[i];
            }
            Products = tempList; // set the new array as the cart's product array
        }

        // a simple loop to add up the price of all products in the cart
        public decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0;
            foreach (var product in Products)
            {
                totalPrice += product.Price;
            }
            return totalPrice;
        }

        public void ClearCart()
        {
            Products = new Product[0];
        }

        // This method has been updated to be an instance method instead of a static method.
        // It now correctly accesses the Products property of the instance it is called on.
        public void ViewCart()
        {
            Console.WriteLine("Viewing cart contents:");
            if (this.Products.Length == 0)
            {
                Console.WriteLine("Your cart is empty.");
            }
            else
            {
                foreach (var product in this.Products)
                {
                    Console.WriteLine($"Name: {product.Name}, Price: {product.Price}");
                }
                Console.WriteLine($"Total Price: {this.CalculateTotalPrice()}");
            }
        }
    }
}
