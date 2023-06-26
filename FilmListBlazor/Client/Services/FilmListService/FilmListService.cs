using FilmListBlazor.Client.Pages;
using FilmListBlazor.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace FilmListBlazor.Client.Services.FilmListService
{
    public class FilmListService : IFilmListService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public FilmListService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<FilmList> Films { get ; set ; } = new List<FilmList>();
        public List<Watch> Watches { get ; set ; } = new List<Watch> ();

        public async Task CreateFilm(FilmList film)
        {
            var result = await _http.PostAsJsonAsync("api/filmlist", film);
            await SetFilms(result);
        }

        private async Task SetFilms(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<FilmList>>();
            Films = response;
            _navigationManager.NavigateTo("filmlists");
        }
        public async Task DeleteFilm(int id)
        {
            var result = await _http.DeleteAsync($"api/filmlist/{id}");
            await SetFilms(result);                    
        }

        public async Task GetFilmLists()
        {
            var result = await _http.GetFromJsonAsync<List<FilmList>>("api/filmlist");
            if (result != null)
                Films = result;
            
        }

        public async Task<FilmList> GetSingleFilm(int id)
        {
            var result = await _http.GetFromJsonAsync<FilmList>($"api/filmlist/{id}");
            if (result != null)
                return result;
            throw new Exception("Título Não Encontrado. :/");
            
        }

        public async Task GetWatches()
        {
            var result = await _http.GetFromJsonAsync<List<Watch>>("api/filmlist/watches");
            if (result != null)
                Watches = result;
        }

        public async Task UpdateFilm(FilmList film)
        {
            var result = await _http.PutAsJsonAsync($"api/filmlist/{film.Id}", film);
            await SetFilms(result);
        }
    }
}
