using PlaylistShare.Models.Models.Responses;

namespace PlaylistShare.BL.Interfaces
{
    public interface IMusicLibraryService
    {
        Task<GetAllByPlaylistResponse> GetAllSongsByPlaylistId(Guid playlistId);

        Task<GetAllPlaylistsBySong> GetAllPlaylistsBySongId(Guid songId);
    }
}
