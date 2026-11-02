using homework10WEB_API.Models.Entities;
using homework10WEB_API.Services;
using Microsoft.AspNetCore.Mvc;
using static homework10WEB_API.Services.FilmService;

namespace homework10WEB_API.Controllers
{
    [Route("api/films")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly FilmService _filmService;
        public FilmController(FilmService service)
        {
            _filmService = service;
        }

        [HttpGet("all")]
        public ActionResult<List<Film>> GetAllFilms()
        {
            var allFilms = _filmService.GetAll();
            if (allFilms.Status == ResponceStatus.NOT_FOUND)
            {
                return NotFound();
            }
            else
            {
                return Ok(allFilms.Value);
            }
        }

        [HttpPost("add")]
        public IActionResult AddFilm([FromBody] Film film)
        {
            var responce = _filmService.Add(film);
            if(responce == ResponceStatus.BAD_PUBLICATION_YEAR)
            {
                return BadRequest("Publication year must be shorter or equals " + DateTime.Now.Year.ToString());
            }
            else if(responce == ResponceStatus.BAD_FILM_LENGTH)
            {
                return BadRequest("Film length must be longer 40 minutes");
            }
            else if (responce == ResponceStatus.BAD_POSTER_URL)
            {
                return BadRequest("No film poster");
            }
            else if(responce == ResponceStatus.OK)
            {
                return Ok("Film was added");
            }
            else
            {
                return StatusCode(500, "Cannot process responce");
            }
        }

        [HttpDelete("remove/{id}")]
        public IActionResult RemoveFilm([FromRoute] int id)
        {
            _filmService.Remove(id);
            return NoContent();
        }
    }
}
