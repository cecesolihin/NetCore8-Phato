using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.SuperiorSubordinate.Commands
{
    public class SubmitSuperiorSubordinateCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employee_superior_id")]
        public int EmployeeSuperiorID { get; set; }

        [JsonPropertyName("employee_id")]
        public int EmployeeID { get; set; }

        [JsonPropertyName("effective_date")]
        public DateTime EffectiveDate { get; set; }

        [JsonPropertyName("end_date")]
        public DateTime? EndDate { get; set; }

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

        [JsonPropertyName("superior11_id")]
        public int? Superior11ID { get; set; }

        [JsonPropertyName("superior12_id")]
        public int? Superior12ID { get; set; }

        [JsonPropertyName("superior13_id")]
        public int? Superior13ID { get; set; }

        [JsonPropertyName("superior14_id")]
        public int? Superior14ID { get; set; }

        [JsonPropertyName("superior15_id")]
        public int? Superior15ID { get; set; }

        [JsonPropertyName("superior16_id")]
        public int? Superior16ID { get; set; }

        [JsonPropertyName("superior17_id")]
        public int? Superior17ID { get; set; }

        [JsonPropertyName("superior18_id")]
        public int? Superior18ID { get; set; }

        [JsonPropertyName("superior19_id")]
        public int? Superior19ID { get; set; }

        [JsonPropertyName("superior20_id")]
        public int? Superior20ID { get; set; }

        [JsonPropertyName("superior21_id")]
        public int? Superior21ID { get; set; }

        [JsonPropertyName("superior22_id")]
        public int? Superior22ID { get; set; }

        [JsonPropertyName("superior23_id")]
        public int? Superior23ID { get; set; }

        [JsonPropertyName("superior24_id")]
        public int? Superior24ID { get; set; }

        [JsonPropertyName("superior25_id")]
        public int? Superior25ID { get; set; }

        [JsonPropertyName("superior26_id")]
        public int? Superior26ID { get; set; }

        [JsonPropertyName("superior27_id")]
        public int? Superior27ID { get; set; }

        [JsonPropertyName("superior28_id")]
        public int? Superior28ID { get; set; }

        [JsonPropertyName("superior29_id")]
        public int? Superior29ID { get; set; }

        [JsonPropertyName("superior30_id")]
        public int? Superior30ID { get; set; }

        [JsonPropertyName("inserted_by")]
        public string? InsertedBy { get; set; }

        [JsonPropertyName("inserted_date")]
        public DateTime? InsertedDate { get; set; }

        [JsonPropertyName("modified_by")]
        public string? ModifiedBy { get; set; }

        [JsonPropertyName("modified_date")]
        public DateTime? ModifiedDate { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

