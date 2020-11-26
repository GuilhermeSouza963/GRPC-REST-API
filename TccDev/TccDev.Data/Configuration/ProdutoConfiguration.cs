using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TccDev.Domain.Entities;

namespace TccDev.Data.Bancos.SQL.EntityFramework.Configuration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(x => x.ProdutoId);

            builder.Property(x => x.ProdutoId).HasColumnName(@"ProdutoId").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Descricao).HasColumnName(@"Descricao").HasColumnType("varchar(256)");
        }
    }
}
