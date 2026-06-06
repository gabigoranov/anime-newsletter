using AnimeNewsletter.Data;
using AnimeNewsletter.Data.Models;
using AnimeNewsletter.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimeNewsletter.Services
{
    /// <summary>
    /// Service for managing user anime watchlist operations.
    /// </summary>
    public class UserAnimeService : IUserAnimeService
    {
        private readonly ApplicationDbContext _context;

        public UserAnimeService(ApplicationDbContext context)
        {
            _context = context;
        }

        private async Task AddAnimeAsync(Anime anime)
        {
            // Check if anime exists in the database
            var existingAnime = await _context.Anime
                .FirstOrDefaultAsync(a => a.Id == anime.Id);

            // If it doesn't exist, add it
            if (existingAnime == null)
            {
                _context.Anime.Add(anime);
                existingAnime = anime;
            }

            

            if (existingUserAnime == null)
            {
                var userAnime = new UserAnime
                {
                    UserEmail = userEmail,
                    AnimeId = anime.Id
                };

                _context.UserAnime.Add(userAnime);
                userAnimeList.Add(userAnime);
            }
        }

        /// <summary>
        /// Adds multiple anime to a user's watchlist in bulk.
        /// Creates anime entries in the database if they don't exist.
        /// </summary>
        public async Task<IEnumerable<UserAnime>> AddAnimeInBulkAsync(string userEmail, IEnumerable<Anime> animes)
        {
            // Verify that the user exists
            var userExists = await _context.Users
                .AnyAsync(u => u.Email == userEmail);

            if (!userExists)
                throw new ArgumentException($"User with email '{userEmail}' does not exist.");

            var userAnimeList = new List<UserAnime>();
            var animeList = animes.ToList();

            foreach (var anime in animeList)
            {
                await AddAnimeAsync(anime);
                // Check if the UserAnime entry already exists
                var existingUserAnime = await _context.UserAnime
                    .FirstOrDefaultAsync(ua => ua.UserEmail == userEmail && ua.AnimeId == animes.Id);

            }

            await _context.SaveChangesAsync();
            return userAnimeList;
        }

        /// <summary>
        /// Removes multiple anime from a user's watchlist in bulk.
        /// </summary>
        public async Task<int> RemoveAnimeInBulkAsync(string userEmail, IEnumerable<int> animeIds)
        {
            var userAnimes = await _context.UserAnime
                .Where(ua => ua.UserEmail == userEmail && animeIds.Contains(ua.AnimeId))
                .ToListAsync();

            _context.UserAnime.RemoveRange(userAnimes);
            await _context.SaveChangesAsync();

            return userAnimes.Count;
        }

        /// <summary>
        /// Retrieves all anime in a user's watchlist.
        /// </summary>
        public async Task<IEnumerable<UserAnime>> GetUserWatchlistAsync(string userEmail)
        {
            return await _context.UserAnime
                .Where(ua => ua.UserEmail == userEmail)
                .ToListAsync();
        }

        /// <summary>
        /// Clears all anime from a user's watchlist.
        /// </summary>
        public async Task<int> ClearWatchlistAsync(string userEmail)
        {
            // Verify that the user exists
            var userExists = await _context.Users
                .AnyAsync(u => u.Email == userEmail);

            if (!userExists)
            {
                throw new ArgumentException($"User with email '{userEmail}' does not exist.");
            }

            var userAnimes = await _context.UserAnime
                .Where(ua => ua.UserEmail == userEmail)
                .ToListAsync();

            _context.UserAnime.RemoveRange(userAnimes);
            await _context.SaveChangesAsync();

            return userAnimes.Count;
        }
    }
}
