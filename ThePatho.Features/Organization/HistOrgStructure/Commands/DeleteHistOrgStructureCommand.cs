using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.HistOrgStructure.Commands
{
    public class DeleteHistOrgStructureCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("histOrgStructureId")]
        public int HistOrgStructureId { get; set; }
    }
}
