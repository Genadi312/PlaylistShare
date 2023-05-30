using Microsoft.AspNetCore.Mvc;
using PlaylistShare.BL.Interfaces;
using PlaylistShare.Models.Models.Responses;

namespace PlaylistShare.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MusicLibraryController : ControllerBase
    {
        private readonly IMusicLibraryService _musicLibraryServices;
        public MusicLibraryController(IMusicLibraryService musicLibraryService)
        {
            _musicLibraryServices = musicLibraryService;
        }
        
        [HttpGet("GetAllSongsByPlaylist")]
        public async Task<GetAllByPlaylistResponse> GetAllSongsByPlaylistId(Guid playlistId)
        {
            return await _musicLibraryServices.GetAllSongsByPlaylistId(playlistId);
        }

        [HttpGet("GetAllPlaylistsBySong")]
        public async Task<GetAllPlaylistsBySong> GetAllPlaylistsBySongId(Guid songId)
        {
            return await _musicLibraryServices.GetAllPlaylistsBySongId(songId);
        }
    }
}
