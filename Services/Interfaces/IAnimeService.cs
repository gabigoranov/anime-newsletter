using AnimeNewsletter.Data.Models;

namespace AnimeNewsletter.Services.Interfaces
{
    /// <summary>
    /// Service for managing anime operations.
    /// </summary>
    public interface IAnimeService
    {
        /// <summary>
        /// Retrieves all anime from the database.
        /// </summary>
        /// <returns>A collection of all anime.</returns>
        Task<IEnumerable<Anime>> GetAllAnimeAsync();

        /// <summary>
        /// Retrieves an anime by its ID.
        /// </summary>
        /// <param name="id">The ID of the anime to retrieve.</param>
        /// <returns>The anime if found; otherwise null.</returns>
        Task<Anime?> GetAnimeByIdAsync(int id);

        /// <summary>
        /// Scans and updates the anime database with new entries.
        /// </summary>
        /// <returns>A collection of newly scanned or updated anime.</returns>
        Task<IEnumerable<Anime>> ScanAnimeAsync();
    }
}
