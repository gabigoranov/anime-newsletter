using AnimeNewsletter.Data.Models;
using AnimeNewsletter.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeNewsletter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>A list of all users.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        /// <summary>
        /// Retrieves a user by email.
        /// </summary>
        /// <param name="email">The email address of the user to retrieve.</param>
        /// <returns>The user if found; otherwise a 404 Not Found response.</returns>
        [HttpGet("{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> GetByEmail(string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="user">The user object to create.</param>
        /// <returns>The created user with a 201 Created response.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> Create([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdUser = await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetByEmail), new { email = createdUser.Email }, createdUser);
        }

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="email">The email address of the user to update.</param>
        /// <param name="user">The updated user object.</param>
        /// <returns>The updated user, or a 404 Not Found response if the user does not exist.</returns>
        [HttpPut("{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> Update(string email, [FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedUser = await _userService.UpdateUserAsync(email, user);
            if (updatedUser == null)
                return NotFound();

            return Ok(updatedUser);
        }

        /// <summary>
        /// Deletes a user by email.
        /// </summary>
        /// <param name="email">The email address of the user to delete.</param>
        /// <returns>A 204 No Content response if deletion was successful, or a 404 Not Found response if the user does not exist.</returns>
        [HttpDelete("{email}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string email)
        {
            var deleted = await _userService.DeleteUserAsync(email);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Updates a user's anime watchlist by syncing with MyAnimeList.
        /// </summary>
        /// <param name="userEmail">The email address of the user.</param>
        /// <param name="username">The MyAnimeList username to fetch the watchlist from.</param>
        /// <returns>The newly added watchlist entries.</returns>
        [HttpPut("{userEmail}/watchlist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<UserAnime>>> UpdateWatchlist(string userEmail, [FromQuery] string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return BadRequest("MyAnimeList username is required.");

            try
            {
                var watchlistEntries = await _userService.UpdateUserWatchlistAsync(userEmail, username);
                return Ok(watchlistEntries);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}