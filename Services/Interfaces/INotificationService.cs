using AnimeNewsletter.Data.Models;
using AnimeNewsletter.Models;

namespace AnimeNewsletter.Services.Interfaces
{
    /// <summary>
    /// Service for managing user notifications and tracking notification state.
    /// </summary>
    public interface INotificationService
    {
        /// <summary>
        /// Gets pending notifications grouped by user email.
        /// Only includes anime where the user hasn't been notified about the latest episode.
        /// </summary>
        /// <param name="newEpisodes">Collection of anime with new episodes.</param>
        /// <returns>Dictionary of user email to list of anime they should be notified about.</returns>
        Task<Dictionary<string, List<AnimeWithNewEpisode>>> GetPendingNotificationsByUserAsync(
            IEnumerable<AnimeWithNewEpisode> newEpisodes);

        Task SendNewslettersAsync(Dictionary<string, List<AnimeWithNewEpisode>> notificationsByUser);

    }
}
