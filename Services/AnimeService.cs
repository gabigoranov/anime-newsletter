using AnimeNewsletter.Data;
using AnimeNewsletter.Data.Models;
using AnimeNewsletter.Models;
using AnimeNewsletter.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace AnimeNewsletter.Services
{
    public class AnimeService : IAnimeService
    {
        private readonly ApplicationDbContext _context;
        private readonly N8NService _n8NService;
        private readonly INotificationService _notificationService;
        private readonly IUserAnimeService _userAnimeService;
        private readonly IConfiguration _configuration;

        public AnimeService(ApplicationDbContext context, N8NService n8NService, INotificationService notificationService, IUserAnimeService userAnimeService, IConfiguration config)
        {
            _context = context;
            _n8NService = n8NService;
            _notificationService = notificationService;
            _userAnimeService = userAnimeService;
            _configuration = config;
        }

        public async Task<IEnumerable<Anime>> GetAllAnimeAsync()
        {
            return await _context.Anime.ToListAsync();
        }

        public async Task<Anime?> GetAnimeByIdAsync(int id)
        {
            return await _context.Anime.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task ScanAnimeAsync()
        {
            string requestUrl = _configuration["ExternalServices:N8NScanAnimes"] ?? throw new Exception("Invalid External Service URL");
            var animeData = await _n8NService.TriggerGet(requestUrl);

            AnimeWithNewEpisode[]? animes = JsonSerializer.Deserialize<AnimeWithNewEpisode[]>(animeData, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if(animes == null || animes.Length == 0)
                return;

            // Get pending notifications grouped by user
            var notificationsGroupedByUser = await _notificationService.GetPendingNotificationsByUserAsync(animes);

            if (notificationsGroupedByUser.Count == 0)
                return;

            // Send newsletters to users
            await _notificationService.SendNewslettersAsync(notificationsGroupedByUser);

            // Update last notified episodes for all users
            await _userAnimeService.UpdateLastNotifiedEpisodesInBulkAsync(notificationsGroupedByUser);
        }
    }
}