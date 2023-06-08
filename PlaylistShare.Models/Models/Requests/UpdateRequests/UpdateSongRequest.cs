using MongoDB.Bson.Serialization.Attributes;

namespace PlaylistShare.Models.Models.Requests.UpdateRequests
{
    public class UpdateSongRequest
    {
        [BsonId]
        [BsonElement("_id")]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Album { get; set; }

        public string Author { get; set; }

        public Guid PlaylistId { get; set; }
    }
}
