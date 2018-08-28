
using System.Data.Entity.ModelConfiguration;
using ProjetoLivros.Domain.Entities;

namespace ProjetoLivros.Infra.Data.EntityConfig
{
    public class LibraryConfiguration : EntityTypeConfiguration<Library>
    {
        public LibraryConfiguration()
        {
            HasKey(l => l.LibraryId);

            Property(l => l.Name)
                .IsRequired()
                .HasMaxLength(250);

            Property(l => l.Address)
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}
