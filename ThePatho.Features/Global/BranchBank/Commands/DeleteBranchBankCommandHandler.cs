using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.BranchBank.Service;

namespace ThePatho.Features.Global.BranchBank.Commands
{
    public class DeleteBranchBankCommandHandler : IRequestHandler<DeleteBranchBankCommand, ApiResponse>
    {
        private readonly IBranchBankService branchBankService;

        public DeleteBranchBankCommandHandler(IBranchBankService _branchBankService)
        {
            branchBankService = _branchBankService;
        }

        public async Task<ApiResponse> Handle(DeleteBranchBankCommand request, CancellationToken cancellationToken)
        {
            return await branchBankService.DeleteBranchBank(request);
        }
    }
}
