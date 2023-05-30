using PlaylistShare.DL.Models;
using PlaylistShare.Models.Models.Requests.AddRequests;

namespace PlaylistShare.BL.Interfaces
{
    public interface IUserInfoService
    {
        public Task<UserInfo?> GetUserInfoAsync(string userName, string password);

        public Task Add(AddUserInfoRequest userInfo);
    }
}
