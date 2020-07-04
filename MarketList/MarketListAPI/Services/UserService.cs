using System.Collections.Generic;
using System.Threading.Tasks;
using MarketListAPI.Data;
using MarketListAPI.Helpers;
using MarketListAPI.Models;
using MarketListAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketListAPI.Services
{
    public class UserService : IUserService
    {
        public async Task<User> Authenticate([FromServices] DataContext context, [FromServices]PasswordHasher passwordHasher, string username, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Username == username);
            (bool verified, bool needsUpgrade) = passwordHasher.Check(user.Password, password);

            return verified ? user.WithoutPassword() : null;
        }

        public IEnumerable<User> GetAll([FromServices] DataContext context)
        {
            return context.Users.WithoutPasswords();
        }

        public async Task<User> GetById([FromServices] DataContext context, int id)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}