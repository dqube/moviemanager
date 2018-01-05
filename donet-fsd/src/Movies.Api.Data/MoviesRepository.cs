using Microsoft.EntityFrameworkCore;
using Movies.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Api.Data
{
    public class MoviesRepository : IMoviesRepository
    {
        MoviesContext _context;

        public MoviesRepository(MoviesContext dbcontext)
        {
            _context = dbcontext;
            _context.Database.EnsureCreatedAsync();
        }
        public async Task<int> AddAsync(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return movie.MovieID;
        }

        public async Task DeleteAsync(int movieId)
        {
            var movie = await _context.Movies
               .SingleOrDefaultAsync(s => s.MovieID == movieId);

            if (movie != null)
            {
                _context.Movies
                    .Remove(movie);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<Movie> GetAsync(int movieId)
        {
            return await _context.Movies
                .Where(s => s.MovieID == movieId)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            //return await _context.Movies
            //    .Where(m =>
            //        (string.IsNullOrEmpty(filter) || (m.Title.Contains(filter) || m.Cast.Contains(filter) || m.Director.Contains(filter))))
            //    .OrderBy(s => s.Title)
            //    .Skip(pageSize * pageCount)
            //    .Take(pageSize)
            //    .ToListAsync();
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> UpdateAsync(Movie movie)
        {
            _context.Movies.Update(movie);

            await _context.SaveChangesAsync();
            return movie;
        }
    }
}
