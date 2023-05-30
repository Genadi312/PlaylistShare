using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using PlaylistShare.DL.Interfaces;
using PlaylistShare.DL.Models;
using PlaylistShare.Models.Configs;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;

namespace PlaylistShare.DL.Repositories.MongoDb
{
    public class SongMongoRepository : ISongRepository
    {
        private readonly IMongoCollection<Song> _songs;

        public SongMongoRepository(IOptionsMonitor<MongoDbConfig> mongoConfig) 
        {
            var client = new MongoClient(mongoConfig.CurrentValue.ConnectionString);
            var database = client.GetDatabase(mongoConfig.CurrentValue.DatabaseName);
            var collectionSettings = new MongoCollectionSettings
            {
                GuidRepresentation = GuidRepresentation.Standard
            };

            _songs = database.GetCollection<Song>(nameof(Song), collectionSettings);
        }

        public async Task Add(Song song)
        {
            await _songs.InsertOneAsync(song);
        }

        public Task Delete (Guid id) 
        {
            return _songs.DeleteManyAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Song>> GetAll()
        {
            return await _songs.Find(song => true).ToListAsync();
        }

        public async Task<IEnumerable<Song>> GetAllByPlaylistId(Guid playlistId)
        {
            return await _songs.Find(x => x.PlaylistId == playlistId).ToListAsync();
        }

        public async Task<Song?> GetById(Guid id)
        {
            var item = await _songs
                .Find(Builders<Song>.Filter.Eq("_id", id))
                .FirstOrDefaultAsync();
            return item;
        }

        public async Task Update(Song song)
        {
            var filter = Builders<Song>.Filter.Eq(s => s.Id, song.Id);
            var update = Builders<Song>.Update.Set(s => s.Title, song.Title)
                                              .Set(s => s.Album, song.Album)
                                              .Set(s => s.Author, song.Author);
                                               
            await _songs.UpdateOneAsync(filter, update);
        }

    }
}
