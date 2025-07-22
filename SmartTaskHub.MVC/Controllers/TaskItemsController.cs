using Microsoft.AspNetCore.Mvc;
using SmartTaskHub.MVC.Models;
using System.Threading.Tasks;

public class TaskItemsController : Controller
{
    private readonly ApiService _api;

    public TaskItemsController(ApiService api)
    {
        _api = api;
    }

    public async Task<IActionResult> Index()
    {
        var tasks = await _api.GetTasksAsync();
        return View(tasks);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(TaskItem task)
    {
        task.DueDate = task.DueDate.Date.Add(DateTime.Now.TimeOfDay); // Set time to current time
        var isSuccess = await _api.CreateTaskAsync(task);

        if (isSuccess)
            return RedirectToAction("Index");

        ModelState.AddModelError("", "Failed to create task");
        return View(task);
    }
    public async Task<IActionResult> Edit(string id)
    {
        var task = await _api.GetTaskByIdAsync(id);
        return View(task);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(string id, TaskItem task)
    {
        await _api.UpdateTaskAsync(id, task);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Details(string id)
    {
        var task = await _api.GetTaskByIdAsync(id);
        return View(task);
    }


    public async Task<IActionResult> Delete(string id)
    {
        await _api.DeleteTaskAsync(id);
        return RedirectToAction("Index");
    }
}
