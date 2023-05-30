using AutoMapper;
using PlaylistShare.DL.Models;
using PlaylistShare.Models.Models.Requests.AddRequests;
using PlaylistShare.Models.Models.Requests.UpdateRequests;

namespace PlaylistShare.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<AddSongRequest, Song>();

            CreateMap<AddPlaylistRequest, Playlist>();

            CreateMap<UpdatePlaylistRequest, Playlist>();

            CreateMap<UpdateSongRequest, Song>();
        }
    }
}
