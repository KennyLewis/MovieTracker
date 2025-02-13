﻿using Microsoft.EntityFrameworkCore;
using MovieTracker.API.Movies;

namespace MovieTracker.API.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasIndex(x => x.YearOfRelease);
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
