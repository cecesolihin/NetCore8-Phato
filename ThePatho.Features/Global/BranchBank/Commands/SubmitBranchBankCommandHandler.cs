using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.BranchBank.Service;

namespace ThePatho.Features.Global.BranchBank.Commands
{
    public class SubmitBranchBankCommandHandler : IRequestHandler<SubmitBranchBankCommand, ApiResponse>
    {
        private readonly IBranchBankService branchBankService;

        public SubmitBranchBankCommandHandler(IBranchBankService _branchBankService)
        {
            branchBankService = _branchBankService;
        }

        public async Task<ApiResponse> Handle(SubmitBranchBankCommand request, CancellationToken cancellationToken)
        {
            return await branchBankService.SubmitBranchBank(request);
        }
    }
}
