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
    public class SongController : ControllerBase
    {
        private readonly ILogger<PlaylistController> _logger;
        private readonly ISongService _songService;

        public SongController(ILogger<PlaylistController> logger, ISongService songService)
        {
            _logger = logger;
            _songService = songService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetAllSongs")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _songService.GetAll();

            if (result != null && result.Any()) return Ok(result);

            return NotFound();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (id == null) return BadRequest(id);

            var result = await _songService.GetById(id);

            if (result != null) return Ok(result);

            return NotFound();

        }
        [HttpPost("Add")]
        [Authorize]
        public async Task Add([FromBody] AddSongRequest songRequest)
        {
            await _songService.Add(songRequest);
        }

        [HttpPost("Update")]
        [Authorize]
        public async Task Update([FromBody] UpdateSongRequest song)
        {
            await _songService.Update(song);
        }

        [HttpDelete("Delete")]
        [Authorize]
        public async Task Delete([FromBody] DeleteSongRequest id)
        {
            await _songService.Delete(id);
        }

    }
}