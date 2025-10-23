using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Nationality.Commands
{
    public class DeleteNationalityCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("nationality_id")]
        public int NationalityId { get; set; }
    }
}
