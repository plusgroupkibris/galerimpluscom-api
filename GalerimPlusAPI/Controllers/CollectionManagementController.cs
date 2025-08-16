using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace GalerimPlusAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CollectionManagementController : ControllerBase
{
    private readonly IMongoDatabase _database;

    public CollectionManagementController(IMongoClient client, IConfiguration config)
    {
        var dbName = config.GetValue<string>("MongoDbSettings:DatabaseName");
        _database = client.GetDatabase(dbName);
    }

    [HttpGet]
    public IActionResult ListCollections()
    {
        var collections = _database.ListCollectionNames().ToList();
        return Ok(collections);
    }

    [HttpPost]
    public IActionResult CreateCollection([FromQuery] string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return BadRequest("Collection name is required.");

        var existingCollections = _database.ListCollectionNames().ToList();
        if (existingCollections.Contains(name))
            return Conflict($"Collection '{name}' already exists.");

        _database.CreateCollection(name);
        return Ok($"Collection '{name}' created successfully.");
    }

    [HttpDelete]
    public IActionResult DeleteCollection([FromQuery] string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return BadRequest("Collection name is required.");

        var existingCollections = _database.ListCollectionNames().ToList();
        if (!existingCollections.Contains(name))
            return NotFound($"Collection '{name}' does not exist.");

        _database.DropCollection(name);
        return Ok($"Collection '{name}' deleted successfully.");
    }
}
