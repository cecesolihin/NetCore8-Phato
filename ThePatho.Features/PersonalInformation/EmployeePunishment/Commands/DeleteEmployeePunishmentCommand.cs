using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeePunishment.Commands
{
    public class DeleteEmployeePunishmentCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("EmPunishmentId")]
        public int EmPunishmentId { get; set; }
    }
}

