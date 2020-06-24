using MarketListAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketListAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<MarketList> MarketLists { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}