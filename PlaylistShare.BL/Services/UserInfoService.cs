using PlaylistShare.BL.Interfaces;
using PlaylistShare.DL.Interfaces;
using PlaylistShare.DL.Models;
using PlaylistShare.Models.Models.Requests.AddRequests;

namespace PlaylistShare.BL.Services
{
    public class UserInfoService : IUserInfoService
        {
            private readonly IUserInfoRepository _userInfoRepository;

            public UserInfoService(IUserInfoRepository userInfoRepository)
            {
                _userInfoRepository = userInfoRepository;
            }

            public async Task Add(AddUserInfoRequest userInfo)
            {
                await _userInfoRepository.Add(new UserInfo()
                {
                    Id = Guid.NewGuid(),
                    Username = userInfo.Email,
                    Password = userInfo.Password,
                });
            }


            public Task<UserInfo?> GetUserInfoAsync(string userName, string password)
            {
                return _userInfoRepository.GetUserInfoAsync(userName, password);
            }
        }
    
}
