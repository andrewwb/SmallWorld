using SmallWorld.Data;
using SmallWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallWorld.Infrastructure
{
    public class GenericRepository<T> : IDisposable where T : class
    {
        protected ApplicationDbContext _db;
        public GenericRepository(ApplicationDbContext db) {
            _db = db;
        }

        public IQueryable<ApplicationUser> Users() {
            return _db.Users;
        }

        public ApplicationUser FindUserByUsername(string username) {
            return (from u in _db.Users where u.UserName == username select u).FirstOrDefault();
        }

        public IQueryable<Warehouse> FindUserWarehouses(string username) {
            return (from w in _db.Warehouses
                    where w.Admin.UserName == username
                    select w);
        }

        public IQueryable<T> List() {
            return _db.Set<T>();
        }

        public void Add(T entity) {
            _db.Set<T>().Add(entity);
        }

        public void Delete(T entity) {
            _db.Set<T>().Remove(entity);
        }

        public void SaveChanges() {
            _db.SaveChanges();
        }

        public void Dispose() {
            _db.Dispose();
        }
    }
}
