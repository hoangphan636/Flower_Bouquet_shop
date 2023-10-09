
using BussinessObject;
using BussinessObject.DataAccess;
using System.Collections.Generic;

namespace ProjectManagementAPI.Controllers
{
    public class FlowerBouquetFull
    {

        public FlowerBouquet FlowerBouquet { get; set; }
        public List<Supplier> Supplier { get; set; }

        public List<Category> Category { get; set; }

    }
}