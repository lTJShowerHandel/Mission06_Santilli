using Microsoft.EntityFrameworkCore;

namespace Mission7.Models;

public class mission7Context : DbContext
{
    public mission7Context(DbContextOptions<mission7Context> options) : base(options)//constructor
    {
    }
    
    public DbSet<Application> Movies { get; set; }
}