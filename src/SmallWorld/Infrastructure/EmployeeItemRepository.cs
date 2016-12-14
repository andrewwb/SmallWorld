using SmallWorld.Data;
using SmallWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallWorld.Infrastructure
{
    public class EmployeeItemRepository : GenericRepository<EmployeeItem>
    {
        public EmployeeItemRepository(ApplicationDbContext db) : base(db) { }
    }
}
