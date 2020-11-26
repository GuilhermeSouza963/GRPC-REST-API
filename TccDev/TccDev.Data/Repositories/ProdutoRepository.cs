using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using TccDev.Data.Bancos.MongoDB.Context;
using TccDev.Data.Bancos.MySQL.Context;
using TccDev.Data.Bancos.SQL.EntityFramework.Context;
using TccDev.Domain.Entities;
using TccDev.Domain.Interfaces.Repositories;

namespace TccDev.Data.Bancos.SQL.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        //private readonly SQLContext _context;
        //private readonly MySqlContext _context;
        private readonly MongoDbContext _context;

        //sql
        //public ProdutoRepository(SQLContext context)
        //{
        //    _context = context;
        //}

        // mySql
        //public ProdutoRepository(MySqlContext context)
        //{
        //    _context = context;
        //}

        //MongoDb
        public ProdutoRepository(MongoDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Produto> GetAll()
        {
            //sql e mysql
            //var query = _context.Produtos.AsQueryable();
            //mongodb
            var query = _context.Produtos.Find(_ => true);

            return query.ToList();
        }
    }
}
