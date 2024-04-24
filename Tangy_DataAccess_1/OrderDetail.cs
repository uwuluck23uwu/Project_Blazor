using System.ComponentModel.DataAnnotations.Schema;

namespace Tangy_DataAccess_1
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderHeaderId { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [NotMapped]
        public Product Product { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public string Size { get; set; }
        public string ProductName { get; set; }
    }
}
