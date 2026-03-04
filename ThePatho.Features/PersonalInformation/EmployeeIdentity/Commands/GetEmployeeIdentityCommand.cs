using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeIdentity.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeIdentity.Commands
{
    public class GetEmployeeIdentityCommand : IRequest<ApiResponse<EmployeeIdentityItemDto>>
    {
        [JsonPropertyName("filter_EmployeeId")]
        public int? FilterEmployeeId { get; set; }
        [JsonPropertyName("filter_Identity")]
        public string? FilterIdentity { get; set; }

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

