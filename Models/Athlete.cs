namespace DecathlonApp.Models
{
    public class Athlete
    {
        public string Name { get; set; }
        public List<double> EventResults { get; set; } // Raw results for 10 events
        public List<int> EventScores { get; set; } // Calculated scores
        public int TotalScore { get; set; }
        public string Place { get; set; } // E.g., "1", "3-4"
    }
}