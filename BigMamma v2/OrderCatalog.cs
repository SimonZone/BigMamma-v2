using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigMamma_v2
{
    public class OrderCatalog
    {
        Dictionary<int, Order> orders;

        public OrderCatalog()
        {
            orders = new Dictionary<int, Order>();
        }

        #region properties

        #endregion

        #region Methods
        public void CreateOrder(Order order)
        {
            orders.Add(order.OrderID, order);
        }

        public Order ReadOrder(int orderID)
        {
            return orders[orderID];
        }

        public void UpdateOrder(Order order, bool deliveryStatus)
        {
            order.Devilery = deliveryStatus;
        }

        public void DeleteOrder(Order order)
        {
            orders.Remove(order.OrderID);
        }

        public void SearchOrder(Order order)
        {
            var key = order.OrderID;
            var value = order.Devilery;
            Console.WriteLine("ID. {0} Devilery: {1}", key, value);
        }

        public int OrderCount()
        {
            int OC = orders.Count();
            return OC;
        }
        #endregion
    }
}
