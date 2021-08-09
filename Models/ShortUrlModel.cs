using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace thinnr.Models
{
    public class ShortUrlModel
    {
        public ShortUrlModel(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public ShortUrlModel(ShortenedUrl shortenedUrl, string key, string hostName)
        {
            ShortUrl = shortenedUrl;
            Key = key;
            HostName = hostName;
        }

        public string Key { get; set; }
        public string HostName { get; set; }
        public ShortenedUrl ShortUrl { get; set; }
        public string ErrorMessage { get; }
    }
}
