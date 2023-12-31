    using Microsoft.EntityFrameworkCore;
    using Test_Lab5.Models;

    namespace Test_Lab5.DB;
     
    public class MusicCatalogContext:DbContext {
        public DbSet<MusicModel> Musics { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data Source = Lab5.db");
        }

        public MusicCatalogContext() {
            Database.EnsureCreated();
        }

        public MusicCatalogContext(DbContextOptions<MusicCatalogContext> options) : base(options) {
            Database.EnsureCreated();
        }
    }