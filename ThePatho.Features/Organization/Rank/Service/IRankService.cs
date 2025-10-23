using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Rank.Commands;
using ThePatho.Features.Organization.Rank.DTO;

namespace ThePatho.Features.Organization.Rank.Service
{
    public interface IRankService
    {
        Task<ApiResponse<RankItemDto>> GetRank(GetRankCommand request);
        Task<ApiResponse<RankDto>> GetSingleRank(GetSingleRankCommand request);
        Task<ApiResponse<RankItemDto>> GetRankByCriteria(GetRankByCriteriaCommand request);
        Task<ApiResponse> SubmitRank(SubmitRankCommand request);
        Task<ApiResponse> DeleteRank(DeleteRankCommand request);
    }
}
