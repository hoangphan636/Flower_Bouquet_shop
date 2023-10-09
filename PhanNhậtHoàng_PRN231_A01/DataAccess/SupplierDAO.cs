
using BussinessObject;
using BussinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SupplierDAO
    {
        public static List<Supplier> GetSupplier()
        {
            var list = new List<Supplier>();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    list = context.Suppliers.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
    }
}
