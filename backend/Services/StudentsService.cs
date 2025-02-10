using backend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace backend.Services;

public class StudentsService
{
    private readonly IMongoCollection<Students> _studentsCollection;

    public StudentsService(
        IOptions<StudentsStoreDatabaseSettings> studentsStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            studentsStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            studentsStoreDatabaseSettings.Value.DatabaseName);

        _studentsCollection = mongoDatabase.GetCollection<Students>(
            studentsStoreDatabaseSettings.Value.StudentCollectionName);
    }

    public async Task<List<Students>> GetAsync() =>
        await _studentsCollection.Find(_ => true).ToListAsync();

    public async Task<Students?> GetAsync(string id) =>
        await _studentsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task<List<Students>> GetByGradoAsync(string grado) =>
        await _studentsCollection.Find(x => x.Grado == grado).ToListAsync();

    public async Task CreateAsync(Students newStudent) =>
        await _studentsCollection.InsertOneAsync(newStudent);

    public async Task UpdateAsync(string id, Students updatedBook) =>
        await _studentsCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

    public async Task RemoveAsync(string id) =>
        await _studentsCollection.DeleteOneAsync(x => x.Id == id);
}
