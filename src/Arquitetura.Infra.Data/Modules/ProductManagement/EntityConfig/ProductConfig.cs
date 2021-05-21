using Arquitetura.Domain.Modules.ProductManagement.Models;
using System.Data.Entity.ModelConfiguration;

namespace Arquitetura.Infra.Data.Modules.ProductManagement.EntityConfig
{
    public class ProductConfig : EntityTypeConfiguration<Product>
    {
        public ProductConfig()
        {
            HasKey(p => p.Id);

            Property(p => p.Name)
                .IsRequired();

            Ignore(p => p.ValidationResult);

            ToTable("Products");
        }
    }
}
