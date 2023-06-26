
namespace FilmListBlazor.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Watch>().HasData(
                new Watch { Id = 1, Name = "Sim" },
                new Watch { Id = 2, Name = "Não" }
                );

            modelBuilder.Entity<FilmList>().HasData(
                new FilmList
                {
                    Id = 1,
                    Title = "How I Met Your Mother",
                    Gender = "Drama Psicológico",
                    Type = "Série",
                    DurationTime = "22 min",
                    HappinessScale = "10",
                    WatchId = 1
                },
                new FilmList
                {
                    Id = 2,
                    Title = "A Baleia",
                    Gender = "Drama Psicológico",
                    Type = "Filme",
                    DurationTime = "115 min",
                    HappinessScale = "10",
                    WatchId = 2
                }
                );
        }
        public DbSet<FilmList> FilmList { get; set; }
        public DbSet<Watch> Watch { get; set; }
    }
}
