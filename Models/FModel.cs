using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FApi.Models;

public class FModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? FId { get; set; }

    [BsonElement("Name")]
    public string FName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string ERC { get; set; } = null!;
}

