using System.ComponentModel.DataAnnotations;

namespace MarketListAPI.Models
{
    public class User : Base
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}