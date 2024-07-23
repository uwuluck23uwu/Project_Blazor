namespace Tangy_Models
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserEmail { get; set; }
        public int ProductId { get; set; }
    }
}
