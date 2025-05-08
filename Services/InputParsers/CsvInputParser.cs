using DecathlonApp.Models;
using DecathlonApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DecathlonApp.Services.InputParsers
{
    public class CsvInputParser : IInputParser
    {
        public List<Athlete> Parse(string input)
        {
            var athletes = new List<Athlete>();
            var lines = input.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length != 11) continue; // Expect name + 10 events

                var athlete = new Athlete
                {
                    Name = parts[0],
                    EventResults = new List<double>()
                };

                // Parse event results, converting times like "5.25.72" to seconds
                for (int i = 1; i < parts.Length; i++)
                {
                    if (parts[i].Contains("."))
                    {
                        // Handle time format (e.g., "5.25.72" or "12.61")
                        var timeParts = parts[i].Split('.');
                        double seconds = double.Parse(timeParts[0]);
                        if (timeParts.Length > 1)
                            seconds += double.Parse(timeParts[1]) / (timeParts[1].Length == 2 ? 100 : 1000);
                        athlete.EventResults.Add(seconds);
                    }
                    else
                    {
                        // Handle distance (e.g., "5" or "9.22")
                        athlete.EventResults.Add(double.Parse(parts[i]));
                    }
                }

                athletes.Add(athlete);
            }

            return athletes;
        }
    }
}