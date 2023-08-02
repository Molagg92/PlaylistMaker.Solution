$(document).ready(function() {
    // This event fires when an 'Add to Playlist' button is clicked.
    $('.add-to-playlist').click(function() {
      // Get the ID of the song from the button's data-song-id attribute.
      var songId = $(this).data('song-id');
  
      // Store songId in a global variable or in the modal's data attributes.
      // This will allow the songId to be accessed in other event handlers.
      $('#playlistModal').data('song-id', songId);
  
      // Load playlists from your server.
      $.get('/playlists/getplaylists', function(data) {
        // Clear any previous playlists.
        $('#playlistList').empty();
        
        // Add each playlist to the modal.
        data.forEach(function(playlist) {
          // You might adjust this to fit your actual playlist data structure.
          var listItem = $('<li>');
          var playlistButton = $('<button>')
          .text(playlist.name)
          .attr('data-playlist-id', playlist.playlistId)
          .addClass('playlist-button');
          listItem.append(playlistButton);
          $('#playlistList').append(listItem);
        });
  
        // Show the modal.
        $('#playlistModal').modal('show');
      });
    });
  
    // This event fires when a playlist button in the modal is clicked.
    $(document).on('click', '.playlist-button', function() {
      // Get the ID of the playlist from the button's value.
      var playlistId = $(this).attr('data-playlist-id');
  
      // Get the song ID from where you stored it earlier...
      var songId = $('#playlistModal').data('song-id');
  
      // Send the song ID and playlist ID to your server.
      $.post('/playlists/addsongtoplaylist', { songId: songId, playlistId: playlistId }, function(data) {
        // Check if the server added the song to the playlist successfully...
        if (data.success) {
          // confirm add
          alert("Song was successfully added to the playlist.");
        }
      });
    });

    // Close button hides modal
    $('.close-modal-button').click(function() {
      $('#playlistModal').modal('hide');
    });
  });
  