using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Bank.Commands
{
    public class DeleteBankCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("bank_code")]
        public string BankCode { get; set; } = null!;
    }
}
