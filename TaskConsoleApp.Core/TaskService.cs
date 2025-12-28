using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskConsoleApp.Core
{
    public class TaskService
    {
        private readonly ITaskRepository _repo;

        public TaskService(ITaskRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task AddTaskAsync(string title)
        {
            var all = await _repo.GetAllAsync();

            if (all.Any(t => t.Title == title))
                throw new InvalidOperationException("Task already exists");

            await _repo.AddAsync(new TaskItem { Title = title });
        }

        public Task<IEnumerable<TaskItem>> GetAllTasksAsync()
        {
            return _repo.GetAllAsync();
        }
    }
}