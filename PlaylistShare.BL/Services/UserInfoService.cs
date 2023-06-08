using AutoMapper;
using PlaylistShare.BL.Interfaces;
using PlaylistShare.DL.Interfaces;
using PlaylistShare.DL.Models;
using PlaylistShare.Models.Models.Requests.AddRequests;
using PlaylistShare.Models.Models.Requests.UpdateRequests;

namespace PlaylistShare.BL.Services
{
    public class UserInfoService : IUserInfoService
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;

        public UserInfoService(IUserInfoRepository userInfoRepository, IMapper mapper)
        {
            _userInfoRepository = userInfoRepository;
            _mapper = mapper;
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
        public async Task<IEnumerable<UserInfo>> GetAll()
        {
            return await _userInfoRepository.GetAll();
        }

        public async Task Update(UpdateUserInfoRequest userInfo)
        {
            var user = _mapper.Map<UserInfo>(userInfo);

            await _userInfoRepository.Update(user);
        }
    }

}
