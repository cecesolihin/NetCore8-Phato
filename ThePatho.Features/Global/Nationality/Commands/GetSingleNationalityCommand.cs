using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Nationality.DTO;

namespace ThePatho.Features.Global.Nationality.Commands
{
    public class GetSingleNationalityCommand : IRequest<ApiResponse<NationalityDto>>
    {
        [JsonPropertyName("filter_NationalityId")]
        public int FilterNationalityId { get; set; }
    }
}
