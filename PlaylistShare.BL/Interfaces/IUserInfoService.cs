using PlaylistShare.DL.Models;
using PlaylistShare.Models.Models.Requests.AddRequests;
using PlaylistShare.Models.Models.Requests.UpdateRequests;

namespace PlaylistShare.BL.Interfaces
{
    public interface IUserInfoService
    {
        Task<UserInfo?> GetUserInfoAsync(string userName, string password);

        Task Add(AddUserInfoRequest userInfo);

        Task<IEnumerable<UserInfo>> GetAll();

        Task Update(UpdateUserInfoRequest user);
    }
}
