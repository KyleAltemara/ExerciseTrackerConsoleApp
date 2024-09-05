namespace ExerciseTrackerConsoleApp.Data
{
    /// <summary>
    /// Represents an exercise entry.
    /// </summary>
    public interface IExerciseEntry
    {
        /// <summary>
        /// Gets the name of the exercise.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets or sets the ID of the exercise entry.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the start date and time of the exercise.
        /// </summary>
        DateTime DateStart { get; set; }

        /// <summary>
        /// Gets the end date and time of the exercise.
        /// </summary>
        DateTime DateEnd { get; }

        /// <summary>
        /// Gets or sets the duration of the exercise.
        /// </summary>
        TimeSpan Duration { get; set; }

        /// <summary>
        /// Gets or sets the comments for the exercise.
        /// </summary>
        string? Comments { get; set; }

        /// <summary>
        /// Returns a string representation of the exercise entry.
        /// </summary>
        /// <returns>A string representation of the exercise entry.</returns>
        string ToString();
    }
}