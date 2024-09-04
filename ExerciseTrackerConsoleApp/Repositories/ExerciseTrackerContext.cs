namespace ExerciseTrackerConsoleApp.Repositories;

using Microsoft.EntityFrameworkCore;
using Data;

public class ExerciseTrackerContext(DbContextOptions<ExerciseTrackerContext> options) : DbContext(options)
{
    public DbSet<RunningEntry> RunningLogs { get; set; }
}

