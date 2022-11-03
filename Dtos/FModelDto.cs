using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FApi.Dtos;

public class FModelDto
{
    [BsonElement("Name")]
    public string FName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string ERC { get; set; } = null!;
}

