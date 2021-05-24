using Arquitetura.Application.Modules.ProductManagement.ViewModels;
using Arquitetura.Domain.Modules.ProductManagement.Models;
using AutoMapper;

public class AutoMapperWebConfiguration
{
    public static void Configure()
    {
        Mapper.Initialize(cfg =>
        {
            cfg.CreateMap<Product, ProductViewModel>();
            cfg.CreateMap<ProductViewModel, Product>();

        });

        Mapper.AssertConfigurationIsValid();
    }
}