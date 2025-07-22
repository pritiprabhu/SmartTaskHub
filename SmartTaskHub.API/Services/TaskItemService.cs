using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SmartTaskHub.API.Configurations;
using SmartTaskHub.API.Models;

namespace SmartTaskHub.API.Services
{
    public class TaskItemService
    {
        private readonly IMongoCollection<TaskItem> _taskCollection;

        public TaskItemService(IOptions<MongoDBSettings> mongoSettings)
        {
            var client = new MongoClient(mongoSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoSettings.Value.DatabaseName);
            _taskCollection = database.GetCollection<TaskItem>("TaskItems");
        }

        public async Task<List<TaskItem>> GetAllAsync() =>
            await _taskCollection.Find(_ => true).ToListAsync();

        public async Task<TaskItem?> GetByIdAsync(string id) =>
            await _taskCollection.Find(t => t.Id == id).FirstOrDefaultAsync();

        public async Task<TaskItem> CreateAsync(TaskItem task)
        {
            await _taskCollection.InsertOneAsync(task);
            return task;  // Now task.Id should be populated by Mongo driver
        }


        public async Task UpdateAsync(string id, TaskItem updatedTask) =>
            await _taskCollection.ReplaceOneAsync(t => t.Id == id, updatedTask);

        public async Task DeleteAsync(string id) =>
            await _taskCollection.DeleteOneAsync(t => t.Id == id);
    }
}
