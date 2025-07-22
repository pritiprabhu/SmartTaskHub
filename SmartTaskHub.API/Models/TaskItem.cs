using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SmartTaskHub.API.Models
{
    public class TaskItem
    {
        [BsonId] // Marks this property as the document’s primary key
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } 

        [BsonElement("Title")]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Status { get; set; } = "To Do"; // To Do, In Progress, Done

        public string DueDate { get; set; } = string.Empty;

        public string AssignedTo { get; set; } = string.Empty;

        public string ProjectId { get; set; } = string.Empty; // For future linking
    }
}
