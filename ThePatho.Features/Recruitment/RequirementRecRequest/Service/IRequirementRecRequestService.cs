using ThePatho.Features.Recruitment.RequirementRecRequest.DTO;

namespace ThePatho.Features.Recruitment.RequirementRecRequest.Service
{
    public interface IRequirementRecRequestService
    {
        Task<List<RequirementRecRequestDto>> GetAllRequirementRecRequestAsync();
        Task<RequirementRecRequestDto?> GetRequirementRecRequestByCodeAsync(string code);
        Task<RequirementRecRequestDto> AddRequirementRecRequestAsync(RequirementRecRequestDto requirement);
        Task<RequirementRecRequestDto?> UpdateRequirementRecRequestAsync(RequirementRecRequestDto requirement);
        Task<bool> DeleteRequirementRecRequestAsync(string code);
    }
}
