using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using wmcdemo.Services.Interfaces;

namespace wmcdemo.Services.Implementations
{
    public class LoginService : ILoginService
    {
        public async Task<bool> Login(string username, string password)
        {
            return password.ToLower() == "password";
        }
    }
}
