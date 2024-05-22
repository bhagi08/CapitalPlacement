using MongoDB.Bson;

namespace Jobs.Models;

// This model is used to manipulate application forms
public class ApplicationForm
{
    public ObjectId _id { get; set; }
    public required string formId { get; set; }
    public required string programId { get; set; }
    public required List<PersonalInformationField> personalInformationFields { get; set; }
    public List<AdditionalQuestion>? additionalQuestions { get; set; }
}