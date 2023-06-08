using PlaylistShare.DL.Models;

namespace PlaylistShare.DL.Interfaces
{
    public interface IUserInfoRepository
    {
        Task<UserInfo?> GetUserInfoAsync(string userName, string password);

        Task Add(UserInfo user);

        Task<IEnumerable<UserInfo>> GetAll();

        Task Update(UserInfo userinfo);

    }
}
