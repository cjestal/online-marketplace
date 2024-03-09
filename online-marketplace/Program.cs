using online_marketplace;
using System;

internal class MarketplaceProgram
{
    private static ProductList productList = new ProductList(); // Refactored to use ProductList class
    private static Cart cart = new Cart(new User("defaultUser", "user@example.com")); // hardcoded user.
    private static int orderId = 1; // Initialize order ID
    private static OrderList orderList = new OrderList(); // Added to manage orders

    public static void Main(string[] args)
    {
        productList = new ProductList(); // Initialize the ProductList
        foreach (var product in GenerateDummyProducts()) // Populate the ProductList with dummy products
        {
            productList.AddProduct(product);
        }

        bool running = true;
        while (running)
        {
            Console.WriteLine("Welcome to the Marketplace!");
            Console.WriteLine("1. Create a Product");
            Console.WriteLine("2. List all Products");
            Console.WriteLine("3. Add Product to Cart");
            Console.WriteLine("4. View Cart");
            Console.WriteLine("5. Checkout");
            Console.WriteLine("6. View Orders");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateProduct();
                    break;
                case "2":
                    ListProducts();
                    break;
                case "3":
                    AddProductToCart();
                    break;
                case "4":
                    cart.ViewCart();
                    break;
                case "5":
                    Checkout();
                    break;
                case "6":
                    ViewOrders();
                    break;
                case "7":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }

    private static void ViewOrders()
    {
        Console.WriteLine("Viewing all orders:");
        var allOrders = orderList.GetAllOrders();
        if (allOrders.Length == 0)
        {
            Console.WriteLine("No orders found.");
            return;
        }
        foreach (var order in allOrders)
        {
            Console.WriteLine($"Order ID: {order.OrderId}, Order Date: {order.OrderDate}, Ordered By: {order.OrderedBy.Username}");
        }
    }

    private static void AddProductToCart()
    {
        ListProducts(); // Show the list of products for user to choose from
        Console.Write("Enter the index of the product you want to add to the cart: ");
        int productIndex = Convert.ToInt32(Console.ReadLine()) - 1; // Adjusting for zero-based index
        var allProducts = productList.GetAllProducts();
        if (productIndex >= 0 && productIndex < allProducts.Length)
        {
            var selectedProduct = allProducts[productIndex];
            if (selectedProduct.Quantity > 0)
            {
                cart.AddProduct(selectedProduct);
                Console.WriteLine($"{selectedProduct.Name} added to cart successfully!");
            }
            else
            {
                Console.WriteLine("This product is out of stock.");
            }
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    private static void CreateProduct()
    {
        Console.Write("Enter product name: ");
        string name = Console.ReadLine();
        Console.Write("Enter product price: ");
        decimal price = Convert.ToDecimal(Console.ReadLine());
        Console.Write("Enter product quantity: ");
        int quantity = Convert.ToInt32(Console.ReadLine());

        Product product = new Product(name, price, quantity);
        productList.AddProduct(product);
        Console.WriteLine("Product created successfully!");
    }

    private static void ListProducts()
    {
        Console.WriteLine("Listing all products:");
        var allProducts = productList.GetAllProducts();
        for (int i = 0; i < allProducts.Length; i++)
        {
            Console.WriteLine($"{i + 1}: Name: {allProducts[i].Name}, Price: {allProducts[i].Price}, Quantity: {allProducts[i].Quantity}");
        }
    }

    private static void Checkout()
    {
        if (cart.Products.Length == 0)
        {
            Console.WriteLine("Your cart is empty. Add some products before checking out.");
            return;
        }
        Order newOrder = new Order(orderId++, cart.CartOwner, cart.CartOwner);
        foreach (var product in cart.Products)
        {
            // Update the quantity of each product in the main products array
            var originalProduct = productList.FindProductById(product.Id);
            if (originalProduct != null && originalProduct.Quantity >= 1)
            {
                originalProduct.Quantity -= 1; // Assuming each product added to the cart is a single unit
                newOrder.AddProduct(product);
            }
            else
            {
                Console.WriteLine($"Not enough stock for {product.Name}. Skipping item.");
            }
        }
        cart.ClearCart(); // clear the cart to start over
        orderList.AddOrder(newOrder); // Add the completed order to the order list
        Console.WriteLine($"Checkout successful. Order ID: {newOrder.OrderId}, Total Price: {newOrder.CalculateTotalPrice()}");
    }

    // This method is used to generate dummy products for testing purposes.
    private static Product[] GenerateDummyProducts()
    {
        return new Product[]
        {
            new Product("Laptop", 1200.00m, 2),
            new Product("Smartphone", 800.00m, 5),
            new Product("Tablet", 600.00m, 20),
            new Product("Headphones", 150.00m, 3),
            new Product("Smartwatch", 250.00m, 2),
            new Product("Keyboard", 100.00m, 5),
        };
    }
}
