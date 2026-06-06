using AnimeNewsletter.Data;
using AnimeNewsletter.Data.Models;
using AnimeNewsletter.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimeNewsletter.Services
{
    public class AnimeService : IAnimeService
    {
        private readonly ApplicationDbContext _context;
        private readonly N8NService _n8NService;
        private readonly IConfiguration _configuration;

        public AnimeService(ApplicationDbContext context, N8NService n8NService, IConfiguration config)
        {
            _context = context;
            _n8NService = n8NService;
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

        public async Task<IEnumerable<Anime>> ScanAnimeAsync()
        {
            string requestUrl = _configuration["ExternalServices:N8NScanAnimes"] ?? throw new Exception("Invalid External Service URL");
            var animeData = await _n8NService.TriggerGet(requestUrl); // Loaded animes with a new episode and the episode number

            // Group them by anime: anime - list of new episodes
            // For each user load their UserAnime
            // Check which ones have a new episode with the data we loaded and filtered
            // If a user has to be notified for smt ( based on the lastNotifiedEp in UserAnime ), send all their new episodes data to n8n to send an email

            throw new NotImplementedException();
        }
    }
}