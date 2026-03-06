using TaskAPI.Models;
using TaskAPI.Repository;

namespace TaskAPI.Services
{
    public class TaskService
    {
        private readonly TaskRepository _repo;

        public TaskService(TaskRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<TaskItem>> GetTasks()
        {
            return await _repo.GetAll();
        }

        public async Task<TaskItem?> GetTask(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task CreateTask(TaskItem task)
        {
            await _repo.Add(task);
        }

        public async Task UpdateTask(int id, TaskItem task)
        {
            var existing = await _repo.GetById(id);

            if (existing == null)
                throw new Exception("Task not found");

            existing.Title = task.Title;
            existing.Description = task.Description;

            await _repo.Update(existing);
        }

        public async Task DeleteTask(int id)
        {
            var task = await _repo.GetById(id);

            if (task == null)
                throw new Exception("Task not found");

            await _repo.Delete(task);
        }
    }
}