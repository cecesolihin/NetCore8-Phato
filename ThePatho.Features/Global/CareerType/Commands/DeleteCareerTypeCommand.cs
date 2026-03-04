using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.CareerType.Commands
{
    public class DeleteCareerTypeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("CareerType_code")]
        public string? CareerTypeCode { get; set; }
    }
}


