using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.BranchBank.DTO;

namespace ThePatho.Features.Global.BranchBank.Commands
{
    public class GetBranchBankByCriteriaCommand : IRequest<ApiResponse<BranchBankItemDto>>
    {
        [JsonPropertyName("filter_BranchBankName")]
        public string? FilterBranchBankName { get; set; }

        [JsonPropertyName("filter_BranchBankCode")]
        public string? FilterBranchBankCode { get; set; }

    }
}
