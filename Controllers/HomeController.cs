using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ATM_project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            // client-app/build/index.html dosyasının yolunu alır
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "client-app", "build", "index.html");

            if (System.IO.File.Exists(filePath))
            {
                return PhysicalFile(filePath, "text/html");
            }

            return NotFound("Index.html dosyası bulunamadı.");
        }
    }
}
