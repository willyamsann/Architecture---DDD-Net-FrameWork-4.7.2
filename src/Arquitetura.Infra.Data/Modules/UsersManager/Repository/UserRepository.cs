using Dapper;
using Arquitetura.Domain.Modules.UsersManager.Interfaces.Repositories;
using Arquitetura.Domain.Modules.UsersManager.Models;
using Arquitetura.Infra.Data.Modules.Common.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Arquitetura.Infra.Data.Modules.UsersManager.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public User GetById(string id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<User> GetUsersBySpecificPermission(string claimType, string claimValue)
        {
            var sql = @"SELECT * FROM AspNetUsers WHERE Id IN 
                        (SELECT UserId
                           FROM AspNetUserClaims
                          WHERE ClaimType = @pClaimType
                            AND CHARINDEX(@pClaimValue, ClaimValue) > 0)";

            var users = Db.Database.Connection.Query<User>(sql, 
                new { pClaimType = claimType, pClaimValue = claimValue });

            return users;
        }

        public bool UserHaveSpecificPermission(string id, string claimType, string claimValue)
        {
            var sql = "SELECT 1 FROM AspNetUserClaims WHERE UserId = @pId AND ClaimType = @pClaimType And CHARINDEX(@pClaimValue, ClaimValue) > 0 ";

            var claimValues = Db.Database.Connection.Query<string>(sql,
                new { pId = id.ToString(), pClaimType = claimType, pClaimValue = claimValue });

            return claimValues != null && claimValues.Count() > 0;
        }
    }
}
