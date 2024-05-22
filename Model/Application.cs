using MongoDB.Bson;

namespace Jobs.Models;

// This model is used to manipulate applications submitted by candidates
public class Application
{
    public ObjectId _id { get; set; }
    public required string applicationId { get; set; }
    public required string formId { get; set; }
    public required string candidateId { get; set; }
    public required Dictionary<string, string> personalInformation { get; set; }
    public List<Answers>? answers { get; set; }
}