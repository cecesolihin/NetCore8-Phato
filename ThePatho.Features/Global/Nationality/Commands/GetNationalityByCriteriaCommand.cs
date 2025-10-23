using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Nationality.DTO;

namespace ThePatho.Features.Global.Nationality.Commands
{
    public class GetNationalityByCriteriaCommand : IRequest<ApiResponse<NationalityItemDto>>
    {
        [JsonPropertyName("filter_NationalityName")]
        public string? FilterNationalityName { get; set; }


    }
}
