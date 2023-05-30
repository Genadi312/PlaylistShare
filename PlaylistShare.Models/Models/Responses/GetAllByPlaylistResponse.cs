using PlaylistShare.DL.Models;

namespace PlaylistShare.Models.Models.Responses
{
    public class GetAllByPlaylistResponse
    {
        public Playlist Playlist { get; set; }

        public IEnumerable<Song> Songs { get; set; }
    }
}
