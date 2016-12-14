using Microsoft.AspNetCore.Mvc;
using SmallWorld.Infrastructure;
using SmallWorld.Models;
using SmallWorld.ViewModels.Employee;
using SmallWorld.ViewModels.Item;
using SmallWorld.ViewModels.Warehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallWorld.Services {
    public class WarehouseService {
        private WarehouseRepository _warehouseRepo;
        private EmployeeItemRepository _employeeItemRepo;

        public WarehouseService(WarehouseRepository warehouseRepo, EmployeeItemRepository employeeItemRepo) {
            _warehouseRepo = warehouseRepo;
            _employeeItemRepo = employeeItemRepo;
        }

        public IList<Warehouse> GetWarehouses(string username) {
            //var user = (from u in _repo.Users() where u.UserName == username
            //              select u).FirstOrDefault();

            return (from w in _warehouseRepo.List() where w.Admin.UserName == username select w).ToList();
        }

        public WarehouseDTO GetWarehouseById(int id) {
            WarehouseDTO after = (from w in _warehouseRepo.GetWarehouseById(id)
                                  select new WarehouseDTO {
                                      Id = w.Id,
                                      Name = w.Name,
                                      Items = (from wi in w.WarehouseItems
                                               select new ItemDTO {
                                                   Id = wi.Item.Id,
                                                   Name = wi.Item.Name,
                                                   WarehouseQty = (wi.Quantity - ((int?)wi.Item.EmployeeItems.Sum(ei => ei.Quantity) ?? 0)),
                                                   ImageUrl = wi.Item.ImageUrl
                                               }).ToList()
                                  }).FirstOrDefault();

            return after;
        }

        public void AddEditWarehouse(WarehouseDTO warehouse, string username, int id = 0) {
            if (id == 0) {
                // ADD
                Warehouse newWarehouse = new Warehouse {
                    Name = warehouse.Name,
                    AdminId = _warehouseRepo.FindUserByUsername(username).Id,
                };

                _warehouseRepo.Add(newWarehouse);
                _warehouseRepo.SaveChanges();
            }
            else {
                // EDIT

            }
        }

        public void CheckoutItem(int employeeId, int itemId, int qty) {
            var exists = (from e in _employeeItemRepo.List() where e.EmployeeId == employeeId && e.ItemId == itemId select e).FirstOrDefault();
            if (exists == null) {
                var ei = new EmployeeItem {
                    EmployeeId = employeeId,
                    ItemId = itemId,
                    Quantity = qty
                };

                _employeeItemRepo.Add(ei);
                _employeeItemRepo.SaveChanges();
            }
            else {
                exists.Quantity += qty;
                _employeeItemRepo.SaveChanges();
            }
        }

        public void CheckInItem(int employeeId, int itemId, int quantity) {
            var item = (from i in _employeeItemRepo.List() where i.EmployeeId == employeeId && i.ItemId == itemId select i).FirstOrDefault();
            item.Quantity -= quantity;
            _employeeItemRepo.SaveChanges();
        }
    }
}
