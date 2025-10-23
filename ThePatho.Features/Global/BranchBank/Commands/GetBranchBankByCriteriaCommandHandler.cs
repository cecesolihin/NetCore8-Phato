using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.BranchBank.Service;
using ThePatho.Features.Global.BranchBank.DTO;

namespace ThePatho.Features.Global.BranchBank.Commands
{
    public class GetBranchBankByCriteriaCommandHandler : IRequestHandler<GetBranchBankByCriteriaCommand, ApiResponse<BranchBankItemDto>>
    {
        private readonly IBranchBankService branchBankService;

        public GetBranchBankByCriteriaCommandHandler(IBranchBankService _branchBankService)
        {
            branchBankService = _branchBankService;
        }

        public async Task<ApiResponse<BranchBankItemDto>> Handle(GetBranchBankByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await branchBankService.GetBranchBankByCriteria(request);
        }
    }
}
