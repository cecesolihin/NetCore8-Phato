using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.WorkLocationGroup.DTO;

namespace ThePatho.Features.Organization.WorkLocationGroup.Commands
{
    public class GetSingleWorkLocationGroupCommand : IRequest<ApiResponse<WorkLocationGroupDto>>
    {
        [JsonPropertyName("group_detail_id")]
        public int GroupDetailId { get; set; }
    }
}
