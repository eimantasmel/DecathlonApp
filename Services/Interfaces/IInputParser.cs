using DecathlonApp.Models;
using System.Collections.Generic;

namespace DecathlonApp.Services.Interfaces
{
    public interface IInputParser
    {
        List<Athlete> Parse(string input);
    }
}