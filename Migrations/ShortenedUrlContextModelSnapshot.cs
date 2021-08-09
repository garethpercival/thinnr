﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using thinnr.Components;

namespace thinnr.Migrations
{
    [DbContext(typeof(ShortenedUrlContext))]
    partial class ShortenedUrlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("thinnr.ShortenedUrl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Key")
                        .HasColumnType("TEXT");

                    b.Property<string>("OriginalUrl")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ShortenedUrls");
                });
#pragma warning restore 612, 618
        }
    }
}