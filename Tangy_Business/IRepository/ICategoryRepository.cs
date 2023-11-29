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
        public Task<CategoryDTO> Create(CategoryDTO category);
        public Task<CategoryDTO> Update(CategoryDTO category);
        public Task<int> Delete(int categoryId);
        public Task<CategoryDTO> Get(int categoryId);
        public Task<List<CategoryDTO>> GetAll();
    }
}
