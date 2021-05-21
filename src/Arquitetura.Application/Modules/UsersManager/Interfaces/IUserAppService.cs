using Arquitetura.Application.Modules.UsersManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitetura.Application.Modules.UsersManager.Interfaces
{
    public interface IUserAppService
    {
        UserViewModel GetById(string id);

        IEnumerable<UserViewModel> GetAll();

        IEnumerable<UserViewModel> GetAllPaged(int skip, int take);

        IEnumerable<UserViewModel> GetUsersBySpecificPermission(string claimType, string claimValue);

        void Dispose();
    }
}
