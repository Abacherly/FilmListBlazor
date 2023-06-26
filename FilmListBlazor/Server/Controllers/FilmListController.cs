using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmListBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmListController : ControllerBase
    {
        private readonly DataContext _context;

        public FilmListController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<FilmList>>> GetFilmLists()
        {
            var films = await _context.FilmList.Include(sh => sh.Watch).ToListAsync();
            return Ok(films);
        }

        [HttpGet("watches")]
        public async Task<ActionResult<Watch>> GetWatches()
        {
            var watches = await _context.Watch.ToListAsync();
                return Ok(watches);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FilmList>> GetSingleFilm(int id)
        {
            var film = await _context.FilmList 
                .Include(h => h.Watch)
                .FirstOrDefaultAsync(h => h.Id == id);
            if (film == null)
            
                return NotFound("Sem Filmes Por Aqui. :/");
            
            return Ok(film);
        }

        [HttpPost]
        public async Task<ActionResult<List<FilmList>>> CreateFilmList(FilmList film)
        {
            film.Watch = null;
            _context.FilmList.Add(film);
            await _context.SaveChangesAsync();
            return Ok(await GetDbFilms());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<FilmList>>> UpdateFilmList(FilmList film, int id)
        {
            var dbFilm = await _context.FilmList
                .Include(sh => sh.Watch)
                .FirstOrDefaultAsync (sh => sh.Id == id);

            if(dbFilm == null)
            return NotFound("Desculpe, Título Não Encontrado. :/");

            dbFilm.Title = film.Title;
            dbFilm.Gender = film.Gender;
            dbFilm.Type = film.Type;
            dbFilm.DurationTime = film.DurationTime;
            dbFilm.HappinessScale = film.HappinessScale;
            dbFilm.WatchId = film.WatchId;

            await _context.SaveChangesAsync();
            return Ok(await GetDbFilms());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<FilmList>>> DeleteFilmList(int id)
        {
            var dbFilm = await _context.FilmList    
                .Include(sh => sh.Watch)
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbFilm == null)
                return NotFound("Desculpe, Título Não Encontrado. :/");
            _context.FilmList.Remove(dbFilm);
            await _context.SaveChangesAsync();
            return Ok(await GetDbFilms());
        }


        private async Task<List<FilmList>> GetDbFilms()
        {
            return await _context.FilmList.Include(sh => sh.Watch).ToListAsync();
        }
    }
}
