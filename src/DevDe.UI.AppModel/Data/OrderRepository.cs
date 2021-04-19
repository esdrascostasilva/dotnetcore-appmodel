using DevDe.UI.AppModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevDe.UI.AppModel.Data
{
    public class OrderRepository : IOrderRepository
    {
        public Order GetOrder()
        {
            return new Order();
        }
    }

    public interface IOrderRepository
    {
        Order GetOrder();
    }
}
