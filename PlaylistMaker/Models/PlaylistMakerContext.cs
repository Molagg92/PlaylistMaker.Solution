using Microsoft.EntityFrameworkCore;

namespace PlaylistMaker.Models;

public class PlaylistMakerContext : DbContext
{
    public DbSet<Playlist> Playlists { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Song> Songs { get; set; }

    public DbSet<PlaylistSongEntity> PlaylistSongEntities { get; set; }

    public PlaylistMakerContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlaylistSongEntity>()
            .HasKey(ps => new { ps.PlaylistId, ps.SongId });
    }
}
