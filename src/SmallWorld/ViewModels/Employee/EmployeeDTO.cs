using SmallWorld.Models;
using SmallWorld.ViewModels.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallWorld.ViewModels.Employee
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<ItemDTO> Items { get; set; }
    }
}
