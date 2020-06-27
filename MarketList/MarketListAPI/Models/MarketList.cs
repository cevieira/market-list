using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;

namespace MarketListAPI.Models
{
    public class MarketList : Base
    {  
        [Required]
        public string Title { get; set; }
        
        public DateTime Date { get; set; }

        public decimal TotalPrice
        {
            get
            {
                return Itens?.Sum(x => x.Price) ?? 0;
            }
        }

        public IEnumerable<Item> Itens { get; set; }
        
        public int UserId { get; set; }
        
        [JsonIgnore]
        public User User { get; set; }
    }
}