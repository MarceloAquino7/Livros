using System.Data.Entity.ModelConfiguration;
using ProjetoLivros.Domain.Entities;

namespace ProjetoLivros.Infra.Data.EntityConfig
{
    public class BookConfiguration : EntityTypeConfiguration<Book>
    {
        public BookConfiguration()
        {
            HasKey(b => b.BookId);

            Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(150);

            Property(b => b.PublisherName)
                .IsRequired()
                .HasMaxLength(150);

            Property(b => b.Author)
                .IsRequired()
                .HasMaxLength(150);

            Property(b => b.Price)
                .IsRequired();
        }
    }
}
