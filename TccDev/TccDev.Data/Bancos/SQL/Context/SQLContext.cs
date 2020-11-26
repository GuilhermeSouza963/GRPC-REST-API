using Microsoft.EntityFrameworkCore;
using TccDev.Data.Bancos.SQL.EntityFramework.Configuration;
using TccDev.Domain.Entities;
using TccDev.Mapping;

namespace TccDev.Data.Bancos.SQL.EntityFramework.Context
{
    public class SQLContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ApplicationSettings.ConnectionStringSql);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            

            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
