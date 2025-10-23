using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.BranchBank.DTO;

namespace ThePatho.Features.Global.BranchBank.Commands
{
    public class GetSingleBranchBankCommand : IRequest<ApiResponse<BranchBankDto>>
    {
        [JsonPropertyName("filter_BranchBankName")]
        public string? FilterBranchBankName { get; set; }

        [JsonPropertyName("filter_BranchBankCode")]
        public string? FilterBranchBankCode { get; set; }

    }
}
