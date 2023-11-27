using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMusic.Models;

public class Music
{
    public int Id { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string Title { get; set; } = string.Empty;

    // [Display(Name = "Release Date"),]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }


    public string Length { get; set; } = string.Empty;

    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [Required]
    [StringLength(30)]
    public string Genre { get; set; } = string.Empty;
    public int Rating { get; set; } 
}