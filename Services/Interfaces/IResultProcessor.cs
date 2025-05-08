using DecathlonApp.Models;
using System.Collections.Generic;

namespace DecathlonApp.Services.Interfaces
{
    public interface IResultProcessor
    {
        List<Athlete> Process(List<Athlete> athletes);
    }
}