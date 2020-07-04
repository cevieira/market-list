using System.Collections.Generic;
using System.Threading.Tasks;
using MarketListAPI.Data;
using MarketListAPI.Models;

namespace MarketListAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> Authenticate(DataContext context, PasswordHasher passwordHasher, string username, string password);
        IEnumerable<User> GetAll(DataContext context);
        Task<User> GetById(DataContext context, int id);
    }
}