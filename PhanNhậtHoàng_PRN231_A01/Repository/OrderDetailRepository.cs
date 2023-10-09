
using BussinessObject.DataAccess;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void DeleteOrder(OrderDetail Order) => OrderDetailDAO.DeleteOrder(Order);


        public List<OrderDetail> FindFlowerBouquetById(int id) => OrderDetailDAO.FindFlowerBouquetById(id);

        public OrderDetail FindFlowerBouquetByIds(int id, int OrderID) => OrderDetailDAO.FindFlowerBouquetByIds(id, OrderID);


        public List<OrderDetail> GetOrderDetail() => OrderDetailDAO.GetOrderDetail();

        public void UpdateOrder(OrderDetail Order) => OrderDetailDAO.UpdateOrder(Order);

    }
}
