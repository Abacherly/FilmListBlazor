
namespace FilmListBlazor.Client.Services.FilmListService
{
    public interface IFilmListService
    {
        List<FilmList> Films { get; set; }
        List<Watch> Watches { get; set; }
        Task GetWatches();
        Task GetFilmLists();
        Task<FilmList> GetSingleFilm(int id);
        Task CreateFilm(FilmList film);
        Task UpdateFilm(FilmList film);
        Task DeleteFilm(int id);
    }
}
