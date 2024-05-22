using MongoDB.Bson;

namespace Jobs.Models;

// This model is used to manipulate additional questions based on their types
public class AdditionalQuestion
{
    public ObjectId _id { get; set; }
    public required string questionId { get; set; }
    public required string questionText { get; set; }
    public required string questionType { get; set; }
}
