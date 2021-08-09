using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using thinnr.Components;
using thinnr.Models;

namespace thinnr.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUrlRepository _repo;
        private readonly IUrlKeyConverter _keyConverter;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IUrlRepository repo, IUrlKeyConverter keyConverter, ILogger<HomeController> logger)
        {
            _repo = repo;
            _keyConverter = keyConverter;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("{key}")]
        public IActionResult UrlForward(string key)
        {
            try
            {
                int id = _keyConverter.GetIdFromKey(key);
                ShortenedUrl url = _repo.Load(id);
                return Redirect(url.OriginalUrl);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
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
