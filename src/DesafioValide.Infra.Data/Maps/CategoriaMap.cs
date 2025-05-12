using DesafioValide.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioValide.Infra.Data.Maps
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.Property(x => x.Nome)
                .HasMaxLength(100)
                .HasColumnName("Nome")
                .IsRequired();

            builder.HasMany(x => x.Produtos).WithOne(x => x.Categoria).HasForeignKey(x => x.CategoriaId)
                                                                       .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
