using MongoDB.Bson.Serialization.Attributes;

namespace PlaylistShare.Models.Models.Requests.UpdateRequests
{
    public class UpdateUserInfoRequest
    {
        [BsonId]
        [BsonElement("_id")]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
