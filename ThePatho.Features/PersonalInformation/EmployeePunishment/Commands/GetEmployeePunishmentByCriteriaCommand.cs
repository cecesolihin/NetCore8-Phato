using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeePunishment.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeePunishment.Commands
{
    public class GetEmployeePunishmentByCriteriaCommand : IRequest<ApiResponse<EmployeePunishmentItemDto>>
    {


        [JsonPropertyName("employeeId")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("letterNo")]
        public string LetterNo { get; set; } = null!;

        [JsonPropertyName("letterDate")]
        public string LetterDate { get; set; } = null!;
        [JsonPropertyName("punishment")]
        public string Punishment { get; set; } = null!;

    }
}

