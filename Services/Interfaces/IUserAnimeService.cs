using AnimeNewsletter.Data.Models;

namespace AnimeNewsletter.Services.Interfaces
{
    /// <summary>
    /// Service for managing user anime watchlist operations.
    /// </summary>
    public interface IUserAnimeService
    {
        /// <summary>
        /// Adds multiple anime to a user's watchlist in bulk.
        /// Creates anime entries in the database if they don't exist.
        /// </summary>
        /// <param name="userEmail">The email address of the user.</param>
        /// <param name="anime">A collection of anime to add to the watchlist.</param>
        /// <returns>A collection of the added UserAnime entries.</returns>
        Task<IEnumerable<UserAnime>> AddAnimeInBulkAsync(string userEmail, IEnumerable<Anime> anime);

        /// <summary>
        /// Removes multiple anime from a user's watchlist in bulk.
        /// </summary>
        /// <param name="userEmail">The email address of the user.</param>
        /// <param name="animeIds">A collection of anime IDs to remove from the watchlist.</param>
        /// <returns>The number of anime removed from the watchlist.</returns>
        Task<int> RemoveAnimeInBulkAsync(string userEmail, IEnumerable<int> animeIds);

        /// <summary>
        /// Retrieves all anime in a user's watchlist.
        /// </summary>
        /// <param name="userEmail">The email address of the user.</param>
        /// <returns>A collection of UserAnime entries for the user.</returns>
        Task<IEnumerable<UserAnime>> GetUserWatchlistAsync(string userEmail);

        /// <summary>
        /// Clears all anime from a user's watchlist.
        /// </summary>
        /// <param name="userEmail">The email address of the user.</param>
        /// <returns>The number of anime removed from the watchlist.</returns>
        Task<int> ClearWatchlistAsync(string userEmail);
    }
}
