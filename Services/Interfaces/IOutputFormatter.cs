using DecathlonApp.Models;
using System.Collections.Generic;

namespace DecathlonApp.Services.Interfaces
{
    public interface IOutputFormatter
    {
        string Format(List<Athlete> athletes);
    }
}