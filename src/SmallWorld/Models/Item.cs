using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallWorld.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<EmployeeItem> EmployeeItems { get; set; }
        public ICollection<WarehouseItem> WarehouseItems { get; set; }
    }
}
