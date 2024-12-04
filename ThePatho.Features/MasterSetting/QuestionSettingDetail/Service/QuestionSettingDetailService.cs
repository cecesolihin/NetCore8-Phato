using Microsoft.EntityFrameworkCore;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.DTO;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.MasterSetting.QuestionSettingDetail.Service
{
    public class QuestionSettingDetailService : IQuestionSettingDetailService
    {
        private readonly ApplicationDbContext _context;

        public QuestionSettingDetailService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<QuestionSettingDetailDto> AddQuestionSettingDetailAsync(QuestionSettingDetailDto detail)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteQuestionSettingDetailAsync(string code)
        {
            throw new NotImplementedException();
        }

        public async Task<List<QuestionSettingDetailDto>> GetAllQuestionSettingDetailAsync()
        {
            return await _context.QuestionSettingDetails.Select(x => new QuestionSettingDetailDto
            {
                QuestDetailId = x.QuestDetailId,
            }).ToListAsync();
        }

        public Task<QuestionSettingDetailDto?> GetQuestionSettingDetailByCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<QuestionSettingDetailDto?> UpdateQuestionSettingDetailAsync(QuestionSettingDetailDto detail)
        {
            throw new NotImplementedException();
        }
    }
}
