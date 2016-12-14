using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallWorld.ViewModels.Item
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WarehouseQty { get; set; }
        public string ImageUrl { get; set; }
    }
}
