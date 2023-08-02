using System.ComponentModel.DataAnnotations;

namespace PlaylistMaker.Models;

public class Artist
{
    public int ArtistId { get; set; }
    [Required]
    [StringLength(45)]
    public string Name { get; set; }
    public List<Album> Albums { get; set; }

}