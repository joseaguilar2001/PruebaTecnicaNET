using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.Models
{
    public class Students
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Fecha_nacimiento { get; set; } = null!;
        public string Nombre_padre { get; set; } = null!;
        public string Nombre_madre { get; set; } = null!;
        public string Grado { get; set; } = null!;
        public string Seccion { get; set; } = null!;
        public string Fecha_ingreso { get; set; } = null!;
    }
}