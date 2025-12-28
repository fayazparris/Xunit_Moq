using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskConsoleApp.Core
{
    public interface ITaskRepository
    {
        Task AddAsync(TaskItem task);
        Task<IEnumerable<TaskItem>> GetAllAsync();
    }
}