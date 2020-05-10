using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PromTrial.Infrastructure;
using PromTrial.Models;

namespace PromTrial.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppMetrics _appMetrics;

        public HomeController(ILogger<HomeController> logger,
                              AppMetrics appMetrics)
        {
            _logger = logger;
            _appMetrics = appMetrics;
        }

        public async Task<IActionResult> Index([FromQuery] int pause = 0,
                                               [FromQuery] int listSize = 1000)
        {
            // Force request to allocate memory
            var dummyDatas = new List<string>();
            for (var i = 0; i < listSize; i++)
            {
                var dummyString = new string("foo, bar, baz");
                dummyDatas.Add(dummyString);
            }

            // Increment the custom counter
            _appMetrics.AllocatedStringsCounter.Inc(listSize);

            // Force request to take some time
            if (pause > 0)
            {
                await Task.Delay(pause);
            }

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
