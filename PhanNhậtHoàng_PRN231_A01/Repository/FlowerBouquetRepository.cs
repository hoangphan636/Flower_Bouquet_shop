
using BussinessObject.DataAccess;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class FlowerBouquetRepository : IFlowerBouquet
    {
        public void DeleteFlowerBouquet(FlowerBouquet FlowerBouquet) => FlowerBouquetDAO.DeleteFlowerBouquet(FlowerBouquet);



        public FlowerBouquet FindFlowerBouquetById(int id) => FlowerBouquetDAO.FindFlowerBouquetById(id);

        public int FindFlowerBouquetMaxId() => FlowerBouquetDAO.FindFlowerBouquetMaxId();


        public List<FlowerBouquet> GetFlowerBouquet() => FlowerBouquetDAO.GetFlowerBouquet();
       

        public void SaveFlowerBouquet(FlowerBouquet FlowerBouquet) => FlowerBouquetDAO.SaveFlowerBouquet(FlowerBouquet);


        public void UpdateFlowerBouquet(FlowerBouquet FlowerBouquet) => FlowerBouquetDAO.UpdateFlowerBouquet(FlowerBouquet);

        public void UpdateFlowerBouquetStatus(int id) => FlowerBouquetDAO.UpdateFlowerBouquetStatus(id);

    }
}
