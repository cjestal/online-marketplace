using System;

namespace online_marketplace
{
    public class Cart : Transaction
    {
        // when this constructor is called, it will instead call the base constructor
        public Cart(User cartOwner) : base(cartOwner) { }

        public void ViewCart()
        {
            Console.WriteLine("Viewing cart contents:");
            if (this.Products.Length == 0)
            {
                Console.WriteLine("Your cart is empty.");
                Console.WriteLine(""); // added line for readability
            }
            else
            {
                foreach (var product in this.Products)
                {
                    Console.WriteLine($"Name: {product.Name}, Price: {product.Price}");
                }
                Console.WriteLine($"Total Price: {this.CalculateTotalPrice()}");
            }
            Console.WriteLine("");
        }
    }
}
