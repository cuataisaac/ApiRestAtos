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
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        private readonly ApplicationDbContext _db;

        public ProfileRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetAll()
        {
            return _db.profile.Select(i => new SelectListItem()
            {
                Text = i.ProfileName,
                Value = i.Id.ToString()
            });
        }

        public void Uptate(Profile profile)
        {
            var objDesdeDb = _db.profile.FirstOrDefault(s => s.Id == profile.Id);
            objDesdeDb.ProfileName = profile.ProfileName;
            _db.SaveChanges();
        }
    }
}
