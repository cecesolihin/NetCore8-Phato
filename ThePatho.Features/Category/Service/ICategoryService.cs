using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePatho.Features.Category.DTO;

namespace ThePatho.Features.Category.Service
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto?> GetCategoryByCodeAsync(string trainingCategoryCode);
        Task<CategoryDto> AddCategoryAsync(CategoryDto category);
        Task<CategoryDto?> UpdateCategoryAsync(CategoryDto category);
        Task<bool> DeleteCategoryAsync(string trainingCategoryCode);
    }
}
