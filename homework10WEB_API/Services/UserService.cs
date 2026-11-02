using homework10WEB_API.Models.Entities;
using homework10WEB_API.Models.DTO;
using homework10WEB_API.Repositories.Interfaces;

namespace homework10WEB_API.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository repository)
    {
        _userRepository = repository;
    }

    public bool Register(UserRegisterDTO user)
    {
        if(!_userRepository.ExistByLogin(user.Login) &&
            !String.IsNullOrEmpty(user.Password) && user.Password.Length > 6 && user.Password.Length < 20 &&
            !String.IsNullOrEmpty(user.Name) && user.Name.Length > 4 && user.Name.Length < 200 &&
            !String.IsNullOrEmpty(user.Surname) && user.Surname.Length > 4 && user.Surname.Length < 200 &&
            user.Age > 18)
        {
            var newUser = new User() { Login = user.Login, Password = user.Password, Name = user.Name, Surname = user.Surname, Age = user.Age };
            _userRepository.Add(newUser);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Login(UserLoginDTO user)
    {
        if (_userRepository.LoginValidation(user.Login, user.Password))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
