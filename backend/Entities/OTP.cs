using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Backend.Entities;

public class OTP
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string UserId { get; set; } 
    
    public string HashedOTP { get; set; }


    public DateTime CreatedAt { get; set; }
    
    public DateTime ExpiredAt { get; set; }
}
