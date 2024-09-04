namespace ExerciseTrackerConsoleApp;

using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Services;
using UI;

public class Program
{
    static void Main()
    {
        var service = new ServiceCollection();
        service.AddDbContext<ExerciseTrackerContext>(options => options.UseSqlite("Data Source=exercise-tracker.db"));
        service.AddSingleton<IRepository<RunningEntry>, RunningTrackerRepository<RunningEntry>>();
        service.AddSingleton<RunningTrackerService>();
        service.AddSingleton<Menu>();

        var serviceProvider = service.BuildServiceProvider();

        var dbContext = serviceProvider.GetRequiredService<ExerciseTrackerContext>();
        dbContext.Database.EnsureCreated();

        var menu = serviceProvider.GetRequiredService<Menu>();
        menu.MainMenu();
    }
}
