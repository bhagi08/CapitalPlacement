using MongoDB.Bson;

namespace Jobs.Models;

// This model is used to manipulate personal information fields of the application form
public class PersonalInformationField
{
    public ObjectId _id { get; set; }
    public required string fieldId { get; set; }
    public required string fieldName { get; set; }
    public bool isRequired { get; set; }
    public bool isVisible { get; set; }
}