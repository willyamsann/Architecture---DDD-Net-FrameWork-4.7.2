using Arquitetura.Domain.Modules.UsersManager.Models;
using System.Data.Entity.ModelConfiguration;

namespace Arquitetura.Infra.Data.Modules.UsersManager.EntityConfig
{
    public class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            HasKey(u => u.Id);

            Property(u => u.Id)
                .HasColumnType("nvarchar")
                .IsRequired()
                .HasMaxLength(128);

            Property(u => u.Email)
                .HasColumnType("nvarchar")
                .IsRequired()
                .HasMaxLength(256);

            Property(u => u.PasswordHash)
                .HasColumnType("nvarchar");

            Property(u => u.SecurityStamp)
                .HasColumnType("nvarchar");

            Property(u => u.PhoneNumber)
                .HasColumnType("nvarchar");

            Property(u => u.UserName)
                .HasColumnType("nvarchar")
                .IsRequired()
                .HasMaxLength(256);

            Ignore(u => u.ValidationResult);

            ToTable("AspNetUsers");
        }
    }
}
