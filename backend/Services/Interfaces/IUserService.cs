using AnimeNewsletter.Data.Models;

namespace AnimeNewsletter.Services.Interfaces
{
    /// <summary>
    /// Service for managing user operations including CRUD operations and watchlist management.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Retrieves all users from the database.
        /// </summary>
        /// <returns>A collection of all users.</returns>
        Task<IEnumerable<User>> GetAllUsersAsync();

        /// <summary>
        /// Retrieves a user by their email address.
        /// </summary>
        /// <param name="email">The email address of the user to retrieve.</param>
        /// <returns>The user if found; otherwise null.</returns>
        Task<User?> GetUserByEmailAsync(string email);

        /// <summary>
        /// Creates a new user in the database.
        /// </summary>
        /// <param name="user">The user object containing username and email.</param>
        /// <returns>The created user object.</returns>
        Task<User> CreateUserAsync(User user);

        /// <summary>
        /// Updates an existing user's information.
        /// </summary>
        /// <param name="email">The email address of the user to update.</param>
        /// <param name="user">The updated user object.</param>
        /// <returns>The updated user object, or null if the user was not found.</returns>
        Task<User?> UpdateUserAsync(string email, User user);

        /// <summary>
        /// Deletes a user from the database.
        /// </summary>
        /// <param name="email">The email address of the user to delete.</param>
        /// <returns>True if the user was deleted; false if the user was not found.</returns>
        Task<bool> DeleteUserAsync(string email);

        /// <summary>
        /// Updates a user's anime watchlist by fetching from MyAnimeList API.
        /// Syncs the user's watchlist with anime marked as "watching" status.
        /// </summary>
        /// <param name="userEmail">The email address of the user.</param>
        /// <param name="username">The MyAnimeList username to fetch the watchlist from.</param>
        /// <returns>A collection of anime entries added to the user's watchlist.</returns>
        Task<IEnumerable<UserAnime>> UpdateUserWatchlistAsync(string userEmail, string username);
    }
}
