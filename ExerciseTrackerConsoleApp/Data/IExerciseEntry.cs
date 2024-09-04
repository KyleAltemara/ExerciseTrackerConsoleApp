namespace ExerciseTrackerConsoleApp.Data
{
    public interface IExerciseEntry
    {
        public string Name { get; }
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; }
        public TimeSpan Duration { get; set; }
        public string? Comments { get; set; }
        public string ToString();
    }
}