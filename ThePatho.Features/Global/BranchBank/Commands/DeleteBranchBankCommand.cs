using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.BranchBank.Commands
{
    public class DeleteBranchBankCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("branch_bank_code")]
        public string BranchBankCode { get; set; } = null!;
    }
}
