using Jobs.Models;
namespace Jobs.Service;
using MongoDB.Driver ;
public class ApplicationService
{
    private readonly IMongoCollection<Application> _application;

    // Establish the connection with the database and get the collection
    public ApplicationService(IConfiguration config)
    {
        var client = new MongoClient(config.GetConnectionString("CosmosDB"));
        Console.WriteLine("Connection established");
        var database = client.GetDatabase(config["CosmosDbSettings:DatabaseName"]);
        _application = database.GetCollection<Application>(config["CosmosDbSettings:ApplicationsCollectionName"]);
    }

    public List<Application> Get() =>
    _application.Find(application => true).ToList();

    public Application Get(string id) =>
        _application.Find<Application>(application => application.applicationId == id).FirstOrDefault();

    public Application Create(Application application)
    {
        _application.InsertOne(application);
        return application;
    }

    public void Update(string id, Application applicationIn) =>
        _application.ReplaceOne(application => application.applicationId == id, applicationIn);

    public void Remove(string id) => 
        _application.DeleteOne(application => application.applicationId == id);

}
