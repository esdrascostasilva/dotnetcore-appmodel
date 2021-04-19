using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevDe.UI.AppModel.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public Order()
        {
            Id = Guid.NewGuid();
        }
    }
}
