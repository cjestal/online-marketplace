using System;
using System.Linq;

namespace online_marketplace
{
    public class OrderList
    {
        private Order[] orders;

        public OrderList()
        {
            orders = new Order[0];
        }

        public void AddOrder(Order order)
        {
            Array.Resize(ref orders, orders.Length + 1);
            orders[orders.Length - 1] = order;
        }

        public Order FindOrderById(int orderId)
        {
            return orders.FirstOrDefault(o => o.OrderId == orderId);
        }

        public Order[] GetAllOrders()
        {
            return orders;
        }
    }
}
