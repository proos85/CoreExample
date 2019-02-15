using System;
using System.Diagnostics;
using CoreExample.Core;
using CoreExample.Website.Extensions;
using Microsoft.AspNetCore.Mvc;
using CoreExample.Website.Models;
using CoreExample.Website.Services;

namespace CoreExample.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILoggingService _loggingService;
        private readonly ISuperHeroService _superHeroService;

        public HomeController(
            ILoggingService loggingService,
            ISuperHeroService superHeroService)
        {
            _loggingService = loggingService ?? throw new ArgumentNullException(nameof(loggingService));
            _superHeroService = superHeroService ?? throw new ArgumentNullException(nameof(superHeroService));
        }

        public IActionResult Index()
        {
            _loggingService.Write(nameof(Index));

            var vm = new HomeViewModel
            {
                SuperHeros = _superHeroService.GetSuperHeroes().ToViewModel()
            };

            return View(vm);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
