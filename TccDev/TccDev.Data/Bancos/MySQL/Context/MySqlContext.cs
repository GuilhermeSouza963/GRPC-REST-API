using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TccDev.Data.Bancos.SQL.EntityFramework.Configuration;
using TccDev.Domain.Entities;
using TccDev.Mapping;

namespace TccDev.Data.Bancos.MySQL.Context
{
    public class MySqlContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ApplicationSettings.ConnectionStringMySql);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
