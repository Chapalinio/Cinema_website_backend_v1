using static homework10WEB_API.Services.FilmService;

namespace homework10WEB_API.Models;

public class Result<T>
{
    public ResponceStatus Status { get; set; }
    public T? Value { get; set; }
}
