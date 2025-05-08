using DecathlonApp.Models;
using System;
using System.Collections.Generic;

namespace DecathlonApp.Services
{
    public class DecathlonCalculator
    {
        private readonly List<EventScore> _events = new List<EventScore>
        {
            new EventScore { EventName = "100m", ScoringConstantA = 25.4347, ScoringConstantB = 18, ScoringConstantC = 1.81, Unit = "Seconds", Type = "Track" },
            new EventScore { EventName = "LongJump", ScoringConstantA = 0.14354, ScoringConstantB = 220, ScoringConstantC = 1.4, Unit = "Centimeters", Type = "Jump" },
            new EventScore { EventName = "ShotPut", ScoringConstantA = 51.39, ScoringConstantB = 1.5, ScoringConstantC = 1.05, Unit = "Meters", Type = "Throw" },
            new EventScore { EventName = "HighJump", ScoringConstantA = 0.8465, ScoringConstantB = 75, ScoringConstantC = 1.42, Unit = "Centimeters", Type = "Jump" },
            new EventScore { EventName = "400m", ScoringConstantA = 1.53775, ScoringConstantB = 82, ScoringConstantC = 1.81, Unit = "Seconds", Type = "Track" },
            new EventScore { EventName = "110mHurdles", ScoringConstantA = 5.74352, ScoringConstantB = 28.5, ScoringConstantC = 1.92, Unit = "Seconds", Type = "Track" },
            new EventScore { EventName = "DiscusThrow", ScoringConstantA = 12.91, ScoringConstantB = 4, ScoringConstantC = 1.1, Unit = "Meters", Type = "Throw" },
            new EventScore { EventName = "PoleVault", ScoringConstantA = 0.2797, ScoringConstantB = 100, ScoringConstantC = 1.35, Unit = "Centimeters", Type = "Jump" },
            new EventScore { EventName = "JavelinThrow", ScoringConstantA = 10.14, ScoringConstantB = 7, ScoringConstantC = 1.08, Unit = "Meters", Type = "Throw" },
            new EventScore { EventName = "1500m", ScoringConstantA = 0.03768, ScoringConstantB = 480, ScoringConstantC = 1.85, Unit = "Seconds", Type = "Track" }
        };

        public int CalculateEventScore(EventScore eventScore, double result)
        {
            double value;
            switch (eventScore.Type)
            {
                case "Track":
                    value = eventScore.ScoringConstantB - result;
                    break;
                case "Jump":
                    value = result * (eventScore.Unit == "Centimeters" ? 1 : 100) - eventScore.ScoringConstantB;
                    break;
                case "Throw":
                    value = result - eventScore.ScoringConstantB;
                    break;
                default:
                    throw new ArgumentException("Invalid event type");
            }
            return (int)Math.Floor(eventScore.ScoringConstantA * Math.Pow(Math.Max(0, value), eventScore.ScoringConstantC));
        }

        public void CalculateScores(Athlete athlete)
        {
            athlete.EventScores = new List<int>();
            for (int i = 0; i < athlete.EventResults.Count; i++)
            {
                var score = CalculateEventScore(_events[i], athlete.EventResults[i]);
                athlete.EventScores.Add(score);
            }
            athlete.TotalScore = athlete.EventScores.Sum();
        }
    }
}