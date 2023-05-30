using MongoDB.Bson.Serialization.Attributes;

namespace PlaylistShare.DL.Models
{
    public class Song
    {
        [BsonId]
        [BsonElement("_id")]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Album { get; set; }

        public string Author { get; set; }

        public Guid PlaylistId{ get; set; }
    }
}
