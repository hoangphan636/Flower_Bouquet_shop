
using BussinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IOrderDetailRepository
    {
        List<OrderDetail> GetOrderDetail();
        List<OrderDetail> FindFlowerBouquetById(int id);
        void UpdateOrder(OrderDetail Order);
        void DeleteOrder(OrderDetail Order);

        OrderDetail FindFlowerBouquetByIds(int id, int OrderID);




    }
}
