using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmallWorld.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string AdminId { get; set; }
        [ForeignKey("AdminId")]
        public ApplicationUser Admin { get; set; }

        public ICollection<WarehouseItem> WarehouseItems { get; set; }
    }
}
