using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thinnr.Components;

namespace thinnr.Components
{
    public class UrlRepository : IUrlRepository
    {
        public UrlRepository()
        {
            //
        }

        public ShortenedUrl Save(string url)
        {
            using(ShortenedUrlContext db = new ShortenedUrlContext())
            {
                ShortenedUrl newUrl = new ShortenedUrl
                {
                    OriginalUrl = url
                };

                EntityEntry<ShortenedUrl> created = db.Add(newUrl);
                db.SaveChanges();
                return created.Entity;
            }
        }

        public ShortenedUrl Load(int id)
        {
            using (ShortenedUrlContext db = new ShortenedUrlContext())
            {
                ShortenedUrl url = db.Find<ShortenedUrl>(id);
                return url;
            }
        }
    }
}
