using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.DataHandler.Serializer;
using Microsoft.Owin.Security.DataProtection;
using Arquitetura.Application.Modules.UsersManager.Interfaces;
using Arquitetura.Application.Modules.UsersManager.Services;
using Arquitetura.Domain.Modules.UsersManager.Interfaces.Repositories;
using Arquitetura.Infra.Crosscuting.Identity.Configuration;
using Arquitetura.Infra.Crosscuting.Identity.Context;
using Arquitetura.Infra.Crosscuting.Identity.Model;
using Arquitetura.Infra.Data.Context;
using Arquitetura.Infra.Data.Modules.UsersManager.Repository;
using SimpleInjector;
using Arquitetura.Infra.Data.Modules.ProductManagement.Repository;
using Arquitetura.Domain.Modules.ProductManagement.Interfaces.Repositories;
using Arquitetura.Domain.Modules.ProductManagement.Services;
using Arquitetura.Domain.Modules.ProductManagement.Interfaces.Services;
using Arquitetura.Application.Modules.ProductManagement.Services;
using Arquitetura.Application.Modules.ProductManagement.Interfaces;

namespace Arquitetura.Infra.Crosscuting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            #region ApplicationServiceInterfaces To ApplicationInterfaces

            container.Register<IUserAppService, UserAppService>(Lifestyle.Scoped);

            container.Register<IProductAppService, ProductAppService>(Lifestyle.Scoped);

            #endregion ApplicationServiceInterfaces To ApplicationInterfaces

            #region ServiceInterfaces To Services            

            container.Register<IProductService, ProductService>(Lifestyle.Scoped);

            #endregion ServiceInterfaces To Services

            #region RepositoryInterfaces To Repositories

            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);

            container.Register<IProductRepository, ProductRepository>(Lifestyle.Scoped);

            #endregion RepositoryInterfaces To Repositories

            #region Data

            //container.Register<IUnitOfWork, UnitOfWork>();
            container.Register<ArquiteturaContext>(Lifestyle.Scoped);

            #endregion Data

            #region Identity

            container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()), Lifestyle.Scoped);
            container.Register<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>(), Lifestyle.Scoped);
            container.Register<ApplicationRoleManager>(Lifestyle.Scoped);
            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);

            container.Register<ISecureDataFormat<AuthenticationTicket>, SecureDataFormat<AuthenticationTicket>>(Lifestyle.Scoped);
            container.Register<IDataSerializer<AuthenticationTicket>, TicketSerializer>(Lifestyle.Scoped);
            container.Register<IDataProtector>(() => new DpapiDataProtectionProvider().Create("ASP.NET Identity"), Lifestyle.Scoped);
            container.Register<ITextEncoder, Base64UrlTextEncoder>(Lifestyle.Scoped);


            #endregion Identity
        }
    }
}