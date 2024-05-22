using Jobs.Models;
namespace Jobs.Service;
using MongoDB.Driver ;
public class ProgramsService
{
    private readonly IMongoCollection<Programs> _programs;

    // Establish the connection with the database and get the collection
    public ProgramsService(IConfiguration config)
    {
        var client = new MongoClient(config.GetConnectionString("CosmosDB"));
        var database = client.GetDatabase(config["CosmosDbSettings:DatabaseName"]);
        _programs = database.GetCollection<Programs>(config["CosmosDbSettings:programsCollectionName"]);
    }

    public List<Programs> Get() =>
    _programs.Find(programs => true).ToList();

    public Programs Get(string id) =>
        _programs.Find<Programs>(programs => programs.programId == id).FirstOrDefault();

    public Programs Create(Programs programs)
    {
        _programs.InsertOne(programs);
        return programs;
    }

    public void Update(string id, Programs programs) =>
        _programs.ReplaceOne(program => program.programId == id, programs);

    public void Remove(string id) => 
        _programs.DeleteOne(programs => programs.programId == id);

}
