using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RequirementRecRequest.DTO;
using System.ComponentModel;

namespace ThePatho.Features.Recruitment.RequirementRecRequest.Commands
{
    public class GetRequirementRecRequestCommand :IRequest<ApiResponse<RequirementRecRequestItemDto>>
    {
        [JsonPropertyName("filter_RequestNo")]
        public string? FilterRequestNo { get; set; }

        [JsonPropertyName("filter_QuestionCode")]
        public string? FilterQuestionCode { get; set; }

        [JsonPropertyName("filter_Answer")]
        public string? FilterAnswer { get; set; }

        [JsonPropertyName("sortBy")]
        [DefaultValue("InsertedDate")]
        public string? SortBy { get; set; } = "InsertedDate";

        [JsonPropertyName("orderBy")]
        [DefaultValue("DESC")]
        public string? OrderBy { get; set; } = "DESC";

        [JsonPropertyName("pageNumber")]
        [DefaultValue(10)]
        public int PageNumber { get; set; } = 0;

        [JsonPropertyName("pageSize")]
        [DefaultValue(10)]
        public int PageSize { get; set; } = 10; 
    }
}
