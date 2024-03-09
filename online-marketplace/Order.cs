using System;
using System.Collections.Generic;

namespace online_marketplace
{
    // extending the cart class to make use of the cart's methods.
    // order is similar to cart, but in this program an order is a cart that has been checked out.
    public class Order : Cart
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public User OrderedBy { get; set; }

        public Order(int orderId, User cartOwner, User orderedBy) : base(cartOwner)
        {
            OrderId = orderId;
            OrderDate = DateTime.Now;
            OrderedBy = orderedBy;
        }
    }
}
