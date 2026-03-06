using Microsoft.AspNetCore.Mvc;
using TaskAPI.Models;
using TaskAPI.Services;

namespace TaskAPI.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _service;

        public TaskController(TaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _service.GetTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var task = await _service.GetTask(id);

            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskDto dto)
        {
            var task = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                DueDate = dto.DueDate,
                Status = "Pending",
                CreatedAt = DateTime.Now,
                UserId = 1
            };
            await _service.CreateTask(task);
            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TaskItem task)
        {
            await _service.UpdateTask(id, task);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteTask(id);
            return Ok();
        }
    }
}