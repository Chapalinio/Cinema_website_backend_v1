using homework10WEB_API.Context;
using homework10WEB_API.Models.Entities;
using homework10WEB_API.Repositories.Interfaces;

namespace homework10WEB_API.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _appContext;
    public UserRepository(AppDbContext context)
    {
        _appContext = context;
    }

    //INTERFACE
    public void Add(User user)
    {
        _appContext.Users.Add(user);
        _appContext.SaveChanges();
    }

    public void Remove(int id)
    {
        var userToDelete = _appContext.Users.FirstOrDefault(u => u.Id == id);
        if (userToDelete != null)
        {
            _appContext.Users.Remove(userToDelete);
            _appContext.SaveChanges();
        }
    }

    public List<User>? GetAll()
    {
        return _appContext.Users.ToList();
    }

    public User? GetById(int id)
    {
        return _appContext.Users.FirstOrDefault(u => u.Id == id);
    }
    //INTERFACE

    //CUSTOM
    public bool ExistByLogin(string login)
    {
        return _appContext.Users.Any(u => String.Equals(u.Login.ToLower(), login.ToLower()));
    }

    public bool LoginValidation(string login, string password)
    {
        return _appContext.Users.Any(u => ExistByLogin(login) && String.Equals(u.Password.ToLower(), password.ToLower()));
    }
    //CUSTOM

}
