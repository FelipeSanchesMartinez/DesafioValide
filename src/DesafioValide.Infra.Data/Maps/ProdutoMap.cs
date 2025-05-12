using DesafioValide.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioValide.Infra.Data.Maps
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
           builder.Property(x => x.Nome)
            .HasMaxLength(100)
            .HasColumnName("Nome")
            .IsRequired();

            builder.Property(x => x.Preco)
            .HasColumnType("decimal(10,2)")
            .HasColumnName("Preço")
            .IsRequired();

           builder.Property(x => x.Estoque)
            .HasColumnType("integer")
            .HasColumnName("Estoque")
            .IsRequired();

        }
    }
}
