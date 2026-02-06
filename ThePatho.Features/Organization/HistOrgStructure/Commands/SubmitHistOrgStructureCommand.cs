using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.HistOrgStructure.Commands
{
    public class SubmitHistOrgStructureCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("histOrgStructureId")]
        public int HistOrgStructureId { get; set; }

        [JsonPropertyName("orgStructureId")]
        public int OrgStructureId { get; set; }

        [JsonPropertyName("orgStructureCode")]
        public string OrgStructureCode { get; set; } = null!;

        [JsonPropertyName("orgStructureName")]
        public string OrgStructureName { get; set; } = null!;

        [JsonPropertyName("parentOrgStructureId")]
        public int? ParentOrgStructureId { get; set; }

        [JsonPropertyName("orgLevelCode")]
        public string OrgLevelCode { get; set; } = null!;

        [JsonPropertyName("status")]
        public string IsActive { get; set; } = null!;

        [JsonPropertyName("costCenterCode")]
        public string? CostCenterCode { get; set; }

        [JsonPropertyName("location")]
        public string? Location { get; set; }

        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        [JsonPropertyName("phoneExt")]
        public string? PhoneExt { get; set; }

        [JsonPropertyName("sort")]
        public byte SortOrder { get; set; }

        [JsonPropertyName("companyCode")]
        public string CompanyCode { get; set; } = null!;

        [JsonPropertyName("startDate")]
        public string? StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public string? EndDate { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("path")]
        public string? Path { get; set; }

        [JsonPropertyName("function")]
        public string? Function { get; set; }
        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
