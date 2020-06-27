using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MarketListAPI.Data;
using MarketListAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketListAPI.Repositories
{
    public class UserRepository
    {
        public static async Task<User> Get(DataContext context, string username, string password)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
        }
    }
}