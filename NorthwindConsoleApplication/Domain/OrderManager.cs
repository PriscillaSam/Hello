using NorthwindConsoleApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindConsoleApplication.Domain
{
    class OrderManager
    {
         private NORTHWNDEntities dbContext;
        
        public OrderManager()
        {
            dbContext = new NORTHWNDEntities();
        }

        ///METHODS
        public Order GetOrderById(int orderId)
        {
            var order = dbContext.Orders.Find(orderId);
            return order;
        }
    }
}
