namespace PlaylistMaker.Models;

public class Song
{
    public int SongId { get; set; }
    public string Title { get; set; }
    public int AlbumId { get; set; }
    public Album Album { get; set; }
    public List<PlaylistSongEntity> PlaylistSongEntities { get; set; }
}