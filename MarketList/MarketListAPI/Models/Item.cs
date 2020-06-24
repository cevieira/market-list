using System.ComponentModel.DataAnnotations;

namespace MarketListAPI.Models
{
    public class Item : Base
    {
        [Required]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Name { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Price { get; set; }
        
        public bool Caught { get; set; }
        
        [MaxLength(1024, ErrorMessage = "Este campo deve conter no máximo 1024 caracteres")]
        public string Comentary { get; set; }
        
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "MarketList inválido")]
        public int MarketListId { get; set; }
        public MarketList MarketList { get; set; }
    }
}