using System;
using Microsoft.AspNet.Identity.EntityFramework;
using Arquitetura.Infra.Crosscuting.Identity.Model;

namespace Arquitetura.Infra.Crosscuting.Identity.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDisposable
    {
        public ApplicationDbContext() 
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
