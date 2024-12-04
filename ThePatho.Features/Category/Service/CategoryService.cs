using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePatho.Features.Category.DTO;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Category.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<CategoryDto> AddCategoryAsync(CategoryDto category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCategoryAsync(string trainingCategoryCode)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
            var categoryDto = new List<CategoryDto>();
            var data = await _context.Categories.ToListAsync();
            foreach (var category in data) 
            {
                categoryDto.Add(new CategoryDto()
                {
                    TrainingCategoryCode = category.TrainingCategoryCode,
                    TrainingCategoryName = category.TrainingCategoryName,
                    InsertedBy = category.TrainingCategoryCode,
                    InsertedDate = category.InsertedDate,
                    ModifiedBy = category.TrainingCategoryCode, 
                    ModifiedDate = category.ModifiedDate,  
                });
            }
            return categoryDto;
        }

        public Task<CategoryDto?> GetCategoryByCodeAsync(string trainingCategoryCode)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto?> UpdateCategoryAsync(CategoryDto category)
        {
            throw new NotImplementedException();
        }
    }
}
