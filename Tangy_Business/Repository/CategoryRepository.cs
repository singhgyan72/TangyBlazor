using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangy_Business.IRepository;
using Tangy_DataAccess;
using Tangy_DataAccess.Data;
using Tangy_Models;

namespace Tangy_Business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _db = dbContext;
            _mapper = mapper;
        }

        public CategoryDTO Create(CategoryDTO categoryDTO)
        {
            var obj = _mapper.Map<CategoryDTO, Category>(categoryDTO);
            obj.CreatedDate = DateTime.Now;
            var addedObj = _db.Category.Add(obj);
            _db.SaveChanges();

            return _mapper.Map<Category, CategoryDTO>(addedObj.Entity);
        }

        public int Delete(int categoryId)
        {
            var obj = _db.Category.FirstOrDefault(i => i.Id == categoryId);
            if (obj != null)
            {
                _db.Category.Remove(obj);
                return _db.SaveChanges();
            }
            return 0;
        }

        public CategoryDTO Get(int categoryId)
        {
            var obj = _db.Category.FirstOrDefault(i => i.Id == categoryId);
            if (obj != null)
            {
                return _mapper.Map<Category, CategoryDTO>(obj);
            }
            return new CategoryDTO();
        }

        public List<CategoryDTO> GetAll()
        {
            return _mapper.Map<List<Category>, List<CategoryDTO>>(_db.Category.ToList());
        }

        public CategoryDTO Update(CategoryDTO categoryDTO)
        {
            var objFromDb = _db.Category.FirstOrDefault(i => i.Id == categoryDTO.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = categoryDTO.Name;
                _db.Category.Update(objFromDb);
                _db.SaveChanges();
                return _mapper.Map<Category, CategoryDTO>(objFromDb);
            }
            return categoryDTO;
        }
    }
}
