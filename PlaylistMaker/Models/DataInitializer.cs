// using Microsoft.Extensions.DependencyInjection;
// using System;
// using System.Linq;
// using System.Collections.Generic;

// namespace PlaylistMaker.Models;

// public class DataInitializer
// {
//     public static void InitializeData(WebApplication app)
//     {
//         using (var scope = app.Services.CreateScope())
//         {
//             var context = scope.ServiceProvider.GetRequiredService<PlaylistMakerContext>();
//             context.Database.Migrate();

//             if (!context.Artists.Any())
//             {
//                 var artists = new List<Artist>();
//                 for (int i = 1; i <= 5; i++)
//                 {
//                     var artist = new Artist
//                     {
//                         Name = $"Artist {i}",
//                         Albums = new List<Album>()
//                     };

//                     for (int j = 1; j <= 3; j++)
//                     {
//                         var album = new Album
//                         {
//                             Title = $"Album {j} of Artist {i}",
//                             Songs = new List<Song>(),
//                             Artist = artist
//                         };

//                         var songCount = new Random().Next(5, 13);
//                         for (int k = 1; k <= songCount; k++)
//                         {
//                             var song = new Song
//                             {
//                                 Title = $"Song {k} of Album {j} of Artist {i}",
//                                 Album = album
//                             };
//                             album.Songs.Add(song);
//                         }

//                         artist.Albums.Add(album);
//                     }

//                     artists.Add(artist);
//                 }

//                 context.Artists.AddRange(artists);
//                 context.SaveChanges();

//                 var playlists = new List<Playlist>();
//                 for (int i = 1; i <= 5; i++)
//                 {
//                     var playlist = new Playlist
//                     {
//                         Name = $"Unique Playlist {i}",
//                         PlaylistSongEntities = new List<PlaylistSongEntity>()
//                     };

//                     var allSongs = context.Songs.ToList();
//                     var randomSongs = allSongs.OrderBy(x => Guid.NewGuid()).Take(new Random().Next(10, 21));

//                     foreach (var song in randomSongs)
//                     {
//                         playlist.PlaylistSongEntities.Add(new PlaylistSongEntity
//                         {
//                             Song = song,
//                             Playlist = playlist
//                         });
//                     }

//                     playlists.Add(playlist);
//                 }

//                 context.Playlists.AddRange(playlists);
//                 context.SaveChanges();
//             }
//         }
//     }
// }
