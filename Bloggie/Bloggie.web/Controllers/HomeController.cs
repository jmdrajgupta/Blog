using Bloggie.web.Models; // Importing the namespace that contains the models used by the application, such as ErrorViewModel.
using Microsoft.AspNetCore.Mvc; // Importing the namespace for ASP.NET Core MVC, which provides the Controller class and IActionResult.
using System.Diagnostics; // Importing the namespace for diagnostic tools, including Activity, which is used for tracing.

namespace Bloggie.web.Controllers
{
    // The HomeController is responsible for handling requests to the main pages of the application, such as the home page and privacy page.
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; // Private field to hold a logger instance for logging purposes.

        // Constructor that accepts an ILogger instance, which is used for logging information, errors, or other messages.
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger; // Initializing the logger field with the injected logger instance.
        }

        // Action method for handling GET requests to the home page ("/" or "/Home/Index").
        public IActionResult Index()
        {
            return View(); // Returns the "Index" view to the user, which is typically the home page.
        }

        // Action method for handling GET requests to the privacy policy page ("/Home/Privacy").
        public IActionResult Privacy()
        {
            return View(); // Returns the "Privacy" view to the user, which typically displays the privacy policy.
        }

        // Action method for handling errors. It is decorated with the ResponseCache attribute to prevent caching of error responses.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Returns the "Error" view, passing an ErrorViewModel that contains the current RequestId or a trace identifier.
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
