using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Movies.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Api.Data
{
   public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Movie>()
            .Property(f => f.MovieID)
            .ValueGeneratedOnAdd();

            base.OnModelCreating(builder);
        }
    }
}