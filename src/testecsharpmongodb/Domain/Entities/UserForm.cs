using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace testecsharpmongodb.Domain.Entities
{
    public class UserForm
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("nome")]
        public string Nome { get; set; }

        [BsonElement("telefone")]
        public string Telefone { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("cpfCnpj")]
        public string CpfCnpj { get; set; }

        [BsonElement("tipoplano")]
        public string TipoPlano { get; set; }
    }
}
