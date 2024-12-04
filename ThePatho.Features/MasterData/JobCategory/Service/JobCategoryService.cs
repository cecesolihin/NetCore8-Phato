using Microsoft.EntityFrameworkCore;
using ThePatho.Features.MasterData.JobCategory.DTO;
using ThePatho.Features.MasterData.JobCategory.Service;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.MasterData.JobCategory.Service
{
    public class JobCategoryService : IJobCategoryService
    {
        private readonly ApplicationDbContext _context;

        public JobCategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<JobCategoryDto>> GetAllJobCategoriesAsync()
        {
            var jobCategoryDto = new List<JobCategoryDto>();
            var data = await _context.JobCategories.ToListAsync();
            foreach (var jobCategory in data)
            {
                jobCategoryDto.Add(new JobCategoryDto()
                {
                    JobCategoryCode = jobCategory.JobCategoryCode,
                    JobCategoryName = jobCategory.JobCategoryName,
                    InsertedBy = jobCategory.InsertedBy,
                    InsertedDate = jobCategory.InsertedDate,
                    ModifiedBy = jobCategory.ModifiedBy,
                    ModifiedDate = jobCategory.ModifiedDate,
                });
            }
            return jobCategoryDto;
        }

        public Task<JobCategoryDto?> GetJobCategoryByCodeAsync(string jobCategoryCode)
        {
            throw new NotImplementedException();
        }

        public Task<JobCategoryDto> AddJobCategoryAsync(JobCategoryDto jobCategory)
        {
            throw new NotImplementedException();
        }

        public Task<JobCategoryDto?> UpdateJobCategoryAsync(JobCategoryDto jobCategory)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteJobCategoryAsync(string jobCategoryCode)
        {
            throw new NotImplementedException();
        }
    }
}
