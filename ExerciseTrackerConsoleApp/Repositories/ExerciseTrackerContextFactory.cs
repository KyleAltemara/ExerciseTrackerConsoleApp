namespace ExerciseTrackerConsoleApp.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

/// <summary>
/// Factory class for creating instances of ExerciseTrackerContext.
/// </summary>
public class ExerciseTrackerContextFactory : IDesignTimeDbContextFactory<ExerciseTrackerContext>
{
    /// <summary>
    /// Creates a new instance of ExerciseTrackerContext.
    /// </summary>
    /// <param name="args">The command-line arguments.</param>
    /// <returns>The created ExerciseTrackerContext instance.</returns>
    public ExerciseTrackerContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ExerciseTrackerContext>();
        optionsBuilder.UseSqlite("Data Source=exercise-tracker.db");
        return new ExerciseTrackerContext(optionsBuilder.Options);
    }
}
