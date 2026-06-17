using AnimeNewsletter.Data;
using AnimeNewsletter.Data.Models;
using AnimeNewsletter.Models;
using AnimeNewsletter.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimeNewsletter.Services
{
    /// <summary>
    /// Service for managing user notifications and tracking notification state.
    /// </summary>
    public class NotificationService : INotificationService
    {
        private readonly ApplicationDbContext _context;
        private readonly N8NService _n8NService;
        private readonly IConfiguration _configuration;

        public NotificationService(ApplicationDbContext context, N8NService n8NService, IConfiguration configuration)
        {
            _context = context;
            _n8NService = n8NService;
            _configuration = configuration;
        }

        /// <summary>
        /// Gets pending notifications grouped by user email.
        /// Only includes anime where the user hasn't been notified about the latest episode.
        /// </summary>
        public async Task<Dictionary<string, List<AnimeWithNewEpisode>>> GetPendingNotificationsByUserAsync(
            IEnumerable<AnimeWithNewEpisode> newEpisodes)
        {
            if (newEpisodes == null || !newEpisodes.Any())
            {
                return new Dictionary<string, List<AnimeWithNewEpisode>>();
            }

            // Map anime IDs to their latest episode numbers for quick lookup
            var episodeLookup = newEpisodes.ToDictionary(a => a.Id, a => a.Episode);
            var animeIds = episodeLookup.Keys.ToList();

            // Fetch all relevant user records in ONE database hit
            var userAnimes = await _context.UserAnime
                .Where(ua => animeIds.Contains(ua.AnimeId))
                .ToListAsync();

            // Filter and group the results entirely in memory
            var notificationsGroupedByUser = userAnimes
                .Where(ua => ua.LastNotifiedEpisode < episodeLookup[ua.AnimeId])
                .GroupBy(ua => ua.UserEmail)
                .ToDictionary(
                    group => group.Key,
                    group => group.Select(ua => newEpisodes.First(e => e.Id == ua.AnimeId)).ToList()
                );

            return notificationsGroupedByUser;
        }

        public async Task SendNewslettersAsync(Dictionary<string, List<AnimeWithNewEpisode>> notificationsByUser)
        {
            string requestUrl = _configuration["ExternalServices:N8NSendNews"] ?? throw new Exception("Invalid External Service URL");
            await _n8NService.TriggerPost(notificationsByUser, requestUrl);
        }
    }
}
