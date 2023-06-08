using Microsoft.Extensions.Logging;
using PlaylistShare.BL.Interfaces;
using PlaylistShare.DL.Interfaces;
using PlaylistShare.DL.Models;
using PlaylistShare.Models.Models.Responses;

namespace PlaylistShare.BL.Services
{
    public class MusicLibraryService : IMusicLibraryService
    {
        private readonly ISongRepository _songRepository;
        private readonly IPlaylistRepository _playlistRepository;
        private readonly ILogger<MusicLibraryService> _logger;

        public MusicLibraryService(IPlaylistRepository playlistRepository, ISongRepository songRepository, ILogger<MusicLibraryService> logger)
        {
            _songRepository = songRepository;
            _playlistRepository = playlistRepository;
            _logger = logger;
        }
        public async Task<GetAllByPlaylistResponse> GetAllSongsByPlaylistId(Guid playlistId)
        {
            var playlist = await _playlistRepository.GetById(playlistId);
            var song = Enumerable.Empty<Song>();

            if (playlist != null)
            {
                _logger.LogError($"GetAllSongsByPlaylistNumber error");
                song = await _songRepository.GetAllByPlaylistId(playlistId);
            }

            return new GetAllByPlaylistResponse()
            {
                Playlist = playlist,
                Songs = song
            };
        }

        public async Task<GetAllPlaylistsBySong> GetAllPlaylistsBySongId(Guid songId)
        {

            var song = await _songRepository.GetById(songId);
            var playlist = Enumerable.Empty<Playlist>();

            if (song != null)
            {
                _logger.LogError($"GetAllPlaylistsBySong error");
                playlist = await _playlistRepository.GetAllPlaylistsBySong(songId);
            }

            return new GetAllPlaylistsBySong()
            {
                Songs = song,
                Playlists = playlist
            };
        }
    }

}
