namespace ExerciseTrackerConsoleApp.Services;

using Data;
using Repositories;

public class RunningTrackerService(IRepository<RunningEntry> repository)
{
    private readonly IRepository<RunningEntry> _repository = repository;

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
            return;
        }
    }

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

