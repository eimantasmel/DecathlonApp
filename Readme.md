# DecathlonApp

A simple ASP.NET Core MVC application to process Decathlon competition results from a CSV file and output a JSON file with calculated scores and rankings.

## Features

- Uploads a CSV file containing Decathlon athlete data (name and 10 event results).
- Parses the CSV, calculates event scores using IAAF Decathlon formulas, and computes total scores.
- Assigns places to athletes, handling ties (e.g., "3-4" for equal scores).
- Outputs a JSON file (`decathlon_results.json`) with sorted results, including event results, scores, total score, and place.
- Designed with extensibility for additional input sources (e.g., XML) and output formats (e.g., CSV).

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- A text editor or IDE (e.g., Visual Studio 2022, VS Code)
- A web browser (e.g., Chrome, Firefox)

## Start the application

``` dotnet run```
![Decathlon app fragment](https://i.snipboard.io/atJQT9.jpg)
![Decathlon app results fragment](https://i.snipboard.io/fKbhmR.jpg)
