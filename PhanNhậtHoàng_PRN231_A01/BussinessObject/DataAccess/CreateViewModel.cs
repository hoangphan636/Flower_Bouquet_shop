using BussinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CreateViewModel
    {
        public FlowerBouquet FlowerBouquet { get; set; }
        public Order Order { get; set; }
        public OrderDetail OrderDetail { get; set; }
    }
}
