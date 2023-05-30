using PlaylistShare.DL.Models;

namespace PlaylistShare.Models.Models.Responses
{
    public class GetAllPlaylistsBySong
    {
        public Song Songs{ get; set; }

        public IEnumerable<Playlist> Playlists { get; set; }
    }
}
