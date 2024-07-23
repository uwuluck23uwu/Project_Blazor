using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tangy_Business.Repository.IRepository;
using Tangy_DataAccess_1;
using Tangy_DataAccess_1.Data;
using Tangy_Models;

namespace Tangy_Business.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public CommentRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CommentDTO> Get(int id)
        {
            var obj = await _db.Comments.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                return _mapper.Map<Comment, CommentDTO>(obj);
            }
            return new CommentDTO();
        }
        public async Task<IEnumerable<CommentDTO>> GetAll(int id)
        {
            return _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDTO>>(await _db.Comments.Where(p => p.ProductId == id).ToListAsync());
        }
        public async Task<int> Delete(int id)
        {
            var obj = await _db.Comments.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                _db.Comments.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<CommentDTO> Create(CommentDTO objDTO)
        {
            var obj = _mapper.Map<CommentDTO, Comment>(objDTO);
            var addedObj = await _db.Comments.AddAsync(obj);
            await _db.SaveChangesAsync();
            return _mapper.Map<Comment, CommentDTO>(addedObj.Entity);
        }
        public async Task<CommentDTO> Update(CommentDTO objDTO)
        {
            var objFromDb = await _db.Comments.FirstOrDefaultAsync(u => u.Id == objDTO.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = objDTO.Name;
                objFromDb.CreatedDate = objDTO.CreatedDate;
                objFromDb.UserEmail = objDTO.UserEmail;
                objFromDb.ProductId = objDTO.ProductId;
                _db.Comments.Update(objFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<Comment, CommentDTO>(objFromDb);
            }
            return objDTO;
        }
    }
}
