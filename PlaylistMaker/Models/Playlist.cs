namespace PlaylistMaker.Models;

public class Playlist
{
    public int PlaylistId { get; set; }
    public string Name { get; set; }
    public List<PlaylistSongEntity> PlaylistSongEntities { get; set; }

}