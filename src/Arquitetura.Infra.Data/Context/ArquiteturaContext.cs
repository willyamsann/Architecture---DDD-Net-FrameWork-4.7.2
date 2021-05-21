using Arquitetura.Domain.Modules.ProductManagement.Models;
using Arquitetura.Domain.Modules.UsersManager.Models;
using Arquitetura.Infra.Data.Modules.ProductManagement.EntityConfig;
using Arquitetura.Infra.Data.Modules.UsersManager.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Arquitetura.Infra.Data.Context
{
    public class ArquiteturaContext : DbContext
    {
        public ArquiteturaContext() : base("DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new UserConfig());

            modelBuilder.Configurations.Add(new ProductConfig());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var userName = System.Web.HttpContext.Current.User.Identity.Name;

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("AddDate") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("AddDate").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("AddDate").IsModified = false;
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("EditDate") != null))
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                    entry.Property("EditDate").CurrentValue = DateTime.Now;
                else
                    entry.Property("EditDate").IsModified = false;
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("AddWho") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("AddWho").CurrentValue = userName;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("AddWho").OriginalValue = "";
                    entry.Property("AddWho").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("EditWho") != null))
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    entry.Property("EditWho").CurrentValue = userName;
                }
                else
                {
                    entry.Property("EditWho").OriginalValue = "";
                    entry.Property("EditWho").IsModified = false;
                }
            }

            return base.SaveChanges();
        }
    }
}
