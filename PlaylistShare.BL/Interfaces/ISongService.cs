using PlaylistShare.DL.Models;
using PlaylistShare.Models.Models.Requests.AddRequests;
using PlaylistShare.Models.Models.Requests.DeleteRequests;
using PlaylistShare.Models.Models.Requests.UpdateRequests;

namespace PlaylistShare.BL.Interfaces
{
    public interface ISongService
    {
        Task <IEnumerable<Song>> GetAll();

        Task <Song?> GetById(Guid id);

        Task Add(AddSongRequest song);

        Task Update(UpdateSongRequest song);

        Task Delete(DeleteSongRequest id);
        
    }
}
