namespace SmartTaskHub.MVC.Models
{
    public class TaskItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }
        public string AssignedTo { get; set; }
        public string ProjectId { get; set; }
    }

}
