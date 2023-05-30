using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using PlaylistShare.DL.Interfaces;
using PlaylistShare.DL.Models;
using PlaylistShare.Models.Configs;

namespace PlaylistShare.DL.Repositories.MongoDb
{
    public class PlaylistMongoRepository : IPlaylistRepository
    {
        private readonly IMongoCollection<Playlist> _playlists;

        public PlaylistMongoRepository(IOptionsMonitor<MongoDbConfig> mongoConfig)
        {
            var client = new MongoClient(mongoConfig.CurrentValue.ConnectionString);
            var database = client.GetDatabase(mongoConfig.CurrentValue.DatabaseName);
            var collectionSettings = new MongoCollectionSettings
            {
                GuidRepresentation = GuidRepresentation.Standard
            };

            _playlists = database.GetCollection<Playlist>(nameof(Playlist), collectionSettings);
        }

        public async Task Add(Playlist playlist)
        {
            await _playlists.InsertOneAsync(playlist);
        }

        public Task Delete(Guid id)
        {
            return _playlists.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Playlist>> GetAll()
        {
            return await _playlists.Find(author => true).ToListAsync();
        }

        public async Task<Playlist> GetById(Guid id)
        {
            var item = await _playlists
                .Find(Builders<Playlist>.Filter.Eq("_id", id))
                .FirstOrDefaultAsync();
            return item;
        }

        public async Task Update(Playlist playlist)
        {
            var filter = Builders<Playlist>.Filter.Eq(p => p.Id, playlist.Id);
            var update = Builders<Playlist>.Update.Set(p => p.Description, playlist.Description)
                                                  .Set(p => p.Name , playlist.Name);
            await _playlists.UpdateOneAsync(filter, update);
        }

        public async Task<IEnumerable<Playlist>> GetAllPlaylistsBySong(Guid songId)
        {
            return await _playlists.Find(x => x.Id == songId).ToListAsync();
        }
    }
}
