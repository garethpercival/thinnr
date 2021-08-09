using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;

namespace thinnr.Components
{
    public class ShortenedUrlContext : DbContext
    {

        public DbSet<ShortenedUrl> ShortenedUrls { get; set; }
        public string DbPath { get; private set; }

        public ShortenedUrlContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}shortened.db"; 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlite($"Data Source={DbPath}");
        }
    }
}
