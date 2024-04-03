using Tangy_Models;
using Tangy_DataAccess_1;
using Tangy_DataAccess_1.Data;
using Tangy_Business.Repository.IRepository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Tangy_Business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mp;

        public CategoryRepository(ApplicationDbContext db, IMapper mp)
        {
            _db = db;
            _mp = mp;
        }

        public async Task<CategoryDTO> Create(CategoryDTO objDTO)
        {
            var category = _mp.Map<Category>(objDTO);
            category.CreatedDate = DateTime.Now;
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();

            return new CategoryDTO()
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                _db.Categories.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<CategoryDTO> Get(int id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                return _mp.Map<Category, CategoryDTO>(obj);
            }
            return new CategoryDTO();
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            return _mp.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
        }

        public async Task<CategoryDTO> Update(CategoryDTO objDTO)
        {
            var objFromDb = await _db.Categories.FirstOrDefaultAsync(u => u.Id == objDTO.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = objDTO.Name;
                _db.Categories.Update(objFromDb);
                await _db.SaveChangesAsync();
                return _mp.Map<Category, CategoryDTO>(objFromDb);
            }
            return objDTO;
        }
    }
}
