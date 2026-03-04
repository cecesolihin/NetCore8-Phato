using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeDocument.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeDocument.Commands
{
    public class GetEmployeeDocumentCommand : IRequest<ApiResponse<EmployeeDocumentItemDto>>
    {
        [JsonPropertyName("filter_EmployeeId")]
        public int? FilterEmployeeId { get; set; }

        [JsonPropertyName("filter_DocumentTypeCode")]
        public string? FilterDocumentTypeCode { get; set; }

        [JsonPropertyName("sortBy")]
        [DefaultValue("InsertedDate")]
        public string? SortBy { get; set; } = "InsertedDate";

        [JsonPropertyName("orderBy")]
        [DefaultValue("DESC")]
        public string? OrderBy { get; set; } = "DESC";

        [JsonPropertyName("pageNumber")]
        [DefaultValue(1)]
        public int PageNumber { get; set; } = 1;

        [JsonPropertyName("pageSize")]
        [DefaultValue(10)]
        public int PageSize { get; set; } = 10;
    }
}

