namespace DecathlonApp.Models
{
    public class EventScore
    {
        public string EventName { get; set; }
        // Scoring constants for Decathlon formulas: Points = A * (B - Time)^C (Track) or A * (Distance - B)^C (Throw/Jump)
        public double ScoringConstantA { get; set; }
        public double ScoringConstantB { get; set; }
        public double ScoringConstantC { get; set; }
        public string Unit { get; set; } // E.g., "Seconds", "Meters", "Centimeters"
        public string Type { get; set; } // "Track", "Jump", "Throw"
    }
}