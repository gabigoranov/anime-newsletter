using AnimeNewsletter.Data;
using AnimeNewsletter.Data.Models;
using AnimeNewsletter.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;

namespace AnimeNewsletter.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly N8NService _n8NService;
        private readonly IUserAnimeService _userAnimeService;

        public UserService(ApplicationDbContext context, N8NService n8NService, IUserAnimeService userAnimeService)
        {
            _context = context;
            this._n8NService = n8NService;
            _userAnimeService = userAnimeService;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> UpdateUserAsync(string email, User user)
        {
            var existingUser = await GetUserByEmailAsync(email);
            if (existingUser == null)
                return null;

            existingUser.Username = user.Username;
            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task<bool> DeleteUserAsync(string email)
        {
            var user = await GetUserByEmailAsync(email);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Updates a user's anime watchlist by fetching from MyAnimeList API.
        /// Retrieves anime with "watching" status and syncs with the database.
        /// </summary>
        public async Task<IEnumerable<UserAnime>> UpdateUserWatchlistAsync(string userEmail, string username)
        {
            string body = await _n8NService.TriggerGet($"webhook-test/user/watchlist?username={username}");
            Anime[]? currentWatchlist = JsonSerializer.Deserialize<Anime[]>(body, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            // Clear in all cases
            await _userAnimeService.ClearWatchlistAsync(userEmail);

            if (currentWatchlist != null && currentWatchlist.Length != 0)
            {
                // If the watchlist isnt empty - add all the currently watching
                return await _userAnimeService.AddAnimeInBulkAsync(userEmail, currentWatchlist);
            }

            return Enumerable.Empty<UserAnime>();
        }

       
    }
}   