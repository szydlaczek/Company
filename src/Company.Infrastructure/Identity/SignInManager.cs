using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CompanySelf.Infrastructure.Identity
{
    public static class SignInManager
    {
        private const string UserName = "Admin";
        private const string Password = "Admin123";

        public static async Task<IEnumerable<Claim>> Authenticate(string username, string password)
        {
            if (string.Equals(username, UserName) && string.Equals(password, Password))
            {
                var result = new List<Claim> { new Claim("name", username) };
                return await Task.FromResult(result);
            }

            return null;
        }
    }
}