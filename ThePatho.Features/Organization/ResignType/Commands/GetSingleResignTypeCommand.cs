using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.ResignType.DTO;

namespace ThePatho.Features.Organization.ResignType.Commands
{
    public class GetSingleResignTypeCommand : IRequest<ApiResponse<ResignTypeDto>>
    {
        [JsonPropertyName("resign_type_code")]
        public string ResignTypeCode { get; set; } = null!;
    }
}
