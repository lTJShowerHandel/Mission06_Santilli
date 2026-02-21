using System.ComponentModel.DataAnnotations;

namespace Mission7.Models; 

public class Application
{
    [Key]
    [Required]
    public int MovieId { get; set; } // PK is fine as Required

    [Required]
    public int CategoryId { get; set; } 

    public Category? Category { get; set; } 
    
    [Required]
    public string Title { get; set; } = "";

    // REMOVE [Required] here so the nulls in the DB don't crash the app
    [Range(1888, 2026, ErrorMessage = "Movies didn't exist before 1888!")] 
    public int? Year { get; set; }

    // REMOVE [Required] from these as well
    public string? Director { get; set; }

    public string? Rating { get; set; }

    [Required]
    public bool Edited { get; set; } 

    public string? LentTo { get; set; }

    [Required]
    public bool CopiedToPlex { get; set; } 

    [StringLength(25, ErrorMessage = "Notes must be 25 characters or less.")] 
    public string? Notes { get; set; }
}