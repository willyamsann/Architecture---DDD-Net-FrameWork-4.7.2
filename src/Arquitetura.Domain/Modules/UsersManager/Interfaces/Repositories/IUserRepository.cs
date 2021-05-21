using Arquitetura.Domain.Common.Interfaces.Repositories;
using Arquitetura.Domain.Modules.UsersManager.Models;
using System.Collections.Generic;

namespace Arquitetura.Domain.Modules.UsersManager.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetById(string id);

        IEnumerable<User> GetUsersBySpecificPermission(string claimType, string claimValue);

        bool UserHaveSpecificPermission(string id, string claimType, string claimValue);
    }
}
