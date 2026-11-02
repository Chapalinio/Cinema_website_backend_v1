using homework10WEB_API.Models;
using homework10WEB_API.Models.DTO;
using homework10WEB_API.Models.Entities;
using homework10WEB_API.Repositories.Interfaces;

namespace homework10WEB_API.Services;

public class FilmService
{
    public enum ResponceStatus
    {
        OK,
        NOT_FOUND,
        BAD_PUBLICATION_YEAR,
        BAD_FILM_LENGTH,
        BAD_POSTER_URL,
        NO_CONTENT
    }
    private readonly IRepository<Film> _filmRepository;
    public FilmService(IRepository<Film> repository)
    {
        _filmRepository = repository;
    }

    public Result<List<Film>> GetAll()
    {
        if (_filmRepository.GetAll() == null || _filmRepository.GetAll().Count == 0)
        {
            return new Result<List<Film>>() { Status = ResponceStatus.NOT_FOUND };
        }
        else
        {
            return new Result<List<Film>>() { Status = ResponceStatus.OK, Value = _filmRepository.GetAll().ToList() };
        }
    }

    public ResponceStatus Add(Film film)
    {
        if(film.PublicationYear > DateTime.Now.Year)
        {
            return ResponceStatus.BAD_PUBLICATION_YEAR;
        }
        else if(film.LengthInMinuts <= 40)
        {
            return ResponceStatus.BAD_FILM_LENGTH;
        }
        else if(String.IsNullOrEmpty(film.PosterUrl))
        {
            return ResponceStatus.BAD_POSTER_URL;
        }
        else
        {
            var filmToAdd = new Film()
            {
                Title = film.Title,
                Description = film.Description,
                PublicationYear = film.PublicationYear,
                LengthInMinuts = film.LengthInMinuts,
                PosterUrl = film.PosterUrl
            };
            _filmRepository.Add(filmToAdd);

            return ResponceStatus.OK;
        }
    }

    public void Remove(int id)
    {
        _filmRepository.Remove(id);
    }
}
