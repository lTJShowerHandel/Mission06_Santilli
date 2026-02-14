using Microsoft.AspNetCore.Mvc;
using Mission06_Santilli.Models;

namespace Mission06_Santilli.Controllers;

public class HomeController : Controller
{
    private MovieContext _context;

    // Constructor to "inject" the database context
    public HomeController(MovieContext temp)
    {
        _context = temp;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AboutJoel()
    {
        return View();
    }

    // GET method to display the form
    [HttpGet]
    public IActionResult EnterMovie()
    {
        return View();
    }

    // POST method to receive and save the form data
    [HttpPost]
    public IActionResult EnterMovie(Movie response)
    {
        if (ModelState.IsValid) // Check if data meets requirements (like the 25-char limit)
        {
            _context.Movies.Add(response); // Add the record to the local list
            _context.SaveChanges(); // Save the record to the SQLite database
            
            return View("Confirmation", response); // Send them to a confirmation page
        }
        else // If validation fails, stay on the same page and show errors
        {
            return View(response);
        }
    }
}