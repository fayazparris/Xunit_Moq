using TaskConsoleApp.Core;
using System;
using System.Threading.Tasks;

internal class Program
{
    private static async Task Main(string[] args)
    {
        ITaskRepository repo = new TaskRepository();
        TaskService service = new TaskService(repo);

        while (true)
        {
            Console.WriteLine("\nTask Manager");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. List Tasks");
            Console.WriteLine("3. Exit");
            Console.Write("Choice: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter task title: ");
                    string title = Console.ReadLine() ?? "";

                    try
                    {
                        await service.AddTaskAsync(title);
                        Console.WriteLine("Task added.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    break;

                case "2":
                    var tasks = await service.GetAllTasksAsync();
                    Console.WriteLine("\nTasks:");
                    foreach (var t in tasks)
                        Console.WriteLine($"- {t.Title}");
                    break;

                case "3":
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}