using homework10WEB_API.Models.Entities;

namespace homework10WEB_API.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public bool ExistByLogin(string login);
        public bool LoginValidation(string login, string password);
    }
}
