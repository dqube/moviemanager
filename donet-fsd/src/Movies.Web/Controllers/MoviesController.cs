using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.ViewModel;
using Movies.Web.Services.Interfaces;

namespace Movies.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
      
        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var viewModel = await _movieService.GetMoviesAsync();
            return View(viewModel);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var viewModel = await _movieService.GetAsync(id);
            return View(viewModel);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        public async Task<IActionResult> Create(Movie movie)
        {
           
            try
            {
               var  viewmodel= await _movieService.AddAsync(movie);
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(movie);
            }
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var viewModel = await _movieService.GetAsync(id);
            return View(viewModel);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Movie movie)
        {
            try
            {
                await _movieService.UpdateAsync(movie);
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var viewModel = await _movieService.GetAsync(id);
            return View(viewModel);
        }

        // POST: Movies/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Movie movie)
        {
            try
            {
                // TODO: Add delete logic here
                await _movieService.DeleteAsync(movie.MovieID);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}