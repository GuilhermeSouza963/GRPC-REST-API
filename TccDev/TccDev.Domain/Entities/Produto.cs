using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TccDev.Domain.Entities
{
    public class Produto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int ProdutoId { get; set; }
        public string Descricao { get; set; }
    }
}
