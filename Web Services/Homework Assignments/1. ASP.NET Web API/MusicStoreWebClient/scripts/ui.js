var ui = (function () {

    function buildSongsList(songs) {

        var songsList = '<ul class="song-list">';
        for (var i = 0; i < songs.length; i++) {
            var song = songs[i];
            songsList +=
				'<li class="song" data-song-id="' + song.songId + '">' +
					'<a href="#">' +
						$("<div />").html(song.songTitle).text() +
					'</a>' +
					'<span> Year: ' +
						song.songYear +
					'</span>' +
                    '<span> Genre: ' +
						song.genre +
					'</span>' +
				'</li>';
        }

        songsList += "</ul>";
        return songsList;
    }

    return {
        getSongsList: buildSongsList
    };

}());