
using BussinessObject;
using BussinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO
    {
        CustomerDAO cus = new CustomerDAO();
        public static List<Order> GetOrder()
        {
            var list = new List<Order>();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    list = context.Orders.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static int FindOrderMaxId()
        {
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    int maxId = context.Orders.Max(customer => customer.OrderId.Value);
                    return maxId;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static void SaveOrder(Order Order)
        {

            try
            {
                using var context = new FUFlowerBouquetManagementContext();

                context.Orders.Add(Order);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


      

        public static Order FindOrderById(int id)
        {
            var list = new Order();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    list = context.Orders.FirstOrDefault(x => x.OrderId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }


        public static List<Order> FindOrderCustomerByEmail(int id)
        {
            
            var list = new List<Order>();
           
            try
            {
                
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    list = context.Orders.Where(x => x.CustomerId == id).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }



        public static void UpdateOrder(Order Order)
        {

            try
            {
                using var context = new FUFlowerBouquetManagementContext();

                context.Orders.Update(Order);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static void DeleteOrder(Order Order)
        {

            try
            {
                using var context = new FUFlowerBouquetManagementContext();

                context.Orders.Remove(Order);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }





    }
}
