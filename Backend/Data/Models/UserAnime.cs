namespace AnimeNewsletter.Data.Models
{
    /// <summary>
    /// Represents the relationship between a user and an anime in their watchlist.
    /// </summary>
    public class UserAnime
    {
        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// Gets or sets the ID of the anime.
        /// </summary>
        public int AnimeId { get; set; }

        public int LastNotifiedEpisode { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the User.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the Anime.
        /// </summary>
        public Anime Anime { get; set; }
    }
}
