using ApiRestAtosDataAccess.Data.Repository;
using ApiRestAtosModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ApiRestAtosDataAccess.Data
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetAll()
        {
            return _db.user.Select(i => new SelectListItem()
            {
                Text = i.UserName,
                Value = i.IdUser.ToString()
            });
        }
        public void Uptate(User user)
        {
            var objDesdeDb = _db.user.FirstOrDefault(s => s.IdUser == user.IdUser);
            objDesdeDb.UserName = user.UserName;
            objDesdeDb.Status = user.Status;
            objDesdeDb.employeeId = user.employeeId;
            objDesdeDb.Password = user.Password;
            objDesdeDb.UpdatedDate = DateTime.Now;

            _db.SaveChanges();
        }
    }
}
