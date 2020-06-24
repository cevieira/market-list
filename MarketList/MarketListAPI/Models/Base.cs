using System.ComponentModel.DataAnnotations;

namespace MarketListAPI.Models
{
    public class Base
    {
        [Key]
        public int Id { get; set; }
    }
}