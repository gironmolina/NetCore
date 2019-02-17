using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using NetCoreApp.Services;
using NetCoreApp.ViewModels;

namespace NetCoreApp.Controllers
{
    public class AppController : Controller
    {
        private readonly INullMailService _nullMailService;

        public AppController(INullMailService nullMailService)
        {
            _nullMailService = nullMailService;
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
    }
}
