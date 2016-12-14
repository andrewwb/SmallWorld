using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using SmallWorld.Models;

namespace SmallWorld.Data
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            // Ensure db
            context.Database.EnsureCreated();

            // Ensure Andrew (IsAdmin)
            var andrew = await userManager.FindByNameAsync("abuttram9@gmail.com");
            if (andrew == null)
            {
                // create user
                andrew = new ApplicationUser
                {
                    UserName = "abuttram9@gmail.com",
                    Email = "abuttram9@gmail.com",
                    FirstName = "Andrew",
                    LastName = "Buttram",
                                       
                };
                await userManager.CreateAsync(andrew, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(andrew, new Claim("IsAdmin", "true"));
            }
            context.SaveChanges();

            // Ensure Ryan (IsAdmin)
            var ryan = await userManager.FindByNameAsync("crandrc@gmail.com");
            if (ryan == null)
            {
                // create user
                ryan = new ApplicationUser
                {
                    UserName = "crandrc@gmail.com",
                    Email = "crandrc@gmail.com",
                    FirstName = "Ryan",
                    LastName = "Cecil"
                };
                await userManager.CreateAsync(ryan, "Secret123!");

                await userManager.AddClaimAsync(ryan, new Claim("IsAdmin", "true"));
            }
            context.SaveChanges();

            if (!context.Items.Any()) {
                context.Items.AddRange(
                    new Item { Name = "Round Point Shovel", ImageUrl = @"C:\Projects\SmallWorld\src\SmallWorld\wwwroot\images\photo_missing.png" },
                    new Item { Name = "Water Bottle", ImageUrl = @"C:\Projects\SmallWorld\src\SmallWorld\wwwroot\images\photo_missing.png" },
                    new Item { Name = "Blue Spray Paint", ImageUrl = @"C:\Projects\SmallWorld\src\SmallWorld\wwwroot\images\photo_missing.png" }
                    );
                context.SaveChanges();

                context.Employees.AddRange(
                    new Employee {
                        FirstName = "Andrew",
                        LastName = "Buttram",
                        AdminId = context.Users.FirstOrDefault(u => u.LastName == "Buttram").Id
                    },
                    new Employee {
                        FirstName = "Ryan",
                        LastName = "Cecil",
                        AdminId = context.Users.FirstOrDefault(u => u.LastName == "Cecil").Id
                    },
                    new Employee {
                        FirstName = "Jarvis",
                        LastName = "Larkin",
                        AdminId = context.Users.FirstOrDefault(u => u.LastName == "Cecil").Id
                    },
                    new Employee {
                        FirstName = "Alex",
                        LastName = "Hagel",
                        AdminId = context.Users.FirstOrDefault(u => u.LastName == "Buttram").Id
                    },
                    new Employee {
                        FirstName = "Zac",
                        LastName = "Coleman",
                        AdminId = context.Users.FirstOrDefault(u => u.LastName == "Buttram").Id
                    },
                    new Employee {
                        FirstName = "Jason",
                        LastName = "Tapia",
                        AdminId = context.Users.FirstOrDefault(u => u.LastName == "Cecil").Id
                    },
                    new Employee {
                        FirstName = "Jeremiah",
                        LastName = "Tilly",
                        AdminId = context.Users.FirstOrDefault(u => u.LastName == "Buttram").Id
                    },
                    new Employee {
                        FirstName = "James",
                        LastName = "Fairfield",
                        AdminId = context.Users.FirstOrDefault(u => u.LastName == "Cecil").Id
                    }
                    );
                context.SaveChanges();

                context.Warehouses.AddRange(
                    new Warehouse {
                        Name = "Andrew's Warehouse",
                        AdminId = context.Users.FirstOrDefault(u => u.LastName == "Buttram").Id
                    },
                    new Warehouse {
                        Name = "Ryan's Warehouse",
                        AdminId = context.Users.FirstOrDefault(u => u.LastName == "Cecil").Id
                    }
                    );
                context.SaveChanges();

                context.EmployeeItems.AddRange(
                    new EmployeeItem {
                        EmployeeId = context.Employees.FirstOrDefault(e => e.LastName == "Buttram").Id,
                        ItemId = context.Items.FirstOrDefault(i => i.Name == "Round Point Shovel").Id,
                        Quantity = 1
                    },
                    new EmployeeItem {
                        EmployeeId = context.Employees.FirstOrDefault(e => e.LastName == "Cecil").Id,
                        ItemId = context.Items.FirstOrDefault(i => i.Name == "Round Point Shovel").Id,
                        Quantity = 1
                    }
                    );
                context.SaveChanges();

                context.WarehouseItems.AddRange(
                    new WarehouseItem {
                        WarehouseId = context.Warehouses.FirstOrDefault(w => w.Name == "Andrew's Warehouse").Id,
                        ItemId = context.Items.FirstOrDefault(i => i.Name == "Round Point Shovel").Id,
                        Quantity = 10
                    },
                    new WarehouseItem {
                        WarehouseId = context.Warehouses.FirstOrDefault(w => w.Name == "Andrew's Warehouse").Id,
                        ItemId = context.Items.FirstOrDefault(i => i.Name == "Water Bottle").Id,
                        Quantity = 10
                    },
                    new WarehouseItem {
                        WarehouseId = context.Warehouses.FirstOrDefault(w => w.Name == "Ryan's Warehouse").Id,
                        ItemId = context.Items.FirstOrDefault(i => i.Name == "Round Point Shovel").Id,
                        Quantity = 5
                    },
                    new WarehouseItem {
                        WarehouseId = context.Warehouses.FirstOrDefault(w => w.Name == "Ryan's Warehouse").Id,
                        ItemId = context.Items.FirstOrDefault(i => i.Name == "Blue Spray Paint").Id,
                        Quantity = 5
                    }
                    );
                context.SaveChanges();
            }


        }

    }
}
