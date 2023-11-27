using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangy_Models;

namespace Tangy_Business.IRepository
{
    public interface ICategoryRepository
    {
        public CategoryDTO Create(CategoryDTO category);
        public CategoryDTO Update(CategoryDTO category);
        public int Delete(int categoryId);
        public CategoryDTO Get(int categoryId);
        public List<CategoryDTO> GetAll();
    }
}
