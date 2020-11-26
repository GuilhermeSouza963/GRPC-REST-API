using MongoDB.Driver;
using System;
using TccDev.Domain.Entities;
using TccDev.Mapping;

namespace TccDev.Data.Bancos.MongoDB.Context
{
    public class MongoDbContext
    {
        private IMongoDatabase _database { get; }
        public MongoDbContext()
        {
            try
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ApplicationSettings.ConnectionStringMongoDb));

                settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };

                var mongoClient = new MongoClient(settings);
                _database = mongoClient.GetDatabase("TCC");
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar com o servidor.", ex);
            }
        }

        public IMongoCollection<Produto> Produtos
        {
            get
            {
                return _database.GetCollection<Produto>("Produto");
            }
        }
    }
}
