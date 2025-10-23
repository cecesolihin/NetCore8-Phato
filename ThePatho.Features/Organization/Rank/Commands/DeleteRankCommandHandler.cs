using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Rank.Service;

namespace ThePatho.Features.Organization.Rank.Commands
{
    public class DeleteRankCommandHandler : IRequestHandler<DeleteRankCommand, ApiResponse>
    {
        private readonly IRankService Service;

        public DeleteRankCommandHandler(IRankService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse> Handle(DeleteRankCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteRank(request);
        }
    }
}
