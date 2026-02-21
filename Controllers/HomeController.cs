using Microsoft.AspNetCore.Mvc;
using Mission7.Models; 
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            .Include(x => x.Category)
            .OrderBy(x => x.Title)
            .ToList();
        return View(movies);
    }
    

    [HttpPost]
    public IActionResult EnterMovie(Application response)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(response);
            _context.SaveChanges();
            return View("Confirmation", response);
        }
    
        // RE-FETCH CATEGORIES so the dropdown doesn't break if validation fails
        ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
        return View(response);
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
    
    [HttpGet]
    public IActionResult EnterMovie()
    {
        // Fetch categories from the DB to put in the dropdown
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();

        return View("EnterMovie", new Application());
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
    
        var recordToEdit = _context.Movies.Single(x => x.MovieId == id);
    
        return View("EnterMovie", recordToEdit);
    }
}