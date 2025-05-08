using Microsoft.AspNetCore.Http;

namespace DecathlonApp.Models
{
    public class UploadViewModel
    {
        public IFormFile File { get; set; }
    }
}