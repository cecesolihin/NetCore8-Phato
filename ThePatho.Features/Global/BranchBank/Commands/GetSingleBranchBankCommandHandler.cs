using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.BranchBank.Service;
using ThePatho.Features.Global.BranchBank.DTO;

namespace ThePatho.Features.Global.BranchBank.Commands
{
    public class GetSingleBranchBankCommandHandler : IRequestHandler<GetSingleBranchBankCommand, ApiResponse<BranchBankDto>>
    {
        private readonly IBranchBankService branchBankService;

        public GetSingleBranchBankCommandHandler(IBranchBankService _branchBankService)
        {
            branchBankService = _branchBankService;
        }

        public async Task<ApiResponse<BranchBankDto>> Handle(GetSingleBranchBankCommand request, CancellationToken cancellationToken)
        {
            return await branchBankService.GetSingleBranchBank(request);
        }
    }
}
