using AutoMapper;
using Arquitetura.Application.Modules.UsersManager.ViewModels;
using Arquitetura.Domain.Modules.UsersManager.Models;
using Arquitetura.Application.Modules.ProductManagement.ViewModels;
using Arquitetura.Domain.Modules.ProductManagement.Models;

namespace Arquitetura.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            #region UserManager

            CreateMap<User, UserViewModel>();

            #endregion UserManager

            #region Product Management

            CreateMap<Product, ProductViewModel>();

            #endregion Product Management
        }
    }
}
