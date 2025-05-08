using DecathlonApp.Models;
using DecathlonApp.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DecathlonApp.Services
{
    public class ResultProcessor : IResultProcessor
    {
        private readonly DecathlonCalculator _calculator;

        public ResultProcessor(DecathlonCalculator calculator)
        {
            _calculator = calculator;
        }

        public List<Athlete> Process(List<Athlete> athletes)
        {
            // Calculate scores
            foreach (var athlete in athletes)
            {
                _calculator.CalculateScores(athlete);
            }

            // Sort by total score (descending)
            var sortedAthletes = athletes.OrderByDescending(a => a.TotalScore).ToList();

            // Assign places, handling ties
            int currentPlace = 1;
            int i = 0;
            while (i < sortedAthletes.Count)
            {
                int sameScoreCount = 1;
                while (i + sameScoreCount < sortedAthletes.Count &&
                       sortedAthletes[i].TotalScore == sortedAthletes[i + sameScoreCount].TotalScore)
                {
                    sameScoreCount++;
                }

                string place = sameScoreCount == 1
                    ? currentPlace.ToString()
                    : $"{currentPlace}-{currentPlace + sameScoreCount - 1}";

                for (int j = i; j < i + sameScoreCount; j++)
                {
                    sortedAthletes[j].Place = place;
                }

                i += sameScoreCount;
                currentPlace += sameScoreCount;
            }

            return sortedAthletes;
        }
    }
}