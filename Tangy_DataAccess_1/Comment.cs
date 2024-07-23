namespace Tangy_DataAccess_1
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserEmail { get; set; }
        public int ProductId { get; set; }
    }
}
