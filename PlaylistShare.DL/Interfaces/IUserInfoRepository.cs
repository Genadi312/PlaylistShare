using PlaylistShare.DL.Models;

namespace PlaylistShare.DL.Interfaces
{
    public interface IUserInfoRepository
    {
        public Task<UserInfo?> GetUserInfoAsync(string userName, string password);

        public Task Add(UserInfo user);
    }
}
