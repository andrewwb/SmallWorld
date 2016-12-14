using SmallWorld.Infrastructure;
using SmallWorld.Models;
using SmallWorld.ViewModels.Item;
using SmallWorld.ViewModels.Warehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallWorld.Services
{
    public class ItemService
    {
        private ItemRepository _itemRepo;
        private WarehouseItemRepository _warehouseItemRepo;

        public ItemService(ItemRepository itemRepo, WarehouseItemRepository warehouseItemRepo) {
            _itemRepo = itemRepo;
            _warehouseItemRepo = warehouseItemRepo;
        }

        public IEnumerable<ItemDTO> GetAllItems(string username) {

            var userWarehouses = _itemRepo.FindUserWarehouses(username);
            var items = (from uw in userWarehouses
                              from ui in uw.WarehouseItems
                              select new ItemDTO {
                                  Id = ui.Item.Id,
                                  Name = ui.Item.Name,
                                  ImageUrl = ui.Item.ImageUrl
                              }).ToList();
            return items;
        }

        public IEnumerable<ItemDTO> GetItemsByWarehouse(string username, int id) {
            var items = (from i in _itemRepo.List()
                         from wi in i.WarehouseItems
                         where wi.WarehouseId == id
                         select new ItemDTO {
                             Id = wi.Item.Id,
                             Name = wi.Item.Name,
                             ImageUrl = wi.Item.ImageUrl
                         }).ToList();
            return items;
        }

        public void PostNewItem(ItemDTO item, string username, int warehouseId) {
            if(item.Id == 0) {
                // NEW ITEM
                Item newItem = new Item {
                    Name = item.Name,
                    ImageUrl = item.ImageUrl
                };
                _itemRepo.Add(newItem);
                _itemRepo.SaveChanges();

                WarehouseItem wi = new WarehouseItem {
                    ItemId = newItem.Id,
                    WarehouseId = warehouseId,
                    Quantity = item.WarehouseQty
                };
                _warehouseItemRepo.Add(wi);
                _warehouseItemRepo.SaveChanges();
            }
        }
    }
}
