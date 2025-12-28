using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskConsoleApp.Core
{
    public class TaskRepository : ITaskRepository
    {
        private readonly List<TaskItem> _tasks = new();

        public Task AddAsync(TaskItem task)
        {
            _tasks.Add(task);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<TaskItem>>(_tasks);
        }
    }
}