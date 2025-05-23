﻿using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Position.DTO;

namespace ThePatho.Features.Organization.Position.Commands
{
    public class GetPositionCommand :IRequest<ApiResponse<PositionItemDto>>
    {
        [JsonPropertyName("filter_PositionName")]
        public string? FilterPositionName { get; set; }
        [JsonPropertyName("filter_PositionCode")]
        public string? FilterPositionCode { get; set; }

        [JsonPropertyName("sortBy")]
        public string? SortBy { get; set; } = "InsertedDate";
        [JsonPropertyName("orderBy")]
        public string? OrderBy { get; set; } = "DESC";
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; } = 0;
        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; } = 10; 
    }
}
