using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeePunishment.Commands
{
    public class SubmitEmployeePunishmentCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("emPunishmentId")]
        public int? EmPunishmentId { get; set; }

        [JsonPropertyName("letterNo")]
        public string LetterNo { get; set; } = null!;

        [JsonPropertyName("employeeId")]
        public List<int> EmployeeId { get; set; }

        [JsonPropertyName("letterDate")]
        public string LetterDate { get; set; } = null!;

        [JsonPropertyName("punishmentType")]
        public string PunishmentType { get; set; } = null!;

        [JsonPropertyName("validFrom")]
        public string ValidFrom { get; set; } = null!;

        [JsonPropertyName("validTo")]
        public string ValidTo { get; set; } = null!;

        [JsonPropertyName("recoveryDate")]
        public string? RecoveryDate { get; set; }

        [JsonPropertyName("remarks")]
        public string Remarks { get; set; } = null!;

        [JsonPropertyName("attachment")]
        public string Attachment { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

