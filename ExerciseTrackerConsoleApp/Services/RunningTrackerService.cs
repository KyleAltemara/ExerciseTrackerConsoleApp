namespace ExerciseTrackerConsoleApp.Services;

using Data;
using Repositories;

/// <summary>
/// The service for the running tracker.
/// </summary>
/// <param name="repository">The repository for running entries.</param>
public class RunningTrackerService(IRepository<RunningEntry> repository)
{
    private readonly IRepository<RunningEntry> _repository = repository;

    /// <summary>
    /// Logs an exercise entry.
    /// </summary>
    /// <param name="startDate">The start date and time of the exercise.</param>
    /// <param name="duration">The duration of the exercise.</param>
    /// <param name="comments">Additional comments about the exercise.</param>
    public void LogExercise(DateTime startDate, TimeSpan duration, string comments)
    {
        try
        {
            var logs = _repository.GetAll();
            var id = logs.Any() ? logs.Max(e => e.Id) + 1 : 0;
            var exerciseEntry = new RunningEntry() { DateStart = startDate, Duration = duration, Comments = comments, Id = id };
            _repository.Add(exerciseEntry);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error logging exercise: {ex.Message}");
        }
    }

    /// <summary>
    /// Retrieves all exercise logs.
    /// </summary>
    /// <returns>A collection all the exercise log entries, or an empty collection if there are none.</returns>
    public IEnumerable<IExerciseEntry> GetExerciseLogs()
    {
        try
        {
            return _repository.GetAll();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting exercise logs: {ex.Message}");
            return [];
        }
    }

    /// <summary>
    /// Deletes an exercise log entry.
    /// </summary>
    /// <param name="id">The ID of the exercise log entry to delete.</param>
    /// <returns>True if the exercise log entry was successfully deleted, otherwise false.</returns>
    public bool DeleteExerciseLog(int id)
    {
        try
        {
            var exerciseEntry = _repository.GetById(id);
            if (exerciseEntry is not null)
            {
                _repository.Delete(exerciseEntry);
                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting exercise log: {ex.Message}");
            return false;
        }
    }
}

