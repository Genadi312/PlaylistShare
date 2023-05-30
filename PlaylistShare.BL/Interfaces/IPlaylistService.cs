using PlaylistShare.DL.Models;
using PlaylistShare.Models.Models.Requests.AddRequests;
using PlaylistShare.Models.Models.Requests.DeleteRequests;
using PlaylistShare.Models.Models.Requests.UpdateRequests;

namespace PlaylistShare.BL.Interfaces
{
    public interface IPlaylistService
    {
        Task<IEnumerable<Playlist>> GetAll();

        Task<Playlist> GetById(Guid id);

        Task Add(AddPlaylistRequest playlist);

        Task Update(UpdatePlaylistRequest playlist);

        Task Delete(DeletePlaylistRequest id);

    }
}
