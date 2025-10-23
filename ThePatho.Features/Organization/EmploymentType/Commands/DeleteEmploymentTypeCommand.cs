using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.EmploymentType.Commands
{
    public class DeleteEmploymentTypeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employment_type_code")]
        public string EmploymentTypeCode { get; set; } = null!;
    }
}
