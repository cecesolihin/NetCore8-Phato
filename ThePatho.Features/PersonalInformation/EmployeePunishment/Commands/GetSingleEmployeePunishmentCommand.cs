using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeePunishment.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeePunishment.Commands
{
    public class GetSingleEmployeePunishmentCommand : IRequest<ApiResponse<EmployeePunishmentDto>>
    {
        [JsonPropertyName("empunishment_id")]
        public int EmPunishmentId { get; set; }

    }
}
