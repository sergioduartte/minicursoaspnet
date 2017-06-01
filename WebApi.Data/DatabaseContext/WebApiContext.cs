using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entidades;

namespace WebApi.Data.DatabaseContext
{
    public class WebApiContext : DbContext 
    {
        public WebApiContext() : base("MyContactsConnectionString")
        {

        }

        public DbSet<Contato> Contatos { get; set; }

        public class AppDataContextInitialize : CreateDatabaseIfNotExists<WebApiContext>
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "Id").Configure(p => p.IsKey());

            //Configuration.LazyLoadingEnabled = false;
            //Configuration.ProxyCreationEnabled = false;
            modelBuilder.Properties<string>().Configure(c => c.HasMaxLength(100));
            modelBuilder.Properties<string>().Configure(c => c.HasColumnType("varchar"));

        }

    }
}
