
using BussinessObject;
using BussinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FlowerBouquetDAO
    {
        public static List<FlowerBouquet> GetFlowerBouquet()
        {
            var list = new List<FlowerBouquet>();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    list = context.FlowerBouquets.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }


        public static int FindFlowerBouquetMaxId()
        {
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    int maxId = context.FlowerBouquets.Max(customer => customer.FlowerBouquetId.Value);
                    return maxId;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }





        public static void SaveFlowerBouquet(FlowerBouquet FlowerBouquet)
        {

            try
            {
                using var context = new FUFlowerBouquetManagementContext();

                context.FlowerBouquets.Add(FlowerBouquet);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


      

        public static FlowerBouquet FindFlowerBouquetById(int id)
        {
            var list = new FlowerBouquet();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    list = context.FlowerBouquets.FirstOrDefault(x => x.FlowerBouquetId == id);
                   
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static void UpdateFlowerBouquet(FlowerBouquet FlowerBouquet)
        {

            try
            {
                using var context = new FUFlowerBouquetManagementContext();

                context.FlowerBouquets.Update(FlowerBouquet);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static void UpdateFlowerBouquetStatus(int id)
        {
            
            try
            {
                using var context = new FUFlowerBouquetManagementContext();
                var statusobject = FindFlowerBouquetById(id);
                statusobject.FlowerBouquetStatus = 0;
                context.FlowerBouquets.Update(statusobject);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static void DeleteFlowerBouquet(FlowerBouquet FlowerBouquet)
        {

            try
            {
                if (FlowerBouquet.FlowerBouquetStatus!= 0)
                {
                    using var context = new FUFlowerBouquetManagementContext();

                    context.FlowerBouquets.Remove(FlowerBouquet);
                    context.SaveChanges();
                }
              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }












    }
}
