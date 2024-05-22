using MongoDB.Bson;

namespace Jobs.Models;

// This model is used to manipulate answers candidate provided to the additional questions
public class Answers
{
    public ObjectId _id { get; set; }
    public required string questionId { get; set; }
    public  string? answer { get; set; }
}