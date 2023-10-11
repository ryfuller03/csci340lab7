using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models;

public class Videogame
{
    public int id { get; set; }
    public string? Title { get; set; }
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    public string? Genre { get; set; }
    public string? Rating { get; set; }
    public string? Platform { get; set; }
}