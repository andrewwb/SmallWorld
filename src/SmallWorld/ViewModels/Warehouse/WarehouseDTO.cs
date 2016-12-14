using SmallWorld.ViewModels.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallWorld.ViewModels.Warehouse
{
    public class WarehouseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ItemDTO> Items { get; set; }
    }
}
