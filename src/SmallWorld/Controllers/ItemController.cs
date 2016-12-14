using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SmallWorld.ViewModels.Item;
using SmallWorld.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SmallWorld.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private ItemService _service;
        public ItemController(ItemService service) {
            _service = service;
        }
        // GET: api/values
        [Authorize]
        [HttpGet]
        public IEnumerable<ItemDTO> Get()
        {
            return _service.GetAllItems(User.Identity.Name);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<ItemDTO> Get(int id)
        {
            return _service.GetItemsByWarehouse(User.Identity.Name, id);
        }

        // POST api/values
        [Authorize]
        [HttpPost("{id}")]
        public void Post([FromBody]ItemDTO item, int id)
        {
            _service.PostNewItem(item, User.Identity.Name, id);
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
