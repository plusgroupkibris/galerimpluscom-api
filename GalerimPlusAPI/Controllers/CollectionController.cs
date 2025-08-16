using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;

namespace GalerimPlusAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CollectionController : ControllerBase
{
    private readonly IMongoDatabase _database;

    public CollectionController(IMongoClient client, IConfiguration config)
    {
        var dbName = config.GetValue<string>("MongoDbSettings:DatabaseName");
        _database = client.GetDatabase(dbName);
    }



    [HttpPost("{collectionName}/insert")]
    public async Task<IActionResult> Insert(string collectionName, [FromBody] JObject data)
    {
        var collection = _database.GetCollection<BsonDocument>(collectionName);
        await collection.InsertOneAsync(BsonDocument.Parse(data.ToString()));
        return Ok(new { message = "Inserted successfully" });
    }

    [HttpPut("{collectionName}/update/{id}")]
    public async Task<IActionResult> Update(string collectionName, string id, [FromBody] JObject data)
    {
        var collection = _database.GetCollection<BsonDocument>(collectionName);
        var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
        var update = new BsonDocument("$set", BsonDocument.Parse(data.ToString()));
        var result = await collection.UpdateOneAsync(filter, update);
        return Ok(result.ModifiedCount);
    }

    [HttpDelete("{collectionName}/delete/{id}")]
    public async Task<IActionResult> Delete(string collectionName, string id)
    {
        var collection = _database.GetCollection<BsonDocument>(collectionName);
        var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
        var result = await collection.DeleteOneAsync(filter);
        return Ok(result.DeletedCount);
    }

    [HttpGet("{collectionName}")]
    public async Task<IActionResult> GetAll(string collectionName)
    {
        var collection = _database.GetCollection<BsonDocument>(collectionName);
        var docs = await collection.Find(new BsonDocument()).ToListAsync();
        return Ok(docs);
    }

    [HttpGet("{collectionName}/{id}")]
    public async Task<IActionResult> GetById(string collectionName, string id)
    {
        var collection = _database.GetCollection<BsonDocument>(collectionName);
        var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
        var doc = await collection.Find(filter).FirstOrDefaultAsync();
        return doc != null ? Ok(doc) : NotFound();
    }
}


