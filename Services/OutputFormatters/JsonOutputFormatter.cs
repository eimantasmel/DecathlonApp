using DecathlonApp.Models;
using DecathlonApp.Services.Interfaces;
using System.Collections.Generic;
using System.Text.Json;

namespace DecathlonApp.Services.OutputFormatters
{
    public class JsonOutputFormatter : IOutputFormatter
    {
        public string Format(List<Athlete> athletes)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            return JsonSerializer.Serialize(athletes, options);
        }
    }
}