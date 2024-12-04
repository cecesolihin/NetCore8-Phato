using Microsoft.EntityFrameworkCore;
using ThePatho.Features.MasterSetting.QuestionSetting.DTO;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.MasterSetting.QuestionSetting.Service
{
    public class QuestionSettingService : IQuestionSettingService
    {
        private readonly ApplicationDbContext _context;

        public QuestionSettingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<QuestionSettingDto>> GetAllQuestionSettingAsync()
        {
            return await _context.QuestionSettings.Select(x => new QuestionSettingDto
            {
                QuestionnaireCode = x.QuestionnaireCode
            }).ToListAsync();
        }

        public Task<QuestionSettingDto?> GetQuestionSettingByCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<QuestionSettingDto> AddQuestionSettingAsync(QuestionSettingDto questionSetting)
        {
            throw new NotImplementedException();
        }

        public Task<QuestionSettingDto?> UpdateQuestionSettingAsync(QuestionSettingDto questionSetting)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteQuestionSettingAsync(string code)
        {
            throw new NotImplementedException();
        }
    }
}
