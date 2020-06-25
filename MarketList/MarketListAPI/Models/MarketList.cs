using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarketListAPI.Models
{
    public class MarketList : Base
    {  
        [Required]
        public string Title { get; set; }
        
        public DateTime Date { get; set; }
        
        public decimal TotalPrice { get; set; }
        public IEnumerable<Item> Itens { get; set; }
    }
}