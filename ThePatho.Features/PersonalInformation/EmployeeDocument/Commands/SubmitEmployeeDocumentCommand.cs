using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeDocument.Commands
{
    public class SubmitEmployeeDocumentCommand : IRequest<ApiResponse>
    {

        [JsonPropertyName("employeeDocumentId")]
        public int EmployeeDocumentId { get; set; }

        [JsonPropertyName("employeeId")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("documentTypeCode")]
        public string DocumentTypeCode { get; set; } = null!;

        [JsonPropertyName("filePath")]
        public string FilePath { get; set; } = null!;

        [JsonPropertyName("remark")]
        public string? Remark { get; set; }

        [JsonPropertyName("insertedBy")]
        public string? InsertedBy { get; set; }

        [JsonPropertyName("insertedDate")]
        public string? InsertedDate { get; set; }

        [JsonPropertyName("modifiedBy")]
        public string? ModifiedBy { get; set; }

        [JsonPropertyName("modifiedDate")]
        public string? ModifiedDate { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

