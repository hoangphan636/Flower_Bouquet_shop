
using BussinessObject;
using BussinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO
    {

        public static List<OrderDetail> GetOrderDetail()
        {
            var list = new List<OrderDetail>();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    list = context.OrderDetails.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static List<OrderDetail> FindFlowerBouquetById(int id)
        {
            var list = new List<OrderDetail>();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    list = context.OrderDetails.Where(x => x.FlowerBouquetId == id).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static OrderDetail FindFlowerBouquetByIds(int id, int OrderID)
        {
            var list = new OrderDetail();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    list = context.OrderDetails.FirstOrDefault(x => x.FlowerBouquetId == id && x.OrderId == OrderID);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }


        public static void UpdateOrder(OrderDetail Order)
        {

            try
            {
                using var context = new FUFlowerBouquetManagementContext();

                context.OrderDetails.Update(Order);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static void DeleteOrder(OrderDetail Order)
        {

            try
            {
                using var context = new FUFlowerBouquetManagementContext();

                context.OrderDetails.Remove(Order);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }




    }
}
