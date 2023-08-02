using System.ComponentModel.DataAnnotations;

namespace PlaylistMaker.Models;

public class Playlist
{
    public int PlaylistId { get; set; }
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    public List<PlaylistSongEntity> PlaylistSongEntities { get; set; }
}