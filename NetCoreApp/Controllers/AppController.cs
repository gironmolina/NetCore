using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NetCoreApp.Data;
using NetCoreApp.Services;
using NetCoreApp.ViewModels;

namespace NetCoreApp.Controllers
{
    public class AppController : Controller
    {
        private readonly INullMailService _nullMailService;
        private readonly IDutchRepository _repository;

        public AppController(INullMailService nullMailService, IDutchRepository repository)
        {
            _nullMailService = nullMailService;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Send the email
                _nullMailService.SendMessage(
                    model.Email, 
                    model.Subject, 
                    $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }

        public IActionResult Shop()
        {
            var results = _repository.GetAllProducts();
            return View(results);
        }
    }
}
