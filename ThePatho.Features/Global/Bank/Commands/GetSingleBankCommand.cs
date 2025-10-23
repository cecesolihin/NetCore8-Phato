using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Bank.DTO;

namespace ThePatho.Features.Global.Bank.Commands
{
    public class GetSingleBankCommand : IRequest<ApiResponse<BankDto>>
    {
        [JsonPropertyName("filter_BankCode")]
        public string FilterBankCode { get; set; } = null!;
    }
}
