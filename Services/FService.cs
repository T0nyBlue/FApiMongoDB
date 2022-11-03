using FApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FApi.Services;

public class FService
{
    private readonly IMongoCollection<FModel> _fCollection;

    public FService(
        IOptions<FDatabaseSettings> FDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            FDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            FDatabaseSettings.Value.DatabaseName);

        _fCollection = mongoDatabase.GetCollection<FModel>(
            FDatabaseSettings.Value.FCollectionName);
    }

    public async Task<List<FModel>> GetAsync() =>
        await _fCollection.Find(_ => true).ToListAsync();

    public async Task<FModel?> GetAsync(string id) =>
        await _fCollection.Find(x => x.FId == id).FirstOrDefaultAsync();

    public async Task CreateAsync(FModel newF) =>
        await _fCollection.InsertOneAsync(newF);

    public async Task UpdateAsync(string id, FModel updatedF) =>
        await _fCollection.ReplaceOneAsync(x => x.FId == id, updatedF);

    public async Task RemoveAsync(string id) =>
        await _fCollection.DeleteOneAsync(x => x.FId == id);
}