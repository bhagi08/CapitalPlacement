using MongoDB.Bson;

namespace Jobs.Models;

// This model is used to manipulate programs
public class Programs
{

    public ObjectId _id { get; set; }
    public required string programId { get; set; }

    public required string title { get; set; }

    public string? description { get; set; } 

}