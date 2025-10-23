using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.WorkLocationGroup.Commands
{
    public class DeleteWorkLocationGroupCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("group_detail_id")]
        public int GroupDetailId { get; set; }
    }
}
