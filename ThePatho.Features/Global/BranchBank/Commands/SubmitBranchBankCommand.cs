using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.BranchBank.Commands
{
    public class SubmitBranchBankCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("branch_bank_code")]
        public string BranchBankCode { get; set; } = null!;

        [JsonPropertyName("branch_bank_name")]
        public string BranchBankName { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
