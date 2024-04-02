using Tangy_Models;
using Tangy_DataAccess_1;
using Tangy_DataAccess_1.Data;
using Tangy_Business.Repository.IRepository;

namespace Tangy_Business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public CategoryDTO Create(CategoryDTO objDTO)
        {
            var category = new Category()
            {
                Id = objDTO.Id,
                Name = objDTO.Name,
                CreatedDate = DateTime.Now
            };

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
            throw new NotImplementedException();
        }

        public CategoryDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public CategoryDTO Update(CategoryDTO objDTO)
        {
            throw new NotImplementedException();
        }
    }
}
