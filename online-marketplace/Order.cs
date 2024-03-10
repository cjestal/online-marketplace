using System;
using System.Collections.Generic;

namespace online_marketplace
{
    // Order represents a finalized transaction, distinct from a modifiable Cart.
    public class Order : Transaction
    {
        public int OrderId { get; set; } // for historical purposes.
        public DateTime OrderDate { get; set; } // for historical purposes.

        // Initializes the Order class with new attributes while also calling
        // the parent class's constructor, Transaction.
        public Order(int orderId, User owner) : base(owner)
        {
            OrderId = orderId;
            OrderDate = DateTime.Now;
        }
    }
}
