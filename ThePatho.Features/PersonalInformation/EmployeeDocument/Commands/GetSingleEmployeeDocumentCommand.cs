using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeDocument.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeDocument.Commands
{
    public class GetSingleEmployeeDocumentCommand : IRequest<ApiResponse<EmployeeDocumentDto>>
    {
        [JsonPropertyName("employee_document_id")]
        public int EmployeeDocumentId { get; set; }

    }
}
