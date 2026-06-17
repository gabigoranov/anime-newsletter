using System.ComponentModel.DataAnnotations;

namespace AnimeNewsletter.Data.Models
{
    /// <summary>
    /// Represents an anime in the database.
    /// </summary>
    public class Anime
    {
        /// <summary>
        /// Gets or sets the anime's title.
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the anime's ID (MyAnimeList ID, primary key).
        /// </summary>
        [Key]
        public int Id { get; set; }

        public virtual List<User> Users { get; set; } = new List<User>();
    }
}
