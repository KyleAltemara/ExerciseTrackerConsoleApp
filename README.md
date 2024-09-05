# ExerciseTrackerConsoleApp

This is a console application that allows users to log and manage running exercises. The application uses a SQLite database to store and retrieve exercise data. Users can insert, delete, and view their running logs.
<https://www.thecsharpacademy.com/project/18/exercise-tracker>

## Features

- Connects to a local SQLite database specified in the `Program.cs` file.
- Contains models for the running exercises and a repository to manage the exercise data.
- Uses Entity Framework Core to interact with the database and create the necessary schema.
- Displays a menu with options to manage running logs or exit the application.
- Allows users to add, delete, and view running logs.
- Uses Spectre.Console to create a user-friendly console interface.

## Getting Started

To run the application, follow these steps:

1. Clone the repository to your local machine.
2. Open the solution in Visual Studio.
3. Build the solution to restore NuGet packages and compile the code.
4. Run the `ExerciseTrackerConsole` project to start the console application.

## Dependencies

- Microsoft.EntityFrameworkCore: The application uses this package to manage the database context and entity relationships.
- Spectre.Console: The application uses this package to create a user-friendly console interface.

## Usage

1. The application will display a menu with options to manage running logs or exit the application.
2. Select an option by using the arrow keys and press Enter.
3. Follow the prompts to perform the desired action.
4. The application will continue to run until you choose the "Exit" option.

## License

This project is licensed under the MIT License.

## Resources Used

- [The C# Academy](https://www.thecsharpacademy.com/)
- [Repository Pattern Docs](https://medium.com/@kerimkkara/implementing-the-repository-pattern-in-c-and-net-5fdd91950485)
- [Repository Pattern Tutorial](https://www.programmingwithwolfgang.com/repository-pattern-net-core/)
- [Dependency Injection Tutorial](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-usage)
- GitHub Copilot to generate code snippets.
