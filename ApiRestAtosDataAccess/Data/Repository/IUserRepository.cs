using ApiRestAtosModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ApiRestAtosDataAccess.Data.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<SelectListItem> GetAll();
        void Uptate(User user);
    }
}
