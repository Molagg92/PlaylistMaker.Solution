using System.ComponentModel.DataAnnotations;
namespace PlaylistMaker.Models;

public class Song
{
    public int SongId { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public int AlbumId { get; set; }
    public Album Album { get; set; }
    public List<PlaylistSongEntity> PlaylistSongEntities { get; set; }
}