using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SmallWorld.Models;
using SmallWorld.Services;
using SmallWorld.ViewModels.Warehouse;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SmallWorld.Controllers
{
    [Route("api/[controller]")]
    public class WarehouseController : Controller
    {
        private WarehouseService _service;
        public WarehouseController(WarehouseService service) {
            _service = service;
        }

        // GET: api/values
        [Authorize]
        [HttpGet]
        public IEnumerable<Warehouse> Get()
        {
            return _service.GetWarehouses(User.Identity.Name);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public WarehouseDTO Get(int id)
        {
            return _service.GetWarehouseById(id);
        }

        // POST api/values
        [Authorize]
        [HttpPost]
        public void Post([FromBody]WarehouseDTO warehouse)
        {
            _service.AddEditWarehouse(warehouse, User.Identity.Name);
        }

        [Authorize]
        [HttpPost("checkout")]
        public void Checkout([FromBody]EmployeeItemDTO dto) {
            _service.CheckoutItem(dto.EmployeeId, dto.ItemId, dto.Quantity);
        }

        [Authorize]
        [HttpPost("checkin")]
        public void CheckIn([FromBody] EmployeeItemDTO dto) {
            _service.CheckInItem(dto.EmployeeId, dto.ItemId, dto.Quantity);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
