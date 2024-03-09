using System;
namespace online_marketplace
{
	// This class is for managing a single product
	public class Product
	{
		public int Id { get; private set; } // this is a read-only property and auto generated upon instantiation.
		public string Name { get; set; } 
		public decimal Price { get; set; } // is used for calculating totals
		public int Quantity { get; set; } // for inventory purposes

		// using this constructor, we can immediately define a product with all its properties including quantity.
		public Product(string name, decimal price, int quantity)
		{
			Id = new Random().Next(1, 1000000); // Id is generated randomly.
			Name = name;
			Price = price;
			Quantity = quantity; // Initialize quantity
		}


		// updates a product. name, price, and quantity can be updated for data integrity.
		public void UpdateProduct(string newName, decimal newPrice, int newQuantity)
		{
			Name = newName;
			Price = newPrice;
			Quantity = newQuantity; // Update quantity
		}

	}
}

