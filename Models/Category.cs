using System.ComponentModel.DataAnnotations;

namespace Mission7.Models;

public class Category
{
    [Key]
    [Required]
    public int CategoryId { get; set; } // Matches DB exactly
    
    [Required]
    public string CategoryName { get; set; } = "";
}