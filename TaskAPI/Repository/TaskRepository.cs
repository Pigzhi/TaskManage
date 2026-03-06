using TaskAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskAPI.Repository
{
    public class TaskRepository
    {
        private readonly TaskMContext _context;

        public TaskRepository(TaskMContext context)
        {
            _context = context;
        }

        public async Task<List<TaskItem>> GetAll()
        {
            return await _context.TaskItem.ToListAsync();
        }
        public async Task<TaskItem?> GetById(int UserId)
        {
            return await _context.TaskItem.FindAsync(UserId);
        }
        public async Task Add(Models.TaskItem task)
        {
            _context.TaskItem.Add(task);
            await _context.SaveChangesAsync();          
        }
        public async Task Update(TaskItem task)
        {
            _context.TaskItem.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TaskItem task)
        {
            _context.TaskItem.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}
