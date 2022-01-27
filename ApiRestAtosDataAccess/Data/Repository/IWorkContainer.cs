using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestAtosDataAccess.Data.Repository
{
    public interface IWorkContainer : IDisposable
    {
        IProfileRepository Profile { get; }
        IUserRepository User { get; }
        void Save();
    }
}
