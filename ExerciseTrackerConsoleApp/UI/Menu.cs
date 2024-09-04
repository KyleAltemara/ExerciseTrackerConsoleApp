namespace ExerciseTrackerConsoleApp.UI;

using Data;
using Services;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;

public class Menu(RunningTrackerService exerciseTrackerService)
{
    private readonly RunningTrackerService _exerciseTrackerService = exerciseTrackerService;

    public void MainMenu()
    {
        var menuOptions = new Dictionary<string, Action>
            {
                { "Log Run", () => LogExercise() },
                { "Print Running Logs", () => PrintLogs() },
                { "Delete Running Log", () => DeleteLog() },
                { "Exit", () => Environment.Exit(0) },
            };

        var menu = new SelectionPrompt<string>()
            .Title("[bold]Coding Tracker Menu[/]")
            .AddChoices(menuOptions.Keys);

        while (true)
        {
            string choice = AnsiConsole.Prompt(menu);
            menuOptions[choice]();
        }
    }

    private void LogExercise()
    {
        var date = GetDateTime();
        if (!date.HasValue)
        {
            return;
        }

        int duration;
        while (true)
        {
            var durationInput = AnsiConsole.Ask<string>("Please enter the duration of the exercise in minutes: ");
            if (durationInput.Equals("c", StringComparison.CurrentCultureIgnoreCase))
            {
                return;
            }

            if (int.TryParse(durationInput, out duration) && duration > 0)
            {
                break;
            }

            AnsiConsole.MarkupLine("[bold red]Invalid duration format. Please try again.[/]");
        }

        var comments = AnsiConsole.Ask<string>("Please enter any comments (or 'c' to cancel): ");
        if (comments.Equals("c", StringComparison.CurrentCultureIgnoreCase))
        {
            return;
        }

        _exerciseTrackerService.LogExercise(date.Value, new TimeSpan(0, duration, 0), comments);
    }

    private void PrintLogs()
    {
        var exerciseLogs = _exerciseTrackerService.GetExerciseLogs();
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Date Start");
        table.AddColumn("Date End");
        table.AddColumn("Duration");
        table.AddColumn("Comments");
        foreach (var exerciseLog in exerciseLogs)
        {
            string[] row =
            [
                exerciseLog.Id.ToString(),
                exerciseLog.Name,
                exerciseLog.DateStart.ToString("yyyy-MM-dd HH:mm"),
                exerciseLog.DateEnd.ToString("yyyy-MM-dd HH:mm"),
                exerciseLog.Duration.ToString("c"),
                exerciseLog.Comments?.ToString() ?? string.Empty
            ];

            table.AddRow(row);
        }

        AnsiConsole.Write(table);
        AnsiConsole.WriteLine("Press and key to return to the main menu");
        Console.ReadKey();
    }

    private void DeleteLog()
    {
        var logs = _exerciseTrackerService.GetExerciseLogs();
        Dictionary<string, IExerciseEntry> options = logs.ToDictionary(log => log.ToString(), log => log);
        options.Add("Cancel", new RunningEntry());
        var prompt = new SelectionPrompt<string>()
            .Title("Select the log to delete")
            .PageSize(10)
            .AddChoices(options.Keys);
        var choice = AnsiConsole.Prompt(prompt);
        if (choice == "Cancle")
        {
            return;
        }

        if (_exerciseTrackerService.DeleteExerciseLog(options[choice].Id))
        {
            AnsiConsole.WriteLine("Log deleted successfully");
        }
        else
        {
            AnsiConsole.WriteLine("Error deleting log");
        }

        AnsiConsole.WriteLine("Press any key to return to the main menu");
        Console.ReadKey();
    }

    private static DateTime? GetDateTime()
    {
        DateTime date;
        var dateOptions = new Dictionary<string, DateTime>
            {
                { "Today", DateTime.Today },
                { "Yesterday", DateTime.Today.AddDays(-1) },
                { "Custom Date", DateTime.MinValue }
            };

        var datePrompt = new SelectionPrompt<string>()
            .Title("Select the date to log")
            .AddChoices(dateOptions.Keys);

        string choice = AnsiConsole.Prompt(datePrompt);

        if (choice == "Custom Date")
        {
            var yearOptions = new List<string>();
            for (int i = DateTime.Today.Year; i >= DateTime.Today.Year - 5; i--)
            {
                yearOptions.Add(i.ToString());
            }

            yearOptions.Add("Cancel");
            var yearPrompt = new SelectionPrompt<string>()
                .Title("Select the year")
                .AddChoices(yearOptions);
            string year = AnsiConsole.Prompt(yearPrompt);
            if (year == "Cancel")
            {
                return null;
            }

            Dictionary<string, int> monthOptions = new()
                {
                    { "Jan", 1},
                    {"Feb",  2},
                    {"Mar", 3},
                    {"Apr", 4},
                    {"May", 5},
                    {"Jun", 6},
                    {"Jul", 7},
                    {"Aug", 8},
                    {"Sep", 9},
                    {"Oct", 10},
                    {"Nov", 11},
                    {"Dec", 12},
                    { "Cancel", 0 }
                };
            var monthPrompt = new SelectionPrompt<string>()
                .Title("Select the month")
                .AddChoices(monthOptions.Keys);
            string month = AnsiConsole.Prompt(monthPrompt);
            if (month == "Cancel")
            {
                return null;
            }

            var daysInMonth = DateTime.DaysInMonth(int.Parse(year), monthOptions[month]);
            List<string> dayOptions = Enumerable.Range(1, daysInMonth).Select(day => day.ToString()).ToList();
            dayOptions.Add("Cancel");
            var dayPrompt = new SelectionPrompt<string>()
                .Title("Select the day")
                .AddChoices(dayOptions);
            string day = AnsiConsole.Prompt(dayPrompt);
            if (day == "Cancel")
            {
                return null;
            }

            date = new DateTime(int.Parse(year), monthOptions[month], int.Parse(day));
        }
        else
        {
            date = dateOptions[choice];
        }

        var timePrompt = new TextPrompt<string>("Enter the time to log (HH:mm) or 'c' to cancel: ")
            .Validate(input =>
            {
                if (input.Equals("c", StringComparison.CurrentCultureIgnoreCase))
                {
                    return ValidationResult.Success();
                }

                if (DateTime.TryParse(input, out DateTime time))
                {
                    return ValidationResult.Success();
                }

                return ValidationResult.Error("Invalid time format");
            });

        string time = AnsiConsole.Prompt(timePrompt);
        if (time.Equals("c", StringComparison.CurrentCultureIgnoreCase))
        {
            return null;
        }

        return date.Add(TimeSpan.Parse(time));
    }
}
