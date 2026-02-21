using Microsoft.AspNetCore.Mvc;
using Mission7.Models; // Updated Namespace
using System.Linq;

namespace Mission7.Controllers;

public class HomeController : Controller
{
    private mission7Context _context;

    public HomeController(mission7Context temp) // Constructor for context
    {
        _context = temp;
    }

    public IActionResult Index() => View();

    // READ: Display full collection
    public IActionResult MovieList()
    {
        var movies = _context.Movies
            .OrderBy(x => x.Title)
            .ToList();
        return View(movies);
    }

    [HttpGet]
    public IActionResult EnterMovie() => View("EnterMovie", new Application());

    [HttpPost]
    public IActionResult EnterMovie(Application response)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(response);
            _context.SaveChanges();
            return View("Confirmation", response);
        }
        return View(response);
    }

    // UPDATE: GET
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Movies.Single(x => x.MovieId == id);
        return View("EnterMovie", recordToEdit); // Reuses the form view
    }

    // UPDATE: POST
    [HttpPost]
    public IActionResult Edit(Application updatedInfo)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Update(updatedInfo);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }
        return View("EnterMovie", updatedInfo);
    }

    // DELETE: Logic
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies.Single(x => x.MovieId == id);
        return View(recordToDelete);
    }

    [HttpPost]
    public IActionResult Delete(Application mov)
    {
        _context.Movies.Remove(mov);
        _context.SaveChanges();
        return RedirectToAction("MovieList");
    }
}