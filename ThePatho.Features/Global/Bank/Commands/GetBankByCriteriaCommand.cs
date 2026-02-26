using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Bank.DTO;

namespace ThePatho.Features.Global.Bank.Commands
{
    public class GetBankByCriteriaCommand : IRequest<ApiResponse<BankItemDto>>
    {
        [JsonPropertyName("bankCode")]
        public string? BankCode { get; set; }

        [JsonPropertyName("bankName")]
        public string? BankName { get; set; }
    }
}
