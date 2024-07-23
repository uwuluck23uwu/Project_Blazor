namespace WebLucky_Client.Service.IService
{
    public interface ICommentService
    {
        public Task<IEnumerable<CommentDTO>> GetAll(int productId);
        public Task<CommentDTO> Create(CommentDTO commentDTO);
        public Task<CommentDTO> Update(CommentDTO commentDTO);
        public Task<bool> Delete(int commentId);
    }
}
