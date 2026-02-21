

using System.ComponentModel.DataAnnotations;

namespace Mission7.Models; 

public class Application
{
    [Key]
    [Required]
    public int MovieId { get; set; } // Primary Key

    [Required]
    public string Category { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    [Range(1888, 2026, ErrorMessage = "Movies didn't exist before 1888!")] // Requirement: 1888 Limit
    public int Year { get; set; }

    [Required]
    public string Director { get; set; }

    [Required]
    public string Rating { get; set; }

    [Required]
    public bool Edited { get; set; } // Requirement: Yes/No (bool)

    public string? LentTo { get; set; }

    [Required]
    public bool CopiedToPlex { get; set; } // New requirement for Mission #7

    [StringLength(25, ErrorMessage = "Notes must be 25 characters or less.")] // Requirement: 25 char limit
    public string? Notes { get; set; }
}