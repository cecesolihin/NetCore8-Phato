using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeDocument.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeDocument.Commands
{
    public class GetEmployeeDocumentByCriteriaCommand : IRequest<ApiResponse<EmployeeDocumentItemDto>>
    {
        [JsonPropertyName("employeeId")]
        public int? EmployeeId { get; set; }

        [JsonPropertyName("documentTypeCode")]
        public string? DocumentTypeCode { get; set; }
    }
}

