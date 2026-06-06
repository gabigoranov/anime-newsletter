using AnimeNewsletter.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimeNewsletter.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Anime> Anime { get; set; }
        public DbSet<UserAnime> UserAnime { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Anime>()
                .Property(e => e.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<UserAnime>()
                .HasKey(ua => new { ua.UserEmail, ua.AnimeId });
        }
    }
}