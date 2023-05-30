using AutoMapper;
using PlaylistShare.BL.Interfaces;
using PlaylistShare.DL.Interfaces;
using PlaylistShare.DL.Models;
using PlaylistShare.Models.Models.Requests.AddRequests;
using PlaylistShare.Models.Models.Requests.DeleteRequests;
using PlaylistShare.Models.Models.Requests.UpdateRequests;

namespace PlaylistShare.BL.Services
{
    public class SongService : ISongService
    {
        public readonly ISongRepository _songRepository;
        private readonly IMapper _mapper;

        public SongService(ISongRepository songRepository, IMapper mapper)
        {
            _songRepository= songRepository;
            _mapper = mapper;
        }

        public async Task Add(AddSongRequest songRequest)
        {
            var song = _mapper.Map<Song>(songRequest);
            song.Id = Guid.NewGuid();
            await _songRepository.Add(song);
        }

        public async Task<Song?> GetById(Guid id)
        {

            var result = await _songRepository.GetById(id);

            if (result != null)
            {
                result.Title = $"!{result.Title}";
            }
            return result;
        }

        public async Task<IEnumerable<Song>> GetAll()
        {
            return await _songRepository.GetAll();
        }

        public async Task Update(UpdateSongRequest songRequest)
        {
            var song = _mapper.Map<Song>(songRequest);

            await _songRepository.Update(song);
        }

        public async Task Delete(DeleteSongRequest idDelete)
        {
            await _songRepository.Delete(idDelete.Id);
        }

    }
}
