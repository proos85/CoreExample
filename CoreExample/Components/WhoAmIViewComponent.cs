using System;
using CoreExample.Core;
using Microsoft.AspNetCore.Mvc;

namespace CoreExample.Website.Components
{
    public class WhoAmIViewComponent: ViewComponent
    {
        private readonly ILoggingService _loggingService;

        public WhoAmIViewComponent(ILoggingService loggingService)
        {
            _loggingService = loggingService ?? throw new ArgumentNullException(nameof(loggingService));
        }

        public IViewComponentResult Invoke()
        {
            _loggingService.Write(nameof(WhoAmIViewComponent));
            return View();
        }
    }
}