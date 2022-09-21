using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("CustomerProduct")]
    public class CustomerProduct
    {
        public Guid CustomerProductId { get; set; }
        public string customer { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        public string price { get; set; }
    }
}