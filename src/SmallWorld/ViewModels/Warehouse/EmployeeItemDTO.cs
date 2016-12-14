using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallWorld.ViewModels.Warehouse
{
    public class EmployeeItemDTO
    {
        public int EmployeeId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
