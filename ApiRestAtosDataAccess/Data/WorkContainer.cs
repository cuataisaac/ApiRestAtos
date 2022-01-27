using ApiRestAtosDataAccess.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestAtosDataAccess.Data
{
    public class WorkContainer : IWorkContainer
    {
        private readonly ApplicationDbContext _db;
        public WorkContainer(ApplicationDbContext db)
        {
            _db = db;
            Profile = new ProfileRepository(_db);
            User = new UserRepository(_db);
        }
        public IProfileRepository Profile { get; private set; }
        public IUserRepository User { get; private set; }
        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
