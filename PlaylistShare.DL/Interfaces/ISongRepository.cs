using PlaylistShare.DL.Models;

namespace PlaylistShare.DL.Interfaces
{
    public interface ISongRepository
    {
        Task<IEnumerable<Song>> GetAll();

        Task<Song?> GetById(Guid id);

        Task Add(Song song);

        Task Update(Song song);

        Task Delete(Guid id);

        Task<IEnumerable<Song>> GetAllByPlaylistId(Guid playlistId);
    }
}
