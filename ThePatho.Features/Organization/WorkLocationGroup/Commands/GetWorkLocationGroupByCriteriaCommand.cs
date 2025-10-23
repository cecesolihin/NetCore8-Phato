using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.WorkLocationGroup.DTO;

namespace ThePatho.Features.Organization.WorkLocationGroup.Commands
{
    public class GetWorkLocationGroupByCriteriaCommand : IRequest<ApiResponse<WorkLocationGroupItemDto>>
    {

        [JsonPropertyName("filter_group_id")]
        public int? FilterGroupId { get; set; }

        [JsonPropertyName("filter_work_location_code")]
        public string? FilterWorkLocationCode { get; set; }
    }
}
