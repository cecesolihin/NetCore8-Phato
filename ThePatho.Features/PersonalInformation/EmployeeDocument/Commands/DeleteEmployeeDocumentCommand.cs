using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeDocument.Commands
{
    public class DeleteEmployeeDocumentCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employee_document_id")]
        public int EmployeeDocumentId { get; set; }
    }
}

