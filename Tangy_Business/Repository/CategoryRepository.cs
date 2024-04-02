using Tangy_Models;
using Tangy_DataAccess_1;
using Tangy_DataAccess_1.Data;
using Tangy_Business.Repository.IRepository;
using AutoMapper;

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

        public CategoryDTO Create(CategoryDTO objDTO)
        {
            var category = _mp.Map<Category>(objDTO);
            category.CreatedDate = DateTime.Now;
            _db.Categories.Add(category);
            _db.SaveChanges();

            return new CategoryDTO()
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public int Delete(int id)
        {
            var obj = _db.Categories.FirstOrDefault(u => u.Id == id);
            if (obj != null)
            {
                _db.Categories.Remove(obj);
                return _db.SaveChanges();
            }
            return 0;
        }

        public CategoryDTO Get(int id)
        {
            var obj = _db.Categories.FirstOrDefault(u => u.Id == id);
            if (obj != null)
            {
                return _mp.Map<Category, CategoryDTO>(obj);
            }
            return new CategoryDTO();

        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            return _mp.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
        }

        public CategoryDTO Update(CategoryDTO objDTO)
        {
            var objFromDb = _db.Categories.FirstOrDefault(u => u.Id == objDTO.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = objDTO.Name;
                _db.Categories.Update(objFromDb);
                _db.SaveChanges();
                return _mp.Map<Category, CategoryDTO>(objFromDb);
            }
            return objDTO;

        }
    }
}
