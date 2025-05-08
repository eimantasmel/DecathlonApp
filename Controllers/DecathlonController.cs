using DecathlonApp.Models;
using DecathlonApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace DecathlonApp.Controllers
{
    public class DecathlonController : Controller
    {
        private readonly IInputParser _inputParser;
        private readonly IResultProcessor _resultProcessor;
        private readonly IOutputFormatter _outputFormatter;

        public DecathlonController(
            IInputParser inputParser,
            IResultProcessor resultProcessor,
            IOutputFormatter outputFormatter)
        {
            _inputParser = inputParser;
            _resultProcessor = resultProcessor;
            _outputFormatter = outputFormatter;
        }

        public IActionResult Index()
        {
            return View(new UploadViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Upload(UploadViewModel model)
        {
            if (model.File == null || model.File.Length == 0)
            {
                ModelState.AddModelError("", "Please upload a valid CSV file.");
                return View("Index", model);
            }

            using var stream = new StreamReader(model.File.OpenReadStream());
            var input = await stream.ReadToEndAsync();

            var athletes = _inputParser.Parse(input);
            var processedAthletes = _resultProcessor.Process(athletes);
            var output = _outputFormatter.Format(processedAthletes);

            return File(System.Text.Encoding.UTF8.GetBytes(output), "application/json", "decathlon_results.json");
        }
    }
}