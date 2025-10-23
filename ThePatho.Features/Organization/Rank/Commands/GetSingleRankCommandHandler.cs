using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Rank.Service;
using ThePatho.Features.Organization.Rank.DTO;

namespace ThePatho.Features.Organization.Rank.Commands
{
    public class GetSingleRankCommandHandler : IRequestHandler<GetSingleRankCommand, ApiResponse<RankDto>>
    {
        private readonly IRankService Service;

        public GetSingleRankCommandHandler(IRankService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<RankDto>> Handle(GetSingleRankCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleRank(request);
        }
    }
}
