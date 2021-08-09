using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thinnr.Components;
using thinnr.Models;

namespace thinnr.Controllers
{
    public class EncodeController : Controller
    {
        private readonly IUrlRepository _repo;
        private readonly IUrlKeyConverter _keyConverter;
        private readonly ILogger<EncodeController> _logger;

        public EncodeController(IUrlRepository repo, IUrlKeyConverter keyConverter, ILogger<EncodeController> logger)
        {
            this._repo = repo;
            this._keyConverter = keyConverter;
            this._logger = logger;
        }

        public IActionResult Index(string url)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(url))
                {
                    throw new Exception("No URL provided");
                }

                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    throw new Exception("URL must start with http:// or https://");
                }

                ShortUrlModel model = GenerateModel(url);
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        private ShortUrlModel GenerateModel(string url)
        {
            ShortenedUrl savedUrl = _repo.Save(url);
            string key = _keyConverter.GetKeyFromId(savedUrl.Id);

            string currentUrl = UriHelper.GetDisplayUrl(HttpContext.Request);
            Uri currentUri = new Uri(currentUrl);
            string hostName = currentUri.Scheme + "://" + currentUri.Host + ":" + currentUri.Port;

            ShortUrlModel model = new ShortUrlModel(savedUrl, key, hostName);
            return model;
        }
    }
}
