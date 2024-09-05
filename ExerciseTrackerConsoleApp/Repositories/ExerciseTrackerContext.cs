namespace ExerciseTrackerConsoleApp.Repositories;

using Microsoft.EntityFrameworkCore;
using Data;

/// <summary>
/// Represents the database context for the Exercise Tracker application.
/// </summary>
public class ExerciseTrackerContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ExerciseTrackerContext"/> class.
    /// </summary>
    /// <param name="options">The options for configuring the context.</param>
    public ExerciseTrackerContext(DbContextOptions<ExerciseTrackerContext> options) : base(options)
    {
    }

    /// <summary>
    /// Gets or sets the DbSet for the RunningEntry entity.
    /// </summary>
    public DbSet<RunningEntry> RunningLogs { get; set; }
}