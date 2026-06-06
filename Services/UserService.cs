using AnimeNewsletter.Data;
using AnimeNewsletter.Data.Models;
using AnimeNewsletter.Services.Dtos;
using AnimeNewsletter.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AnimeNewsletter.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly HttpClient _httpClient;

        public UserService(ApplicationDbContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
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
            await TriggerN8NGet($"webhook/user/watchlist?username={username}");
        }

        private async Task<HttpRequestMessage> TriggerN8NGet(string urlToSend)
        {
            // Crucial: Encode the target URL so characters like '?', '&', and '/' don't break the request
            string encodedUrl = HttpUtility.UrlEncode(urlToSend);

            string n8nWebhookUrl = $"{Constants.SERVER_URL}{encodedUrl}";

            HttpResponseMessage response = await _httpClient.GetAsync(n8nWebhookUrl);

            return response;
        }
    }
}