using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Backend.Entities;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string Name { get; set; }
    
    public string Email { get; set; }

    public string AvatarUrl { get; set; }

    public bool Verified { get; set; } = false;

}


