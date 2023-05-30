using System.Globalization;
using PlaylistShare.DL.Models;

namespace PlaylistShare.DL.Interfaces
{
    public interface IPlaylistRepository
    {
        Task<IEnumerable<Playlist>> GetAll();

        Task<Playlist> GetById(Guid id);

        Task Add(Playlist playlist);

        Task Update(Playlist playlist);

        Task Delete(Guid id);

        Task<IEnumerable<Playlist>> GetAllPlaylistsBySong(Guid songId);

    }
}
