using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeDocument.Commands
{
    public class SubmitEmployeeDocumentCommand : IRequest<ApiResponse>
    {

        [JsonPropertyName("employee_document_id")]
        public int EmployeeDocumentId { get; set; }

        [JsonPropertyName("employee_id")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("document_type_code")]
        public string DocumentTypeCode { get; set; } = null!;

        [JsonPropertyName("file_path")]
        public string FilePath { get; set; } = null!;

        [JsonPropertyName("remark")]
        public string? Remark { get; set; }

        [JsonPropertyName("inserted_by")]
        public string? InsertedBy { get; set; }

        [JsonPropertyName("inserted_date")]
        public string? InsertedDate { get; set; }

        [JsonPropertyName("modified_by")]
        public string? ModifiedBy { get; set; }

        [JsonPropertyName("modified_date")]
        public string? ModifiedDate { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

