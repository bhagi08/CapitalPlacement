using Jobs.Models;
namespace Jobs.Service;
using MongoDB.Driver ;
public class ApplicationFormService
{
    private readonly IMongoCollection<ApplicationForm> _applicationForm;

    // Establish the connection with the database and get the collection
    public ApplicationFormService(IConfiguration config)
    {
        var client = new MongoClient(config.GetConnectionString("CosmosDB"));
        var database = client.GetDatabase(config["CosmosDbSettings:DatabaseName"]);
        _applicationForm = database.GetCollection<ApplicationForm>(config["CosmosDbSettings:applicationFormsCollectionName"]);
    }

    public List<ApplicationForm> Get() =>
    _applicationForm.Find(application => true).ToList();

    public ApplicationForm Get(string id) =>
        _applicationForm.Find<ApplicationForm>(applicationForm => applicationForm.formId == id).FirstOrDefault();

    public ApplicationForm Create(ApplicationForm applicationForm)
    {
        _applicationForm.InsertOne(applicationForm);
        return applicationForm;
    }

    public void Update(string id, ApplicationForm applicationFormIn) =>
        _applicationForm.ReplaceOne(applicationForm => applicationForm.formId == id, applicationFormIn);

    public void Remove(string id) => 
        _applicationForm.DeleteOne(applicationForm => applicationForm.formId == id);

}
