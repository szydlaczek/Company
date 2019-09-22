using System.Collections.Generic;
using System.Linq;

namespace CompanySelf.Application.Services
{
    public class UserService : IUserService
    {
        private List<User> _users = new List<User>
        {
            new User {   UserName = "Admin", Password = "test" }
        };

        public bool Authenticate(string userName, string password)
        {
            var user = _users.Where(u => u.UserName == userName && u.Password == password).FirstOrDefault();

            return user is null ? false : true;
        }
    }

    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}