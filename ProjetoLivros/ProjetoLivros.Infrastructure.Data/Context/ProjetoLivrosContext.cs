using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using ProjetoLivros.Domain.Entities;
using ProjetoLivros.Infra.Data.EntityConfig;

namespace ProjetoLivros.Infra.Data.Context
{
    public class ProjetoLivrosContext : DbContext
    {
        public ProjetoLivrosContext()
            : base("ProjetoLivros")
        {
            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Library> Libraries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new BookConfiguration());
            modelBuilder.Configurations.Add(new LibraryConfiguration());
        }
    }
}
