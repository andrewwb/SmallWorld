using SmallWorld.Data;
using SmallWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallWorld.Infrastructure
{
    public class WarehouseRepository : GenericRepository<Warehouse>
    {
        public WarehouseRepository(ApplicationDbContext db) : base(db) { }

        public IQueryable<Warehouse> GetWarehouseById(int id) {
            return (from w in _db.Warehouses where w.Id == id select w);
        }
    }
}
