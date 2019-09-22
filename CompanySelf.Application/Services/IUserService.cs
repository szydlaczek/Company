namespace CompanySelf.Application.Services
{
    public interface IUserService
    {
        bool Authenticate(string userName, string password);
    }
}