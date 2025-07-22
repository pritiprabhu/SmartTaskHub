using Microsoft.AspNetCore.Mvc;
using SmartTaskHub.API.Models;
using SmartTaskHub.API.Services;

namespace SmartTaskHub.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskItemsController : ControllerBase
    {
        private readonly TaskItemService _taskService;

        public TaskItemsController(TaskItemService taskService)
        {
            _taskService = taskService;
        }

        // GET: api/TaskItems
        [HttpGet]
        public async Task<ActionResult<List<TaskItem>>> GetAll()
        {
            var tasks = await _taskService.GetAllAsync();
            return Ok(tasks);
        }

        // GET: api/TaskItems/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetById(string id)
        {
            var task = await _taskService.GetByIdAsync(id);
            if (task == null)
                return NotFound();
            return Ok(task);
        }

        // POST: api/TaskItems
        [HttpPost]
        public async Task<ActionResult> Create(TaskItem task)
        {
            var createdTask = await _taskService.CreateAsync(task);
            return CreatedAtAction(nameof(GetById), new { id = createdTask.Id }, createdTask);
        }


        // PUT: api/TaskItems/{id}  
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, TaskItem task)
        {
            var existing = await _taskService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            task.Id = id; // ensure ID remains unchanged
            await _taskService.UpdateAsync(id, task);
            return NoContent();
        }

        // DELETE: api/TaskItems/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var existing = await _taskService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _taskService.DeleteAsync(id);
            return NoContent();
        }
    }
}
