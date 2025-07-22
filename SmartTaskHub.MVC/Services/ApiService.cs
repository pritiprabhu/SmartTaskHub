using SmartTaskHub.MVC.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class ApiService
{
    private readonly HttpClient _http;

    public ApiService(HttpClient http)
    {
        _http = http;
        _http.BaseAddress = new Uri("http://localhost:5010/api/"); // Change port if needed
    }

    public async Task<List<TaskItem>> GetTasksAsync()
    {
        return await _http.GetFromJsonAsync<List<TaskItem>>("TaskItems");
    }

    public async Task<TaskItem> GetTaskByIdAsync(string id)
    {
        return await _http.GetFromJsonAsync<TaskItem>($"TaskItems/{id}");
    }

    public async Task<bool> CreateTaskAsync(TaskItem task)
    {
        var response = await _http.PostAsJsonAsync("TaskItems", task);
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"API Error: {response.StatusCode} - {errorContent}");
        }
        return response.IsSuccessStatusCode;
    }



    public async Task UpdateTaskAsync(string id, TaskItem task)
    {
        await _http.PutAsJsonAsync($"TaskItems/{id}", task);
    }

    public async Task DeleteTaskAsync(string id)
    {
        await _http.DeleteAsync($"TaskItems/{id}");
    }
}
