using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.SuperiorSubordinate.Commands
{
    public class SubmitMultiSuperiorSubordinateCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employeeList")]
        public List<int> EmployeeList { get; set; } = new();

        [JsonPropertyName("employeeId")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("effectiveDate")]
        public DateTime EffectiveDate { get; set; }

        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }

        [JsonPropertyName("superior1Id")]
        public int? Superior1Id { get; set; }

        [JsonPropertyName("superior2Id")]
        public int? Superior2Id { get; set; }

        [JsonPropertyName("superior3Id")]
        public int? Superior3Id { get; set; }

        [JsonPropertyName("superior4Id")]
        public int? Superior4Id { get; set; }

        [JsonPropertyName("superior5Id")]
        public int? Superior5Id { get; set; }

        [JsonPropertyName("superior6Id")]
        public int? Superior6Id { get; set; }

        [JsonPropertyName("superior7Id")]
        public int? Superior7Id { get; set; }

        [JsonPropertyName("superior8Id")]
        public int? Superior8Id { get; set; }

        [JsonPropertyName("superior9Id")]
        public int? Superior9Id { get; set; }

        [JsonPropertyName("superior10Id")]
        public int? Superior10Id { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

