using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeePunishment.Commands
{
    public class SubmitEmployeePunishmentCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("em_punishment_id")]
        public int? EmPunishmentId { get; set; }

        [JsonPropertyName("letter_no")]
        public string LetterNo { get; set; } = null!;

        [JsonPropertyName("employee_id")]
        public List<int> EmployeeId { get; set; }

        [JsonPropertyName("letter_date")]
        public string LetterDate { get; set; } = null!;

        [JsonPropertyName("punishment_type")]
        public string PunishmentType { get; set; } = null!;

        [JsonPropertyName("valid_from")]
        public string ValidFrom { get; set; } = null!;

        [JsonPropertyName("valid_to")]
        public string ValidTo { get; set; } = null!;

        [JsonPropertyName("recovery_date")]
        public string? RecoveryDate { get; set; }

        [JsonPropertyName("remarks")]
        public string Remarks { get; set; } = null!;

        [JsonPropertyName("attachment")]
        public string Attachment { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

