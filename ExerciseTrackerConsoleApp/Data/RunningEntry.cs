namespace ExerciseTrackerConsoleApp.Data;

/// <summary>
/// The specific implementation of <see cref="IExerciseEntry"/> for running.
/// </summary>
public class RunningEntry : IExerciseEntry
{
    public string Name { get; } = "Running";
    public int Id { get; set; }
    public DateTime DateStart { get; set; }
    public TimeSpan Duration { get; set; }
    public string? Comments { get; set; }
    public DateTime DateEnd => DateStart + Duration;
    public override string ToString() => $"DateStart: {DateStart:yyyy-MM-dd HH:mm}, Duration: {Duration:c}, Comments: {Comments}";
}
