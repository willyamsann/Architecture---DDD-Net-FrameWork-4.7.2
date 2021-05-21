using AutoMapper;
using Arquitetura.Application.Modules.UsersManager.ViewModels;
using Arquitetura.Domain.Modules.UsersManager.Models;
using Arquitetura.Domain.Modules.ProductManagement.Models;
using Arquitetura.Application.Modules.ProductManagement.ViewModels;

namespace Arquitetura.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            #region UserManager

            CreateMap<UserViewModel, User>();

            #endregion UserManager

            #region Product Management

            CreateMap<ProductViewModel, Product>();

            #endregion Product Management
        }
    }
}
