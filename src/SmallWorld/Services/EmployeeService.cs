using SmallWorld.Infrastructure;
using SmallWorld.Models;
using SmallWorld.ViewModels.Employee;
using SmallWorld.ViewModels.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallWorld.Services
{
    public class EmployeeService
    {
        private EmployeeRepository _repo;

        public EmployeeService(EmployeeRepository repo) {
            _repo = repo;
        }

        public IEnumerable<EmployeeDTO> GetEmployees(string username) {
            
            //GET ALL EMPLOYEES THAT BELONG TO CURRENT USER
            IQueryable<Employee> employees = (from e in _repo.List()
                                              where e.Admin.UserName == username
                                               select e);

            //CONVERT EMPLOYEES TO EMPLOYEEDTOs
            IEnumerable<EmployeeDTO> dto = (from e in employees
                       select new EmployeeDTO {
                           Id = e.Id,
                           FirstName = e.FirstName,
                           LastName = e.LastName,
                           Items = e.EmployeeItems.Select(ei => new ItemDTO {
                               Id = ei.Item.Id,
                               Name = ei.Item.Name,
                               ImageUrl = ei.Item.ImageUrl
                           }).ToList()
                       }).ToList();
            return dto;
        }
    }
}
