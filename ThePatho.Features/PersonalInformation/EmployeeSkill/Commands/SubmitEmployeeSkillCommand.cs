using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeSkill.Commands
{
    public class SubmitEmployeeSkillCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employee_id")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("skill_code")]
        public string SkillCode { get; set; } = null!;

        [JsonPropertyName("profiency_code")]
        public string ProfiencyCode { get; set; } = null!;

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("taken_date")]
        public string? TakenDate { get; set; }

        [JsonPropertyName("expired_date")]
        public string? ExpiredDate { get; set; }

        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }

        [JsonPropertyName("is_deleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

