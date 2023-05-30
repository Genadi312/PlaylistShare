namespace PlaylistShare.Models.Models.Requests.AddRequests
{
    public class AddSongRequest
    {
        public string Title { get; set; }

        public string Album { get; set; }

        public string Author { get; set; }

        public Guid PlaylistId { get; set; }
    }
}
