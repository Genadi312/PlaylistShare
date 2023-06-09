using MongoDB.Driver;
using PlaylistShare.Models.Configs;
using PlaylistShare.DL.Interfaces;
using PlaylistShare.DL.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;

namespace PlaylistShare.DL.Repositories.MongoDb
{
    public class UserInfoMongoRepository : IUserInfoRepository
    {
        private readonly IMongoCollection<UserInfo?> _userInfo;

        public UserInfoMongoRepository(IOptionsMonitor<MongoDbConfig> mongoConfig)
        {
            var client = new MongoClient(
                mongoConfig.CurrentValue.ConnectionString);
            var database = client.GetDatabase(mongoConfig.CurrentValue.DatabaseName);
            var collectionSettings = new MongoCollectionSettings
            {
                GuidRepresentation = GuidRepresentation.Standard
            };

            _userInfo = database.GetCollection<UserInfo>(nameof(UserInfo), collectionSettings);
        }

        public Task<UserInfo?> GetUserInfoAsync(string userName, string pasword)
        {
            var filterBuilder = Builders<UserInfo>.Filter;
            var filter = filterBuilder.Eq(entity => entity.Username, userName) & filterBuilder.Eq(entity => entity.Password, pasword);
            var item = _userInfo.Find(filter).FirstOrDefault();
            return Task.FromResult(item);
        }

        public async Task Add(UserInfo user)
        {
            await _userInfo.InsertOneAsync(user);
        }

        public async Task<IEnumerable<UserInfo>> GetAll()
        {
            return await _userInfo.Find(song => true).ToListAsync();
        }

        public async Task Update(UserInfo userinfo)
        {
            var filter = Builders<UserInfo>.Filter.Eq(u=>u.Id, userinfo.Id);
            var update = Builders<UserInfo>.Update.Set(u => u.Username, userinfo.Username)
                                                  .Set(u => u.Password, userinfo.Password);

            await _userInfo.UpdateOneAsync(filter, update);
        }
    }
}
