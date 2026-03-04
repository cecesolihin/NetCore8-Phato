using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeSkill.Commands
{
    public class SubmitEmployeeSkillCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employeeId")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("skillCode")]
        public string SkillCode { get; set; } = null!;

        [JsonPropertyName("profiencyCode")]
        public string ProfiencyCode { get; set; } = null!;

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("takenDate")]
        public string? TakenDate { get; set; }

        [JsonPropertyName("expiredDate")]
        public string? ExpiredDate { get; set; }

        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

