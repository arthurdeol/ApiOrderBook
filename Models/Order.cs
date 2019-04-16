using System.ComponentModel.DataAnnotations;

namespace ApiOrderBook.Models
{
    public class Order
    {
        [Key]
        public int IdOrder { get; set; }
        public decimal price { get; set; }
    }
}