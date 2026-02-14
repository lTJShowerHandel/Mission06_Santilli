using System.ComponentModel.DataAnnotations;

namespace Mission06_Santilli.Models;

public class Movie
{
    [Key]
    [Required]
    public int MovieId { get; set; }

    [Required] // Category must be entered
    public string Category { get; set; }

    [Required] // Title must be entered
    public string Title { get; set; }

    [Required] // Year must be entered
    public int Year { get; set; }

    [Required] // Director must be entered
    public string Director { get; set; }

    [Required] // Rating must be entered
    public string Rating { get; set; }

    // NOT Required: Edited, LentTo, and Notes
    public bool Edited { get; set; } 
    public string? LentTo { get; set; }

    [StringLength(25)] // Requirement: Notes limited to 25 characters
    public string? Notes { get; set; }
}