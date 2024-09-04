namespace ExerciseTrackerConsoleApp.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class ExerciseTrackerContextFactory : IDesignTimeDbContextFactory<ExerciseTrackerContext>
{
    public ExerciseTrackerContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ExerciseTrackerContext>();
        optionsBuilder.UseSqlite("Data Source=exercise-tracker.db");
        return new ExerciseTrackerContext(optionsBuilder.Options);
    }
}
