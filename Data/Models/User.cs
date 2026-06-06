using System.ComponentModel.DataAnnotations;

namespace AnimeNewsletter.Data.Models
{
    /// <summary>
    /// Represents a user in the anime newsletter system.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the user's username.
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the user's email address (primary key).
        /// </summary>
        [Key]
        [EmailAddress]
        public string Email { get; set; }
    }
}
