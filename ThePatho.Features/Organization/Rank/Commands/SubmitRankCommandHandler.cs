using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Rank.Service;

namespace ThePatho.Features.Organization.Rank.Commands
{
    public class SubmitRankCommandHandler : IRequestHandler<SubmitRankCommand, ApiResponse>
    {
        private readonly IRankService Service;

        public SubmitRankCommandHandler(IRankService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse> Handle(SubmitRankCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitRank(request);
        }
    }
}
