using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
   [Table("Product")]
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ean { get; set; }
        public string price { get; set; }
    }
}