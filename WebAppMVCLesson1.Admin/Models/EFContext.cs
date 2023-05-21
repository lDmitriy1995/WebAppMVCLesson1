﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace WebAppMVCLesson1.Admin.Models
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<EventCategory> EventCategories { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<EventCategory>().HasData
        //        (
        //        new EventCategory() { EventCategoryId = 6, Name = "CategoryName",Description = "test" }
        //        );
        //}
    }
}
