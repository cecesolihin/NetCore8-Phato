using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.SuperiorSubordinate.Commands
{
    public class SubmitMultiSuperiorSubordinateCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employee_list")]
        public List<int> EmployeeList { get; set; } = new();

        [JsonPropertyName("employee_id")]
        public int EmployeeID { get; set; }

        [JsonPropertyName("effective_date")]
        public DateTime EffectiveDate { get; set; }

        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }

        [JsonPropertyName("superior1_id")]
        public int? Superior1ID { get; set; }

        [JsonPropertyName("superior2_id")]
        public int? Superior2ID { get; set; }

        [JsonPropertyName("superior3_id")]
        public int? Superior3ID { get; set; }

        [JsonPropertyName("superior4_id")]
        public int? Superior4ID { get; set; }

        [JsonPropertyName("superior5_id")]
        public int? Superior5ID { get; set; }

        [JsonPropertyName("superior6_id")]
        public int? Superior6ID { get; set; }

        [JsonPropertyName("superior7_id")]
        public int? Superior7ID { get; set; }

        [JsonPropertyName("superior8_id")]
        public int? Superior8ID { get; set; }

        [JsonPropertyName("superior9_id")]
        public int? Superior9ID { get; set; }

        [JsonPropertyName("superior10_id")]
        public int? Superior10ID { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

