namespace AnimeNewsletter.Models
{
    /// <summary>
    /// Returned by n8n when scanning for new episodes
    /// </summary>
    public class AnimeWithNewEpisode
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Episode { get; set; }
    }
}
