using Tangy_Models;

namespace Tangy_Business.Repository.IRepository
{
    public interface ICommentRepository
    {
        public Task<CommentDTO> Get(int id);
        public Task<IEnumerable<CommentDTO>> GetAll(int id);
        public Task<int> Delete(int id);
        public Task<CommentDTO> Create(CommentDTO objDTO);
        public Task<CommentDTO> Update(CommentDTO objDTO);
    }
}
