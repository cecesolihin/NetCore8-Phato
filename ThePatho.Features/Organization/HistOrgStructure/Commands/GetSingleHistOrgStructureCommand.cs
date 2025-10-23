using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.HistOrgStructure.DTO;

namespace ThePatho.Features.Organization.HistOrgStructure.Commands
{
    public class GetSingleHistOrgStructureCommand : IRequest<ApiResponse<HistOrgStructureDto>>
    {
        [JsonPropertyName("histOrgStructureId")]
        public int HistOrgStructureId { get; set; }
    }
}
