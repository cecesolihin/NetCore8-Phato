using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.TerminationType.DTO;

namespace ThePatho.Features.Organization.TerminationType.Commands
{
    public class GetSingleTerminationTypeCommand : IRequest<ApiResponse<TerminationTypeDto>>
    {
        [JsonPropertyName("termination_type_code")]
        public string TerminationTypeCode { get; set; } = null!;
    }
}
