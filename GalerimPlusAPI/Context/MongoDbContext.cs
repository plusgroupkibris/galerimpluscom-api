using GalerimPlusAPI.Models;
using MongoDB.Driver;

namespace GalerimPlusAPI.Context;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration["MongoDbSettings:ConnectionString"]);
        _database = client.GetDatabase(configuration["MongoDbSettings:DatabaseName"]);
    }

    public IMongoCollection<CarListing> CarListings => _database.GetCollection<CarListing>("CarListings");



}
