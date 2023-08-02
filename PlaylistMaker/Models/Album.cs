using System.ComponentModel.DataAnnotations;

namespace PlaylistMaker.Models;

public class Album
{
    public int AlbumId { get; set; }
    [Required]
    [StringLength(45)]
    public string Title { get; set; }
    [Required]
    public int ArtistId { get; set; }
    public Artist Artist { get; set; }
    public List<Song> Songs { get; set; }
}