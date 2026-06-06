using AnimeNewsletter.Data.Models;
using AnimeNewsletter.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeNewsletter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimesController : ControllerBase
    {
        private readonly IAnimeService _animeService;

        public AnimesController(IAnimeService animeService)
        {
            _animeService = animeService;
        }

        /// <summary>
        /// Retrieves all anime.
        /// </summary>
        /// <returns>A list of all anime.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Anime>>> GetAll()
        {
            var anime = await _animeService.GetAllAnimeAsync();
            return Ok(anime);
        }

        /// <summary>
        /// Retrieves an anime by its ID.
        /// </summary>
        /// <param name="id">The ID of the anime to retrieve.</param>
        /// <returns>The anime if found; otherwise a 404 Not Found response.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Anime>> GetById(int id)
        {
            var anime = await _animeService.GetAnimeByIdAsync(id);
            if (anime == null)
                return NotFound();

            return Ok(anime);
        }

        /// <summary>
        /// Scans for new or updated anime entries.
        /// </summary>
        [HttpPost("scan")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Scan()
        {
            await _animeService.ScanAnimeAsync();
            return Ok();
        }
    }
}
