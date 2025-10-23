using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.BranchBank.Service;
using ThePatho.Features.Global.BranchBank.DTO;

namespace ThePatho.Features.Global.BranchBank.Commands
{
    public class GetBranchBankCommandHandler : IRequestHandler<GetBranchBankCommand, ApiResponse<BranchBankItemDto>>
    {
        private readonly IBranchBankService branchBankService;

        public GetBranchBankCommandHandler(IBranchBankService _branchBankService)
        {
            branchBankService = _branchBankService;
        }

        public async Task<ApiResponse<BranchBankItemDto>> Handle(GetBranchBankCommand request, CancellationToken cancellationToken)
        {
            return await branchBankService.GetBranchBank(request);
        }
    }
}
