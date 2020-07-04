using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MarketListAPI.Data;
using MarketListAPI.Models;
using MarketListAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketListAPI.Repositories
{
    public class UserRepository
    {
        public static async Task<User> Get(DataContext context, PasswordHasher passwordHasher, string username, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Username == username);
            (bool verified, bool needsUpgrade) = passwordHasher.Check(user.Password, password);

            return verified ? user : null;
        }
    }
}