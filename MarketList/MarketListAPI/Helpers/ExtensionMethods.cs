using System.Collections.Generic;
using System.Linq;
using MarketListAPI.Models;

namespace MarketListAPI.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<User> WithoutPasswords(this IEnumerable<User> users) 
        {
            return users?.Select(x => x.WithoutPassword());
        }

        public static User WithoutPassword(this User user) 
        {
            if (user == null) return null;

            user.Password = null;
            return user;
        }
    }
}