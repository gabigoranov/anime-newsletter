using AnimeNewsletter.Data;
using AnimeNewsletter.Data.Models;
using AnimeNewsletter.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimeNewsletter.Services
{
    public class AnimeService : IAnimeService
    {
        private readonly ApplicationDbContext _context;

        public AnimeService(ApplicationDbContext context)
        {
            _context = context;
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
            // Service logic to be implemented
            throw new NotImplementedException();
        }
    }
}