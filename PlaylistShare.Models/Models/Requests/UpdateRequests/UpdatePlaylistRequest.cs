namespace PlaylistShare.Models.Models.Requests.UpdateRequests
{
    public class UpdatePlaylistRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

    }
}
