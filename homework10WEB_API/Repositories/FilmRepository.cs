using homework10WEB_API.Context;
using homework10WEB_API.Models.Entities;
using homework10WEB_API.Repositories.Interfaces;

namespace homework10WEB_API.Repositories;

public class FilmRepository : IRepository<Film>
{
    private readonly AppDbContext _appContext;
    public FilmRepository(AppDbContext context)
    {
        _appContext = context;
    }

    public void Add(Film film)
    {
        if(_appContext.Films.FirstOrDefault(f => f.Title == film.Title) == null)
        {
            _appContext.Films.Add(film);
            _appContext.SaveChanges();
        }
    }

    public List<Film>? GetAll()
    {
        return _appContext.Films.ToList();
    }

    public Film? GetById(int id)
    {
        return _appContext.Films.FirstOrDefault(f => f.Id == id);
    }

    public void Remove(int id)
    {
        var filmToDelete = _appContext.Films.FirstOrDefault(f => f.Id == id);
        if (filmToDelete != null)
        {
            _appContext.Films.Remove(filmToDelete);
            _appContext.SaveChanges();
        }
    }
}
