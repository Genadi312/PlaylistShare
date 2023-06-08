using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlaylistShare.BL.Interfaces;
using PlaylistShare.DL.Models;
using PlaylistShare.Models.Models.Requests.AddRequests;
using PlaylistShare.Models.Models.Requests.DeleteRequests;
using PlaylistShare.Models.Models.Requests.UpdateRequests;

namespace PlaylistShare.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaylistController : ControllerBase
    {
        private readonly ILogger<PlaylistController> _logger;
        private readonly IPlaylistService _playlistService;

        public PlaylistController(ILogger<PlaylistController> logger, IPlaylistService playlistService)
        {
            _logger = logger;
            _playlistService = playlistService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetAllPlaylists")]
        public async Task<IEnumerable<Playlist>> GetAll()
        {
            return await _playlistService.GetAll();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetById")]
        public async Task<Playlist> GetById(Guid id)
        {
            return await _playlistService.GetById(id);
        }

        [HttpPost("Add")]
        [Authorize]
        public async Task Add([FromBody] AddPlaylistRequest playlistRequest)
        {
            await _playlistService.Add(playlistRequest);
        }

        [HttpPost("Update")]
        [Authorize]
        public async Task Update([FromBody] UpdatePlaylistRequest playlist)
        {
            await _playlistService.Update(playlist);
        }

        [HttpDelete("Delete")]
        [Authorize]
        public void Delete(DeletePlaylistRequest id)
        {
            _playlistService.Delete(id);
        }
    }
}
