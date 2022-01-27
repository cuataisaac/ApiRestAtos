using ApiRestAtosModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ApiRestAtosDataAccess.Data.Repository
{
    public interface IProfileRepository : IRepository<Profile>
    {
        IEnumerable<SelectListItem> GetAll();
        void Uptate(Profile profile);
    }
}
