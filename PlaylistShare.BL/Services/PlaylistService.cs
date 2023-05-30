using AutoMapper;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using PlaylistShare.BL.Interfaces;
using PlaylistShare.DL.Interfaces;
using PlaylistShare.DL.Models;
using PlaylistShare.Models.Models.Requests.AddRequests;
using PlaylistShare.Models.Models.Requests.DeleteRequests;
using PlaylistShare.Models.Models.Requests.UpdateRequests;

namespace PlaylistShare.BL.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IMapper _mapper;
        public PlaylistService(IPlaylistRepository playlistRepository, IMapper mapper)
        {
            _playlistRepository = playlistRepository;
            _mapper = mapper;
        }

        public async Task Add(AddPlaylistRequest playlistRequest)
        {
            var playlist = _mapper.Map<Playlist>(playlistRequest);
            playlist.Id = Guid.NewGuid();
            await _playlistRepository.Add(playlist);
        }

        public async Task Delete(DeletePlaylistRequest deleteId)
        {
            await _playlistRepository.Delete(deleteId.Id);
        }

        public async Task<IEnumerable<Playlist>> GetAll()
        {
            return await _playlistRepository.GetAll();
        }

        public async Task<Playlist> GetById(Guid id)
        {
            return await _playlistRepository.GetById(id);
        }

        public async Task Update(UpdatePlaylistRequest playlistRequest)
        {
            var playlist = _mapper.Map<Playlist>(playlistRequest);

            await _playlistRepository.Update(playlist);
        }
    }
}
